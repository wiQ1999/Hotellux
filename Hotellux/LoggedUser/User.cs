using DataBase.DataModels;
using System;

namespace Hotellux.LoggedUser
{
    public sealed class User
    {
        private static User _instance;
        private WorkerDataModel _workerModel;

        public static User Get
        {
            get
            {
                if (_instance == null)
                    throw new Exception("Missing initialization.");
                return _instance;
            }
        }

        public int Id => _workerModel.Id;

        public string Name => _workerModel.Name;

        public string Lastname => _workerModel.Lastname;

        public string FullName => $"{Name} {Lastname}";

        private User(WorkerDataModel worker)
        {
            _workerModel = worker;
        }

        public static bool Initialize(WorkerDataModel worker)
        {
            if (IsInitialized())
                return false;
            _instance = new User(worker);
            return true;
        }

        public static bool IsInitialized() => _instance != null;
    }
}
