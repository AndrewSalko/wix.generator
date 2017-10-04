using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace wix.generator
{
	public class WixComponentRef
	{
		[XmlAttribute]
		public string Id
		{
			get;
			set;
		}
	}
}
