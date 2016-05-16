using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;

namespace MachineMaintenance.Database
{
    public class TodoItemDatabase
    {
        SQLiteConnection database;
        static object locker = new object();

        public TodoItemDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<ObjectModel.Machine>();
            database.CreateTable<Inspections.Inspection>();
            database.CreateTable<ObjectModel.Token>();
        }

        public void storeMachine(ObjectModel.Machine machine)
        {
            lock (locker)
            {
                if (database.Update(machine) == 0)
                {
                    database.Insert(machine);
                }
     
            }
        }

        public List<ObjectModel.Machine> getMachines()
        {
            return (from i in database.Table<ObjectModel.Machine>() select i).ToList();
        }

        public ObjectModel.Machine getMachine(int id)
        {
            return database.Table<ObjectModel.Machine>().FirstOrDefault(x => x.id == id);
        }

        public void deleteMachine(int id)
        {
            database.Delete<ObjectModel.Machine>(id);
        }

        public void storeInspection(Inspections.Inspection inspection)
        {
            lock (locker)
            {
                if (database.Update(inspection) == 0)
                {
                    database.Insert(inspection);
                }

            }
        }

        public List<Inspections.Inspection> getInspections()
        {
            return (from i in database.Table<Inspections.Inspection>() select i).ToList();
        }

        public Inspections.Inspection getInspection(int id)
        {
            return database.Table<Inspections.Inspection>().FirstOrDefault(x => x.id == id);
        }
    }
}
