using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.IO;


namespace wix.generator
{
	[Serializable]
	public class WixComponent
	{
		public WixComponent(string[] files, string id)
		{
			Guid = "{" + System.Guid.NewGuid().ToString().ToUpper() + "}";
			Id = id;

			List<WixFile> fileslist = new List<WixFile>();
			foreach (var file in files)
			{
				fileslist.Add(new WixFile(file));
			}

			Files = fileslist.ToArray();
		}

		public WixComponent()
		{
		}

		[XmlAttribute]
		public string Id
		{
			get;
			set;
		}

		[XmlAttribute]
		public string Guid
		{
			get;
			set;
		}

		[System.Xml.Serialization.XmlElementAttribute("File")]
		public WixFile[] Files
		{
			get;
			set;
		}


	}
}
