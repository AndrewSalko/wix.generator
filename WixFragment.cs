using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;

namespace wix.generator
{
	[Serializable]
	public class WixFragment
	{
		public WixComponentGroup ComponentGroup
		{
			get;
			set;
		}


		public WixDir DirectoryRef
		{
			get;
			set;
		}
		

	}
}
