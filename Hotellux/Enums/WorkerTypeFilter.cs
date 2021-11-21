using System.ComponentModel;

namespace Hotellux.Enums
{
    public enum WorkerTypeFilter
    {
        [Description("Kierownik")]
        Manager,
        [Description("Recepcja")]
        Reception,
        [Description("Obsługa sprzątająca")]
        CleaningService,
        [Description("Wszystkie")]
        All
    }
}
