using System.Configuration;

namespace Lab.App.Helpers
{
    public sealed class Settings
    {
        public bool InDevelopment
        {
            get
            {
                return ConfigurationManager.AppSettings["InDevelopment"] == "true";
            }
        }

        public string FilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["FilePath"];
            }
        }
    }
}
