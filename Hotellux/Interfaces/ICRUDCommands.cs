using System.Windows.Input;

namespace Hotellux.Interfaces
{
    public interface ICRUDCommands
    {
        public ICommand Save { get; set; }

        public ICommand Delete { get; set; }
    }
}
