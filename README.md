MegaKeep
========

![MegaKeep](https://i.imgur.com/43lLYFx.png)

This program will allow you to login to all of your mega accounts to avoid deletion due to inactivity.

> Please note while this program should work, it has not been completely tested. Doing so requires waiting for an email from mega saying "[MEGA is missing you!](https://i.imgur.com/OIY3RQq.png)", and then waiting to see if you get the following email "[Your MEGA account is inactive](https://i.imgur.com/quT4Rmk.png)".

## Requirements

You must have MEGAcmd installed and running on your machine. You can download the program here: https://mega.nz/cmd

## Instructions

Create a text file (.txt) of all your mega accounts and passwords in a `user:pass` format with one account per line. Then locate that file and run the program.

## Command Line

You are also able to start the program via command line.

`--cli` will auto-click the run button and run whatever file is already loaded

`--txtFile "C:\path\to\txtfile.txt"` will load the text file into the program

## Contributing

When making a pull request, please provide a thorough explanation of what you added/fixed. Suggestions are welcome in the form of issues.

## Version History

v1.0

- Initial Release

v1.1

- Fixed the UI freezing (via Task)
- Added timestamps to logging
- Added log saving

v2.0

- Rewrote the base code for the program
- The program will no longer completely restart if an account is already logged in
- The log now automatically scrolls down with the log instead of jumping to the top
