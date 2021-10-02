﻿namespace MaoNaMassa.Web.ViewModels.Messages
{
    using System;

    using MaoNaMassa.Data.Models;
    using MaoNaMassa.Services.Mapping;

    public class UserMessageViewModel : IMapFrom<Message>
    {
        public string Content { get; set; }

        public string SenderId { get; set; }

        public string SenderProfileImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }

        public string DateReceivedToString => this.CreatedOn.ToLongDateString();

        public bool IsDateReceivedToday => this.CreatedOn.Date == DateTime.Today;
    }
}
