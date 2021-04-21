using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Com.Tweetapp.Model;
using Microsoft.EntityFrameworkCore;
using tweetApp_console.Com.Tweetapp.Dao;

namespace Com.Tweetapp.Dao
{
    class TweetDao : ITweetDao
    {
        tweetAppDbContext tweetApp = new tweetAppDbContext();
        public string PostTweet(Tweet tweet)
        {
            try
            {
                Tweet newTweet = new Tweet();
                newTweet.UserId = tweet.UserId;
                newTweet.Text = tweet.Text;
                newTweet.CreatedAt = tweet.CreatedAt;
                tweetApp.Tweet.Add(newTweet);
                tweetApp.SaveChanges();
                return "Posted Successfully...";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public List<Tweet> ViewAllTweets()
        {
            return tweetApp.Tweet.Include(t => t.User).ToList();
        }

        public List<Tweet> ViewMyTweets(int userId)
        {
            return tweetApp.Tweet.Include(t => t.User).Where(t => t.UserId == userId).ToList();
        }
    }
}
