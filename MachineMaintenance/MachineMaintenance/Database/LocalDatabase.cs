using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using MachineMaintenance.ObjectModel;
using MachineMaintenance.Inspections;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Extensions;

namespace MachineMaintenance.Database
{
    public class LocalDatabase
    {
        SQLiteConnection database;
        static object locker = new object();

        public LocalDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();

            database.CreateTable<ObjectModel.MachineSerialised>();
            database.CreateTable<Inspections.InspectionSerialised>();
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
    }
}
