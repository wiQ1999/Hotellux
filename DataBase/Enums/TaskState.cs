using System.ComponentModel;

namespace DataBase.Enums
{
    public enum TaskState
    {
        [Description("Zakończony")]
        Complited,
        [Description("Realizowany")]
        Realized,
        [Description("Nowy")]
        New,
        [Description("Anulowany")]
        Cancelled,
    }
}
