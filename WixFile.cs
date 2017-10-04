using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.IO;


namespace wix.generator
{
	[Serializable]
	public class WixFile
	{
		public WixFile()
		{
		}

		public WixFile(string fileName)
		{
			Name = Path.GetFileName(fileName);
			Id = WixDir.PrepareID("File_", Name);
		}

		[XmlAttribute]
		public string Name
		{
			get;
			set;
		}

		[XmlAttribute]
		public string Id
		{
			get;
			set;
		}



	}
}
