using MachineLearningTool.AbstractEntities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Streaming;

namespace MachineLearningTool
{
    //This class will be responsible for downloading tweets and saving them to the database
    public class TwitterMessageDownloader : MessageDownloader
    {
        public Action<string> StatusUpdate { get; set; }
        public Action<string, Image> UpdateStreamedTweetsScreen { get; set; }
        private int m_downloadCounter = 0;
        private IFilteredStream m_stream { get; set; }
        private WebClient m_webclient = new WebClient();
        private JArray m_downloadSequenceSetting = null;
        private (bool AllowRetweets, bool OnlyVerifiedUser) m_userDefinedSetting;
        private int m_downloadLimit = 0;
        public TwitterMessageDownloader(JToken downloadProcessConfig, Action<string> statusUpdate, Action<string, Image> updateStreamedTweetsScreen, bool startDownload = false)
        {
            m_downloadSequenceSetting = JArray.FromObject(downloadProcessConfig);
            StatusUpdate = statusUpdate;
            UpdateStreamedTweetsScreen = updateStreamedTweetsScreen;

            if (startDownload)
                StartDownload();
        }


        public override async void StartDownload()
        {
            for (int i = 0; i < m_downloadSequenceSetting.Count; i++)
            {
                m_downloadCounter = 0;
                bool allowRetweets = bool.Parse(m_downloadSequenceSetting[i]["AllowRetweets"].ToString());
                bool onlyVerifiedUser = bool.Parse(m_downloadSequenceSetting[i]["OnlyVerifiedUser"].ToString());

                m_userDefinedSetting = (allowRetweets, onlyVerifiedUser);
                m_downloadLimit = int.Parse(m_downloadSequenceSetting[i]["Amount"].ToString());

                CreateNewStream(JArray.FromObject(m_downloadSequenceSetting[i]["TweetKeyWords"]));


                while (m_downloadCounter <= m_downloadLimit)
                {
                    //Keep looping untill the download limit is reached
                    await m_stream.StartStreamMatchingAllConditionsAsync();
                }
            }
        }

        private void CreateNewStream(JArray trackCollection)
        {
            m_stream = Tweetinvi.Stream.CreateFilteredStream();
            m_stream.AddTweetLanguageFilter(LanguageFilter.English);
            AssignStreamEventHandlers();
            AddTracks(trackCollection);
        }


        private void AddTracks(JArray trackCollection)
        {
            foreach (JToken word in trackCollection)
            {
                m_stream.AddTrack(word.ToString());
            }
        }


        private void AssignStreamEventHandlers()
        {
            m_stream.MatchingTweetReceived += (sender, matchedTweetReceived) =>
            {
                if (m_downloadCounter <= m_downloadLimit)
                {
                    //Extract details from tweet
                    ITweet originalTweet = ExtractTweetDetails(matchedTweetReceived.Tweet);

                    //If tweet matches requirements continue
                    if (IsTweetValid(originalTweet))
                    {
                        m_downloadCounter++;

                        //Download tweeters profilepic 
                        Image profilepic = Image.FromStream(new MemoryStream(m_webclient.DownloadData(originalTweet.CreatedBy.ProfileImageUrl)));

                        var tweetDetails = (profilePic: profilepic, userScreenName: originalTweet.CreatedBy.ScreenName, userId: originalTweet.CreatedBy.Id, tweetMessage: originalTweet.FullText);

                        //Update grid
                        UpdateStreamedTweetsScreen(originalTweet.FullText, profilepic);

                        //Save to the database


                    }
                }
                else
                {
                    EndDownloader();
                    //All tweets downloaded
                }
            };

            m_stream.StreamStarted += (sender, eventargs) =>
            {
                StatusUpdate("Tweets Download Started");
            };

            m_stream.StreamStopped += (sender, eventargs) =>
            {
                StatusUpdate("Tweets Download Stopped");
            };
        }

        public void EndDownloader()
        {
            m_stream.StopStream();
            m_stream = null;
        }

        private ITweet ExtractTweetDetails(ITweet tweet)
        {
            if (tweet.IsRetweet)
                tweet = ExtractTweetDetails(tweet.RetweetedTweet);

            return tweet;
        }

        private bool IsTweetValid(ITweet tweet)
        {
            bool isTweetLengthValid = tweet.FullText.Split(' ').Count() < 10;//
            //bool isVerifiedSettingMatch = tweet.CreatedBy.Verified == m_userDefinedSetting.OnlyVerifiedUser;
            bool isVerifiedSettingMatch = (m_userDefinedSetting.OnlyVerifiedUser && !tweet.CreatedBy.Verified) ? false : true;

            bool isRetweetedSettingMatch = tweet.IsRetweet == m_userDefinedSetting.AllowRetweets;
            //return isTweetSourceVerified;//isTweetLengthValid &&
            return true;
        }
    }
}
