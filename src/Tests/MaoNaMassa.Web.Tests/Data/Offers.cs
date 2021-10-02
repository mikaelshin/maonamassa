namespace MaoNaMassa.Web.Tests.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using MaoNaMassa.Data.Models;

    public static class Offers
    {
        public static IEnumerable<Offer> TwoOffers
            => Enumerable.Range(0, 2).Select(x => new Offer());
    }
}
