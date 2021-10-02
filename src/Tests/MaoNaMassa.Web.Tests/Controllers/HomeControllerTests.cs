namespace MaoNaMassa.Web.Tests.Controllers
{
    using System.Linq;

    using MaoNaMassa.Services.Interfaces;
    using MaoNaMassa.Web.Controllers;
    using MaoNaMassa.Web.ViewModels.Administration.Dashboard;
    using MaoNaMassa.Web.ViewModels.Home;
    using MyTested.AspNetCore.Mvc;
    using Xunit;

    using static MaoNaMassa.Web.Tests.Data.Employers;
    using static MaoNaMassa.Web.Tests.Data.Freelancers;
    using static MaoNaMassa.Web.Tests.Data.Jobs;
    using static MaoNaMassa.Web.Tests.Data.Offers;

    public class HomeControllerTests
    {
        // Testing if MyTested library works correctly
        [Fact]
        public void PrivacyShouldReturnView()
            => MyController<HomeController>
                .Instance()
                .Calling(c => c.Privacy())
                .ShouldReturn()
                .View();

        [Fact]
        public void IndexShouldReturnPublicViewIfUserIsNotAuthenticated()
            => MyController<HomeController>
                .Instance(
                    controller => controller
                        .WithDependencies(
                            From.Services<IFreelancePlatform>())
                        .WithData(FiveJobs)
                        .AndAlso()
                        .WithData(ThreeFreelancers)
                        .AndAlso()
                        .WithData(TwoOffers))
                .Calling(x => x.Index())
                .ShouldReturn()
                .View(
                    view => view
                        .WithModelOfType<HomeViewModel>()
                        .Passing(
                            model =>
                                model.JobsCount == 5 &&
                                model.FreelancersCount == 43 &&
                                model.OffersCount == 66));

        [Fact]
        public void IndexShouldReturnRedirectIfUserIsAdmin()
            => MyController<HomeController>
                .Instance(
                    controller => controller
                        .WithDependencies(
                            From.Services<IFreelancePlatform>())
                        .WithUser(
                            user => user
                                .WithUsername("tonsan1")
                                .InRole("Administrator")))
                .Calling(x => x.Index())
                .ShouldReturn()
                .RedirectToAction("Index", "Dashboard", new { area = "Administration" });

        [Fact]
        public void IndexShouldReturnCorrectViewIfUserIsEmployer()
            => MyController<HomeController>
                .Instance(
                    controller => controller
                        .WithDependencies(From.Services<IFreelancePlatform>())
                        .WithUser(
                            user => user
                                .WithUsername("tonsan1")
                                .InRole("Employer")))
                .Calling(x => x.Index())
                .ShouldReturn()
                .View(
                    view => view
                        .WithModelOfType<HomeViewModel>());

        [Fact]
        public void IndexShouldReturnCorrectViewIfUserIsFreelancer()
            => MyController<HomeController>
                .Instance(controller => controller
                    .WithDependencies(
                        From.Services<IFreelancePlatform>())
                    .WithUser(user => user
                        .WithUsername("tonsan1")
                        .InRole("Freelancer")))
                .Calling(x => x.Index())
                .ShouldReturn()
                .View(view => view
                    .WithModelOfType<HomeViewModel>()
                    .Passing(model =>
                        model.Jobs.Any(x =>
                            x.Id == "123" &&
                            x.Title == "Test" &&
                            x.EmployerFirstName == "Vanko" &&
                            x.EmployerLastName == "Edno")));
    }
}
