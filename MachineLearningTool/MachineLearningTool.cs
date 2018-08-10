using MachineLearningTool.Entities;
using MachineLearningTool.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tweetinvi;
using Tweetinvi.Events;
using Tweetinvi.Models;
using Tweetinvi.Streaming;

namespace MachineLearningTool
{
    public partial class frmMachineLearningTool : Form
    {
        private Action<string> m_statusUpdate = null;
        private Action<string, Image> m_updateStreamedTweetsScreen = null;
        private Action<object, QueryAwaitingEventArgs> m_queryAwaitingRateLimit = null;


        public frmMachineLearningTool()
        {
            InitializeComponent();
        }


        private void frmMachineLearningTool_Load(object sender, EventArgs e)
        {
            //Load Credentials
            Auth.SetUserCredentials(Settings.Default.ConsumerKey, Settings.Default.ConsumerSecret, Settings.Default.UserAcessToken, Settings.Default.UserAccessTokenSecret);
 
            m_queryAwaitingRateLimit = (source, queryAwaitingEventArgs) =>
            {
                //Log the query that is being awaited and the remaining awaiting time
                //possibly change credentials and continue
                m_statusUpdate($"Rate Limit Will Be Reset In {queryAwaitingEventArgs.ResetDateTime.ToShortTimeString()}");
            };

            m_updateStreamedTweetsScreen = (screenMessage, image) =>
            {
                if (dgvTweetDownloads.InvokeRequired)
                {
                    dgvTweetDownloads.Invoke(m_updateStreamedTweetsScreen, screenMessage, image);
                }
                else
                {
                    dgvTweetDownloads.Rows.Add(image, screenMessage);
                }
            };

            //An action delegate used to display status messages
            m_statusUpdate = (updateMessage) =>
            {
                if (ssStatusSection.InvokeRequired)
                {
                    ssStatusSection.Invoke(m_statusUpdate, updateMessage);
                }
                else
                {
                    tsslStatus.Text = updateMessage;
                }
            };

            RateLimit.RateLimitTrackerMode = RateLimitTrackerMode.TrackAndAwait;
            RateLimit.QueryAwaitingForRateLimit += new EventHandler<QueryAwaitingEventArgs>(m_queryAwaitingRateLimit);
        }


        private void btnStreamTweets_Click(object sender, EventArgs e)
        {
            //Get project path
            string testConfigPath = $"{Directory.GetCurrentDirectory()}/{Settings.Default.DownloadConfigLocation}";

            JObject downloadSettings = JObject.Parse(File.ReadAllText(testConfigPath));

            TestInitiationProcessor.InitiateTests(downloadSettings, m_statusUpdate, m_updateStreamedTweetsScreen);
        }
    }
}
