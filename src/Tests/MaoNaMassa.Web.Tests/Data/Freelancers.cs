namespace MaoNaMassa.Web.Tests.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using MaoNaMassa.Data.Models;

    public static class Freelancers
    {
        public static IEnumerable<Freelancer> ThreeFreelancers
            => Enumerable.Range(0, 3).Select(x => new Freelancer());
    }
}
