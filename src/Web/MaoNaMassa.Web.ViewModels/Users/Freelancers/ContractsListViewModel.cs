﻿namespace MaoNaMassa.Web.ViewModels.Users.Freelancers
{
    using System;

    using MaoNaMassa.Common;
    using MaoNaMassa.Data.Models;
    using MaoNaMassa.Services.Mapping;

    public class ContractsListViewModel : IMapFrom<Contract>
    {
        public ContractStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedOnFormatted
            => this.CreatedOn.ToShortDateString();

        public DateTime CompletedOn { get; set; }

        public string CompletedOnFormatted
            => this.CompletedOn > DateTime.MinValue ? this.CompletedOn.ToShortDateString() : "Presente";

        public string JobTitle { get; set; }

        public string JobDescription { get; set; }

        public string EmployerId { get; set; }

        public string EmployerProfileImageUrl { get; set; }

        public string EmployerFirstName { get; set; }

        public string EmployerLastName { get; set; }
    }
}
