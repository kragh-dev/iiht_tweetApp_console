using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Com.Tweetapp.Model
{
    public partial class Tweet
    {
        public int TweetId { get; set; }
        public int? UserId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual AppUser User { get; set; }
    }
}
