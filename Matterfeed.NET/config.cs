﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace Matterfeed.NET
{
    public class Config
    {
       

        public int BotCheckIntervalMs { get; set; } = 30000; //Default to 30 seconds, but configure it in the secrets file
        public string MattermostWebhookUrl { get; set; } = "";

        public string BotChannelDefault { get; set; } = "";
        public string BotNameDefault { get; set; } = "";
        public string BotImageDefault { get; set; } = "";

        public List<RssFeed> RssFeeds { get; set; }
        public List<RedditJsonFeed> RedditJsonFeeds { get; set; }
        public TwitterFeed TwitterFeed { get; set; }


        public void Save(string path)
        {
            // serialize JSON directly to a file
            using (var file = File.CreateText(path))
            {
                var serializer = new JsonSerializer {Formatting = Formatting.Indented};
                serializer.Serialize(file, this);
            }
        }
    }

    public class RssFeed
    {
        public bool FallbackMode { get; set; } = false;
        public string FeedPretext { get; set; }
        
        public string Url { get; set; }

        public string BotChannelOverride { get; set; } = "";
        public string BotNameOverride { get; set; } = "";
        public string BotImageOverride { get; set; } = "";

        public bool IncludeContent { get; set; } = true;
       
        public DateTime? LastProcessedItem { get; set; } = new DateTime();
    }

    public class RedditJsonFeed
    {
        public string FeedPretext { get; set; }
        public string Url { get; set; }
        public string BotChannelOverride { get; set; } = "";
        public string BotNameOverride { get; set; } = "";
        public string BotImageOverride { get; set; } = "";
        public DateTime? LastProcessedItem { get; set; } = new DateTime();
    }

    public class TwitterFeed
    {
        public int Interval { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
        

        public List<TwitterSearch> Searches { get; set; }
    }

    public class TwitterSearch
    {
        public string FeedPretext { get; set; }
        public string SearchTerm { get; set; }
        public string BotChannelOverride { get; set; } = "";
        public string BotNameOverride { get; set; } = "";
        public string BotImageOverride { get; set; } = "";
        public long LastProcessedId { get; set; } = 0;
    }
}