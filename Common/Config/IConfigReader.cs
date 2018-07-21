using System;

namespace eLearning.Common.Config
{
    public class ConfigurationException : System.ApplicationException
    {
        public ConfigurationException(string format, params object[] args)
            : base(string.Format(format, args))
        { }

        public ConfigurationException(Exception innerExcep, string message)
            : base(message, innerExcep)
        { }
        public ConfigurationException(Exception innerExcep, string format, params object[] args)
            : base(string.Format(format, args), innerExcep)
        { }
    }

    public interface IConfigSection
    {
        string Name
        {
            get;
        }

        IConfigSection GetChild(string name);
        //IConfigSection GetChild(string name,string moduleID);
         
        bool HasChild(string name);

        string GetTextValue(string name);
        int GetInt32Value(string name);
        bool GetBoolValue(string name);

        string GetValue(string name, string defVal);
        int GetValue(string name, int defVal);
        bool GetValue(string name, bool defVal);

        string ToString();

        IConfigSection[] ChildSections
        {
            get;
        }
    }

    public interface IConfigReader
    {
        IConfigSection Load(string fileUrl);

        //IConfigSection Load(string fileUrl,string moduleID);
        IConfigSection LoadData(string confData);
    }
}
