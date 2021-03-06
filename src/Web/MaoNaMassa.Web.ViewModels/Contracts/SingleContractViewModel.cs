namespace MaoNaMassa.Web.ViewModels.Contracts
{
    using System;
    using System.Collections.Generic;

    using MaoNaMassa.Common;
    using MaoNaMassa.Data.Models;
    using MaoNaMassa.Services.Mapping;

    public class SingleContractViewModel : IMapFrom<Contract>
    {
        public string Id { get; set; }

        public ContractStatus Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public string OfferId { get; set; }

        public string OfferJobId { get; set; }

        public string OfferJobTitle { get; set; }

        public string OfferJobDescription { get; set; }

        public int OfferFixedPrice { get; set; }

        public int OfferDeliveryDays { get; set; } = 1;

        public string EmployerId { get; set; }

        public string EmployerFirstName { get; set; }

        public string EmployerLastName { get; set; }

        public string FreelancerId { get; set; }

        public string FreelancerFirstName { get; set; }

        public string FreelancerLastName { get; set; }

        public string StatusToString => this.Status.ToString();

        public DateTime ContractDeadline
            => this.StatusToString == "Ongoing" ?
            this.CreatedOn.AddDays(this.OfferDeliveryDays).ToLocalTime() : DateTime.MinValue;

        public int TimeLeft
            => this.ContractDeadline.Subtract(DateTime.Now).Days;

        public string StatusColor => this.StatusToString == "Finished" ? "bg-secondary text-white" :
                                     this.StatusToString == "Ongoing" && this.TimeLeft <= 0 ? "bg-warning text-white" :
                                     this.StatusToString == "Canceled" ? "bg-danger text-white" : string.Empty;

        public string StatusName => this.StatusToString == "Ongoing" && this.TimeLeft > 0 ? "Em andamento" :
                                    this.StatusToString == "Ongoing" && this.TimeLeft < 0 ? "Expirado" :
                                    this.StatusToString == "Canceled" ? "Cancelado" : "Finalizado";

        public List<AttachmentListViewModel> Attachments { get; set; }
    }
}
