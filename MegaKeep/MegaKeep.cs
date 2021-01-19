using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaKeep
{
	public partial class MegaKeep : Form
	{
		private string _local = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		private string[] commandlineArgs = { };

		public MegaKeep(string[] args)
		{
			InitializeComponent();

			if (args.Length == 0)
				return;

			commandlineArgs = args;
			var txtFileIndex = Array.IndexOf(args, "--txtFile") + 1;
			var txtFile = args[txtFileIndex];

			if (File.Exists(txtFile))
			{
				Properties.Settings.Default.Location = txtFile;
				Properties.Settings.Default.Save();
				txtPath.Text = txtFile;
			}
		}

		private async void btnRun_ClickAsync(object sender, EventArgs e)
		{
			txtLog.Clear();

			// first make sure megacmd is found
			if (!File.Exists(_local + "\\MEGAcmd\\mega-login.bat"))
			{
				Log("mega-login.bat was not found, please install it to the default directory: https://mega.nz/cmd");
				return;
			}

			// then check to make sure the file exists and it's actually a txt file
			if (!File.Exists(txtPath.Text) || txtPath.Text.Substring(txtPath.Text.LastIndexOf(".")) != ".txt")
			{
				Log("The file could not be found or is not a .txt file");
				return;
			}

			Log("Loading file...");

			// then try to read the text file's contents
			string[] lines;
			try
			{
				lines = File.ReadAllLines(txtPath.Text);
			}
			catch (Exception ex)
			{
				Log("Error: " + ex.ToString());
				return;
			}

			// run the processes in a task so it doesn't freeze the ui
			await Task.Run(() => Work(lines));

			if (commandlineArgs.Contains("--cli")) // if running in cli mode, closes window after running work
				this.Close();
		}

		private string Login(string user, string pass)
		{
			Process login = new Process
			{
				StartInfo =
				{
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					CreateNoWindow = true,
					FileName = _local + "\\MEGAcmd\\mega-login.bat",
					Arguments = user + " \"" + pass + "\""
				}
			};

			Log("Logging into " + user + "...");

			login.Start();
			var result = login.StandardOutput.ReadToEnd();
			login.WaitForExit();

			if (login.HasExited)
				return result;
			else
				return "Unable to exit the process";
		}

		private string Logout()
		{
			Process logout = new Process
			{
				StartInfo =
				{
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true,
					CreateNoWindow = true,
					FileName = _local + "\\MEGAcmd\\mega-logout.bat"
				}
			};

			// the process doesn't exit, just return failed
			var result = "Failed to exit the process";

			// 10 attempts to logout
			for (var i = 0; i < 10; i++)
			{
				logout.Start();
				logout.WaitForExit();

				if (logout.HasExited)
				{
					var res = logout.StandardOutput.ReadToEnd();

					if (res == "Logging out..." + Environment.NewLine)
					{
						result = "Success";
						break;
					}
					else
					{
						Log("Unable to log out (Attempt #" + (i + 1) + ")");
						result = res;
					}
				}
			}

			return result;
		}

		private void Work(string[] lines)
		{
			// loop through every line
			foreach (var line in lines)
			{
				var info = line.Split(':');

				// check line format
				if (info.Length != 2)
				{
					// log error and skip if bad user pass format
					Log("Colon (:) seperator not found. Error: " + line);
					continue;
				}

				var user = info[0];
				var pass = info[1];

				/* NOTE
				 * the for loop's purpose is in case the account is already
				 * logged into mega. this can happen if the user closes out
				 * of megakeep before the cycle ends or because the user
				 * is actively using megacmd
				 */

				for (var i = 0; i < 2; i++)
				{
					var loginResult = Login(user, pass);

					if (loginResult == "")
					{
						// login was successful
						Log("Login succeeded. Logging out...");
					}
					else if (loginResult.Contains("Failed"))
					{
						Log("Failed: " + loginResult);
						break; // just move on to the next account
					}
					else if (loginResult.Contains("Already logged in"))
					{
						Log("Already logged in. Logging out...");
					}

					Thread.Sleep(2000);

					var logout = Logout();

					if (logout == "Success")
					{
						Log("Logged out");

						Thread.Sleep(2000);

						// we don't want to login to the same account again
						// so we're going to break out of the loop
						if (loginResult == "")
							break;
					}
					else
					{
						/* NOTE
						 * I've never had this happen before.
						 * however if this done happen,
						 * the loop will be ended since there's no
						 * point in continuing if logging out doesn't work
						 */

						Log("Unable to logout. Error: " + logout);
						return;
					}
				}
			}

			Log("Finished");
			File.WriteAllLines(Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "-log.txt", txtLog.Lines);
		}

		private void btnLocate_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFile = new OpenFileDialog();

			openFile.Multiselect = false;
			openFile.Title = "Mega Keepalive";
			openFile.Filter = "Text Files (*.txt)|*.txt";

			if (openFile.ShowDialog() == DialogResult.OK)
			{
				txtPath.Text = openFile.FileName;
			}
		}

		private void Log(string txt)
		{
			this.Invoke((MethodInvoker)delegate
			{
				var time = "[" + DateTime.Now.ToString("hh:mm:ss tt") + "] ";

				txtLog.AppendText(time + txt + Environment.NewLine);
			});
		}

		private void MegaKeep_Load(object sender, EventArgs e)
		{
			// if started with arg "--cli" simulate button click in UI
			if (commandlineArgs.Contains("--cli"))
				btnRun.PerformClick();

			txtPath.Text = Properties.Settings.Default.Location;
		}

		private void txtPath_TextChanged(object sender, EventArgs e)
		{
			Properties.Settings.Default.Location = txtPath.Text;
			Properties.Settings.Default.Save();
		}
	}
}
