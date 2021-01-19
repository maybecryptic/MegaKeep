using System;
using System.IO;
using System.Windows.Forms;

namespace MegaKeep
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			CommandArgs(args);
			Application.Run(new MegaKeep(args)); //passes args to new start method
		}

		// sets the path to the text file passed via command line.
		static void CommandArgs(string[] args)
		{
			if (args.Length > 0)
			{
				var txtFileIndex = Array.IndexOf(args, "--txtFile") + 1;
				if(args[txtFileIndex] != null)
				{
					var txtFile = args[txtFileIndex];
					if (File.Exists(txtFile))
					{
						Properties.Settings.Default.Location = txtFile;
						Properties.Settings.Default.Save();
					}
				}
				
			}
		}
	}
}
