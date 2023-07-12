using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindArea.Model;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FindArea.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SavedData : ContentPage
    {

        public SavedData()
        {
            InitializeComponent();
            BindingContext = new Project();
            listview.ItemsSource = DB.GetAllDate();
        }
        protected override async void OnAppearing()
        {
            var list = await DB._connection.Table<Project>().ToListAsync();
            listview.ItemsSource = list;
            base.OnAppearing();
        }

        private async void listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await PopupNavigation.PushAsync(new PopUpPage(((listview.SelectedItem)as Project).Name, ((listview.SelectedItem) as Project).Date, ((listview.SelectedItem) as Project).ImagePath));
        }
        [Obsolete]
        private async void Delete_Clicked(object sender, EventArgs e)
        {
             DB.Delete(((sender as MenuItem).CommandParameter) as Project);
            await DisplayAlert("تحزير", "تم مسح هذا المشروع", "حسنا");
            var list = await DB._connection.Table<Project>().ToListAsync();
            ObservableCollection<Project> myList = new ObservableCollection<Project>(list);
            listview.ItemsSource = list;
        }

        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(search.Text))
                OnAppearing();
            else
            {
                listview.ItemsSource = (await DB._connection.Table<Project>().ToListAsync()).Where(c => c.Name.StartsWith(e.NewTextValue)).ToList(); 
            }

        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Calculator());
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewProjectPage());

        }
    }
}