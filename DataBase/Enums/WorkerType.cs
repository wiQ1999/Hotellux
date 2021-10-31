using System.ComponentModel;

namespace DataBase.Enums
{
    public enum WorkerType
    {
        [Description("Kierownik")]
        Manager,
        [Description("Recepcja")]
        Reception,
        [Description("Obsługa sprzątająca")]
        CleaningService
    }
}
