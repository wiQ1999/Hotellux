using System.ComponentModel;

namespace DataBase.Enums
{
    public enum State
    {
        [Description("Zakończony")]
        a,
        [Description("W realizacji")]
        b,
        [Description("Nowy")]
        c,
        [Description("Anulowany")]
        d,
    }
}
