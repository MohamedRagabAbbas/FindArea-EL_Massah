using App21;
using FindArea.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FindArea.Pages
{
    class DB 
    {
        public static SQLiteAsyncConnection _connection = DependencyService.Get<DataBase>().GetConnection();
        public static ObservableCollection<Project> project = new ObservableCollection<Project>();

        public static List<Project> Project { get; private set; }

        public static async void create_table()
        {
            await _connection.CreateTableAsync<Project>();
        }

        public async static void Add(Project p)
        {
            project.Add(p);
            await _connection.InsertAsync(p);

        }
        public async static void Delete(Project p)
        {
            project.Remove(p);
            await _connection.DeleteAsync(p);

        }
        public static ObservableCollection<Project> GetAllDate()
        {
            return project;
        }
    }
}
