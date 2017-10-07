# WiX Generator
Automatically creates .wxs file for [Wix Toolset](http://wixtoolset.org/). You may use it in your installation project (or wix library).

##
System requirements
Windows and .NET Framework 4.0 or later. Try to start program, it's very possible you already have .NET installed.

##
Usage

wix.generator.exe **/dir** "C:\yourproject\project\bin\Release" **/wixsourcepath** "..\project\bin\Release"  **/groupid** "GroupIDForYourInstallation" **/rootid** "DirIDForYourInstallation" **/resultfile** library.wxs

**Note**: don't add backslash to the end of your paths in /dir or /wixsourcepath arguments.

All files and subfolders in specified **/dir argument** will be added to result .wxs file.

The **/wixsourcepath** argument specifies the relative path to the folder 
you specified in **/dir**. The installation project will "search" for files 
on it. Most likely you will store the installation project (wix) on the 
repository next to your project, so the path to the **bin\Release folder** will be relative 
(relative to the installation). 

The **/groupid** argument contains the group component identifier in the 
wix project. You can invent it at your discretion.

The **/rootid** argument contains the folder identifier in the wix project.


##Support the project
If you like this utility and you want to support the development:

**LTC**:LWNyqqMzdC2sAZa1XGKUCm62Qfd7k4Md23
**ETH**:0x5c153d2B653ab7925FC0fE7cf585e7628EDc9d32
**PPC**:PQazRKkaKHi99RnK3cUxbfmnxQFengc9Rd
**FTC**:6nvBitWATH1ar2cJc64ogf58VLQUrSbKkQ
**NEM**:NBJ4PI-2XKD33-PNJLZY-QSB57D-4ICIV3-C2ME5N-B2V6
**XLM**:GABERDH63VVBJQ6ITVSAIXXBBPKSDGBQGIIZ6C2USMWIG5HHYLU7INXU
**GRC**:SAesjyp8cpwWGz5UCJwzDVigR7VPTiicne

