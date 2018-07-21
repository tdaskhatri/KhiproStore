using System;
using System.Xml;
using System.Collections;

namespace eLearning.Common.Config
{
	public class XmlConfigReader : IConfigReader
	{
        private const string INVALID_CONFIG_FILE = "Invalid Configuration file. Make sure it should be proper XML document";

		private class IConfigSectionImpl : IConfigSection
		{
            private XmlElement node;

			public IConfigSectionImpl(XmlNode node)
			{
				this.node = (XmlElement)node;
			}

			public XmlElement XmlNode
			{
				get
				{
					return this.node;
				}
				set
				{
					if(this.node == null)
						throw new System.NullReferenceException( "The value null was found where " +
							          "an instance of an XmlElement was required" );

					this.node = value;
				}
			}
			
			public string Name
			{
				get { return this.node.Name; }
			}

            public string Value
            {
                get { return this.node.InnerText; }
            }


			public bool HasChild(string name)
			{
				return(this.node.SelectSingleNode(name) != null);
			}

			public IConfigSection GetChild(string name)
			{
				XmlNode oNode = this.node.SelectSingleNode(name);

				if(null == oNode)
					throw new ConfigurationException( "Node {0} not found. Parent Node {1}", name, this.node.Name);

				return new IConfigSectionImpl(oNode);
			}

			public string GetAttribValue(string name)
			{
				if( !this.node.HasAttribute(name) )
                    throw new ConfigurationException("Parameter {0} not found. Section {0}", name, this.node.Name);

				return this.node.GetAttribute(name);
			}

			public string GetTextValue(string name)
			{
				return this.GetAttribValue(name);
			}

			public int GetInt32Value(string name)
			{
				string strVal = this.GetAttribValue(name);
				try
				{
					return XmlConvert.ToInt32(strVal);
				}
				catch(Exception excep)
				{
                    throw new ConfigurationException(excep, "Failed to parse the value {0} as int. Attribute {1} in {2} section", 
                                                 strVal, name, this.Name);
				}
			}

            public bool GetBoolValue(string name)
            {
                string strVal = this.GetAttribValue(name).ToLower();
                bool retVal;

                if( (strVal.CompareTo("1") == 0) || (strVal.CompareTo("true") == 0) || 
                    (strVal.CompareTo("y") == 0))
                    retVal = true;
                else if( (strVal.CompareTo("0") == 0) || (strVal.CompareTo("false") == 0) || 
                         (strVal.CompareTo("n") == 0))
                    retVal = false;
                else
                    throw new ConfigurationException("Failed to parse the value {0} as bool. Attribute {1} in {2} section",
                                                     strVal, name, this.Name);
                return retVal;
            }

			public string GetValue(string name, string defVal)
			{
				if( this.node.HasAttribute(name) )
					defVal = this.node.GetAttribute(name);

				return defVal;
			}

			public bool GetValue(string name, bool defVal)
			{
				if( this.node.HasAttribute(name) )
				{
					try
					{
						defVal = XmlConvert.ToBoolean( this.node.GetAttribute(name) );
					}
					catch(Exception)
					{}
				}

				return defVal;
			}

			public int GetValue(string name, int defVal)
			{
				if( this.node.HasAttribute(name) )
				{
					try
					{
						defVal = XmlConvert.ToInt32( this.node.GetAttribute(name) );
					}
					catch(Exception)
					{}
				}

				return defVal;
			}

			public override string ToString()
			{
				return this.node.InnerXml;
			}

			public IConfigSection[] ChildSections
			{
				get
				{
					if( this.node == null)
						return null;

					if(!this.node.HasChildNodes)
						return null;

					IConfigSectionImpl oTemp = null;
					ArrayList childList = new ArrayList(this.node.ChildNodes.Count);
					foreach(XmlNode oNode in this.node.ChildNodes)
					{
						if(oNode.NodeType == XmlNodeType.Element)
						{
							oTemp = new IConfigSectionImpl(oNode);
							childList.Add(oTemp);
						}
					}

					if(childList.Count == 0)
						return null;

					return (IConfigSectionImpl[])childList.ToArray(oTemp.GetType());
				}
			}
		}

		private static XmlConfigReader singleton = new XmlConfigReader();
		
		private XmlConfigReader()
		{}

		public static IConfigReader Instance
		{
			get {return singleton;}
		}

		public IConfigSection Load(string fileUrl)
		{
			XmlDocument oDoc = new XmlDocument();
			try
			{
				oDoc.Load(fileUrl);
			}
			catch(XmlException excep)
			{
				throw new ConfigurationException(excep, INVALID_CONFIG_FILE);
			}
			return new IConfigSectionImpl(oDoc.DocumentElement);
		}

		public IConfigSection LoadData(string confData)
		{
			XmlDocument oDoc = new XmlDocument();
			try
			{
				oDoc.LoadXml(confData);
			}
			catch(XmlException excep)
			{
                throw new ConfigurationException(excep, INVALID_CONFIG_FILE);
			}

			return new IConfigSectionImpl(oDoc.DocumentElement);
		}
	}
}
