using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using MachineMaintenance.ObjectModel;
using MachineMaintenance.Inspections;


namespace MachineMaintenance.Database
{
    public class LocalDatabase
    {
        SQLiteConnection database;
        static object locker = new object();

        public LocalDatabase() 
        {
            database = DependencyService.Get<ISQLite>().GetConnection();

            database.CreateTable<MachineSerialised>();
            database.CreateTable<InspectionSerialised>();
            database.CreateTable<Token>();
            database.CreateTable<User>();
        }

        public void storeMachine(MachineSerialised machine)
        {
            lock (locker)
            {
                 database.Insert(machine);
            }
        }

        public List<MachineSerialised> getMachines()
        {
            lock (locker)
            {
                return (from i in database.Table<MachineSerialised>() select i).ToList();
            }
        }

        public MachineSerialised getMachine(string machine)
        {
            return database.Table<MachineSerialised>().FirstOrDefault(x => x.machine.Equals(machine));
        }

        public void deleteMachine(int id)
        {
            database.Delete<ObjectModel.Machine>(id);
        }

        public void storeInspection(Inspection inspection)
        {
            lock (locker)
            {
                if (database.Update(inspection) == 0)
                {
                    database.Insert(inspection);
                }

            }
        }

        public List<Inspection> getInspections()
        {
            return (from i in database.Table<Inspection>() select i).ToList();
        }

        public Inspection getInspection(int id)
        {
            return database.Table<Inspection>().FirstOrDefault(x => x.id == id);
        }

        public void storeToken(Token token)
        {
            lock (locker)
            {
                database.Insert(token);
            }
        }

        public List<Token> getToken()
        {
            lock (locker)
            {
                return (from i in database.Table<Token>() select i).ToList();
            }
        }

        public void storeUser(User user)
        {
            lock (locker)
            {
                database.Insert(user);
            }
        }
        
        public void deleteUser(User user)
        {
            lock (locker)
            {
                database.Delete<User>(user);
            }
        }

        public List<User> getUser()
        {
            lock (locker)
            {
                return (from i in database.Table<User>() select i).ToList();
            }
        }

    }
}
