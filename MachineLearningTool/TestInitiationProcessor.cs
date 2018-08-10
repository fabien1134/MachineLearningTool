using MachineLearningTool.AbstractEntities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Events;

namespace MachineLearningTool.Entities
{
    public static class TestInitiationProcessor
    {
        private static List<MessageDownloader> m_messageDownloaders = new List<MessageDownloader>();
        private static List<Task> m_downloadTasks = new List<Task>();


        //This method will initiate tests defined in the configuration
        public static void InitiateTests(JObject downloadSettings, Action<string> statusUpdate, Action<string, Image> updateStreamedTweetsScreen)
        {
            m_messageDownloaders = new List<MessageDownloader>();

            if (!bool.TryParse(downloadSettings["OnlyDisplaySavedData"].ToString(), out bool onlyDisplaySavedData))
                throw new Exception("Issue While Parsing OnlyDisplaySavedData");

            foreach (JToken dataSourceConfig in downloadSettings["DataSourceTestConfigs"])
            {
                string dataSourceName = dataSourceConfig["DataSource"].ToString();
                if (!Enum.TryParse(dataSourceName, out DataSource dataSource))
                    throw new Exception($"{dataSourceName} Is Not A Valid Enum Name");

                switch (dataSource)
                {
                    case DataSource.Twitter:

                        JArray downloadProcessConfigs = JArray.FromObject(dataSourceConfig["DownloadProcessConfigs"]);

                        foreach (JToken downloadProcessConfig in downloadProcessConfigs)
                        {
                            //m_downloadTasks
                            m_downloadTasks.Add(Task.Factory.StartNew(() =>
                            {
                                m_messageDownloaders.Add(new TwitterMessageDownloader(downloadProcessConfig, statusUpdate, updateStreamedTweetsScreen, true));
                            }, TaskCreationOptions.LongRunning));
                        }

                        break;
                }
            }
        }
    }

    public enum DataSource
    {
        Twitter = 0
    };
}
