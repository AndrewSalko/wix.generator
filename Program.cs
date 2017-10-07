using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace wix.generator
{
	class Program
	{
		static int Main(string[] args)
		{
			bool showHelp = false;

			if (args == null || args.Length == 0)
			{
				showHelp = true;
			}
			else
			{
				if (args.Length == 1 && !string.IsNullOrWhiteSpace(args[0]) && args[0] == "/?")
				{
					showHelp = true;
				}
			}

			if (showHelp)
			{
				var versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
				var version = string.Format("{0}.{1}", versionInfo.FileMajorPart, versionInfo.FileMinorPart);
				var company = versionInfo.CompanyName;

				Console.WriteLine(string.Format("Wix Library Generator {0} by {1}", version, company));
				Console.WriteLine("Creates WIX installer .wxs file automatically from specified directory (files and subfolders will be processed)");
				Console.WriteLine("");

				Console.WriteLine("Usage:");

				string usageExample = "wix.generator.exe /dir \"C:\\yourproject\" /wixsourcepath \"\\bin\\Release\"  /groupid \"GroupIDForYourInstallation\" /rootid \"DirIDForYourInstallation\" /resultfile library.wxs";
				Console.WriteLine(usageExample);


				Console.WriteLine("");
				Console.WriteLine("Switches:");
				Console.WriteLine(" /dir <path to your directory> - files and subfolders will be added to .wxs file");

				Console.WriteLine("");
				Console.WriteLine(string.Format(" /wixsourcepath <relative path> - this path should be relative (from your .wixproj project) where source files will be located. It will be used in your .wxs file as '{0}' variable, you can correct it later manually.", WixRoot.SOURCE_DIRECTORY_VARIABLE));
				
				Console.WriteLine("");
				Console.WriteLine(" /groupid <name> - your name for root component group (something like 'mycomponentgroupid')");
				Console.WriteLine(" /rootid <name> - your wix root directory id (something like 'mydirectoryid')");
				Console.WriteLine(" /resultfile <file path> - path to result .wxs file");
				Console.WriteLine(" /? - help screen");

				return -1;
			}

			string dir = null;
			string wixSourcePath = null;
			string groupID = null;
			string rootID = null;
			string resultFile = null;

			try
			{
				for (int i = 0; i < args.Length; i++)
				{
					string arg = args[i];
					string argLow = arg.ToLower();

					if (argLow == "/dir")
					{
						dir = args[i + 1];
					}

					if (argLow == "/wixsourcepath")
					{
						wixSourcePath = args[i + 1];
						wixSourcePath = wixSourcePath.Trim('"');
					}

					if (argLow == "/groupid")
					{
						groupID = args[i + 1];
						groupID = groupID.Trim('"');
					}

					if (argLow == "/rootid")
					{
						rootID = args[i + 1];
						rootID = rootID.Trim('"');
					}

					if (argLow == "/resultfile")
					{
						resultFile = args[i + 1];
						resultFile = resultFile.Trim('"');
					}
				}
			}
			catch (IndexOutOfRangeException)
			{
				Console.WriteLine("Error: incorrect arguments usage");
				return -1;
			}

			if(string.IsNullOrWhiteSpace(dir))
			{
				Console.WriteLine("Error: 'dir' not specified");
				return -1;
			}

			if (string.IsNullOrWhiteSpace(wixSourcePath))
			{
				Console.WriteLine("Error: 'wixsourcepath' not specified");
				return -1;
			}

			if (string.IsNullOrWhiteSpace(groupID))
			{
				Console.WriteLine("Error: 'groupid' not specified");
				return -1;
			}

			if (string.IsNullOrWhiteSpace(rootID))
			{
				Console.WriteLine("Error: 'rootid' not specified");
				return -1;
			}

			if (string.IsNullOrWhiteSpace(resultFile))
			{
				Console.WriteLine("Error: 'resultfile' not specified");
				return -1;
			}

			try
			{
				if (!Directory.Exists(dir))
				{
					Console.WriteLine("Error: directory {0} not exists", dir);
					return -2;
				}

				WixRoot root = new WixRoot(dir, wixSourcePath);
				root.Fragment.ComponentGroup.Id = groupID;
				var rootDirRef = root.Fragment.DirectoryRef;

				rootDirRef.Id = rootID;
				rootDirRef.Name = null;
				rootDirRef.FileSource = string.Format("$(var.{0})", WixRoot.SOURCE_DIRECTORY_VARIABLE);
				rootDirRef.DiskId = "1";
				
				root.Serialize(resultFile);

				Console.WriteLine("Done");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
				return -2;
			}

			return 0;
		}
	}
}
