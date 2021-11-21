using System.ComponentModel;

namespace Hotellux.Enums
{
    public enum WorkerActivityFilter
    {
        [Description("Aktywni")]
        Active,
        [Description("Nie aktywni")]
        NonActive,
        [Description("Wszyscy")]
        All
    }
}
