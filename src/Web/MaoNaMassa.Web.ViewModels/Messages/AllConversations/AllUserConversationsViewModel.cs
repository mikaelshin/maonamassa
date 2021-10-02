﻿namespace MaoNaMassa.Web.ViewModels.Messages.AllConversations
{
    using System;

    using MaoNaMassa.Common;
    using MaoNaMassa.Data.Models;
    using MaoNaMassa.Services.Mapping;

    public class AllUserConversationsViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfileImageUrl { get; set; }

        public string LastMessage { get; set; }

        public bool IsOnline { get; set; }

        public string ShortenedLastMessage => this.LastMessage.Length > 30 ? this.LastMessage.Substring(0, 30) : this.LastMessage;

        public DateTime ReceivedDate { get; set; }

        public string ReceivedDateTimeAgo => TimeCalculator.GetTimeAgo(this.ReceivedDate);
    }
}
