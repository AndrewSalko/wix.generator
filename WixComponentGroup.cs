using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace wix.generator
{
	public class WixComponentGroup
	{
		[XmlAttribute]
		public string Id
		{
			get;
			set;
		}

		[XmlElementAttribute("ComponentRef")]
		public WixComponentRef[] Components
		{
			get;
			set;
		}

		List<WixComponentRef> _Components;

		internal void Add(WixComponentRef comp)
		{
			if (_Components == null)
				_Components = new List<WixComponentRef>();

			_Components.Add(comp);
		}

		internal void PrepareToSerialization()
		{
			if (_Components != null)
				Components = _Components.ToArray();
		}


	}
}
