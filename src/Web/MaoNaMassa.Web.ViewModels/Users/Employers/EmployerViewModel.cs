﻿namespace MaoNaMassa.Web.ViewModels.Users.Employers
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;
    using MaoNaMassa.Common;
    using MaoNaMassa.Data.Models;
    using MaoNaMassa.Services.Mapping;

    public class EmployerViewModel : BaseUserViewModel, IMapFrom<Employer>, IHaveCustomMappings
    {
        public List<OpenJobsListViewModel> OpenJobs { get; set; } = new List<OpenJobsListViewModel>();

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Employer, EmployerViewModel>()
                .ForMember(x => x.OpenJobs, options => options
                .MapFrom(e => e.Jobs.Where(x => x.Status == JobStatus.Open)));
        }
    }
}
