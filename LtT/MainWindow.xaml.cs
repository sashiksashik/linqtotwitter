using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LinqToTwitter;
namespace LinqToTwitter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainFunction()
        {
            Tweets.Text = "";
            var auth = new SingleUserAuthorizer
            {
                Credentials = new SingleUserInMemoryCredentials
                {
                    ConsumerKey = "t3aTtDc1ycxZRFGWGe7ODQ",
                    ConsumerSecret = "El1eDr0x9xX1E8gxxV0J4V3vOe9HLQtkYZLhyJ18xpA",
                    TwitterAccessToken = "176353513-dMdE0uB2JQfywVYIH1HCIOxfgnTdjCc9ZNXjOYAG",
                    TwitterAccessTokenSecret = "UTkm8syPwee9eShd7RlRe7lahMygDmK65DhfCsI0oTgdw"
                }
            };

            var twitterCtx = new TwitterContext(auth);
            var tweetResponse =
                (from tweet in twitterCtx.Status
                 where tweet.Type == StatusType.User &&
                       tweet.ScreenName == AccountName.Text &&
                       tweet.IncludeRetweets == true
                 select tweet)
                .ToList();
            var tweets = tweetResponse.OrderByDescending(item => item.CreatedAt).Take(int.Parse(TweetsCount.Text));

            foreach (var tweet in tweets)
            {
                Tweets.Text +="Name : " + tweet.ScreenName + ", Tweet: " + tweet.Text + "\n";
            }
        }
        private void getTweets(object sender, RoutedEventArgs e)
        {
            MainFunction();
        }

    }
}
