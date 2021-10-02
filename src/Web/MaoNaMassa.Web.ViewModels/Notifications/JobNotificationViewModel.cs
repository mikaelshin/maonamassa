namespace MaoNaMassa.Web.ViewModels.Notifications
{
    using MaoNaMassa.Data.Models;
    using MaoNaMassa.Services.Mapping;

    public class JobNotificationViewModel : IMapFrom<Job>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string EmployerId { get; set; }
    }
}
