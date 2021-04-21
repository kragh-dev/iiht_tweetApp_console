using Com.Tweetapp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace tweetApp_console.Com.Tweetapp.Dao
{
    interface ITweetDao
    {
        string PostTweet(Tweet tweet);
        List<Tweet> ViewMyTweets(int userId);
        List<Tweet> ViewAllTweets();
    }
}
