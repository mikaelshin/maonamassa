namespace MaoNaMassa.Web.ViewModels.Jobs
{
    using MaoNaMassa.Data.Models;
    using MaoNaMassa.Services.Mapping;

    public class CategoriesListViewModel : IMapFrom<Category>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
