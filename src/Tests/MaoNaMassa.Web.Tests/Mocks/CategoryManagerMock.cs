namespace MaoNaMassa.Web.Tests.Mocks
{
    using System.Collections.Generic;

    using MaoNaMassa.Services.Interfaces;
    using MaoNaMassa.Web.ViewModels.Jobs;
    using Moq;

    public class CategoryManagerMock
    {
        public static ICategoryManager Instance
        {
            get
            {
                var categoryManagerMock = new Mock<ICategoryManager>();

                categoryManagerMock.Setup(
                        x =>
                            x.GetAllJobCategoriesAsync<CategoriesListViewModel>())
                    .ReturnsAsync(
                        new List<CategoriesListViewModel>()
                        {
                            new CategoriesListViewModel()
                            {
                                Id = "Test",
                                Name = "TestCategory",
                            },
                        });

                return categoryManagerMock.Object;
            }
        }
    }
}
