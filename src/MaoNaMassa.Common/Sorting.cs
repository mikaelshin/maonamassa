using System.ComponentModel;

namespace MaoNaMassa.Common
{
    public enum Sorting
    {
        [Description("Mais Recentes")]
        Newest = 1,
        [Description("Mais Antigos")]
        Oldest = 2,
        [Description("Aleatório")]
        Random = 4,
    }
}
