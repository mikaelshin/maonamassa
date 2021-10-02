﻿namespace MaoNaMassa.Web.ViewModels.Home
{
    using System.Collections.Generic;

    using MaoNaMassa.Web.ViewModels.Jobs;
    using MaoNaMassa.Web.ViewModels.Users.Freelancers;

    public class HomeViewModel
    {
        public int JobsCount { get; set; }

        public int OffersCount { get; set; }

        public int FreelancersCount { get; set; }

        public IEnumerable<FreelancerViewModel> Freelancers { get; set; }

        public IEnumerable<AllJobsListViewModel> Jobs { get; set; }
    }
}
