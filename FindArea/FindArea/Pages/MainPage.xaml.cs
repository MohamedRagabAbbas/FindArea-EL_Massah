using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FindArea.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            image.Source = ImageSource.FromResource("FindArea.Images.Surveyor.jpg");
            

        }
        protected override void OnAppearing()
        {
            DB.create_table();
            base.OnAppearing();
        }
        private async void NewProject_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewProjectPage() {Title="مشروع جديد" });
        }

        private async void Calculator_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Calculator() { Title = "الحاسبة" });
        }

        private async void Data_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SavedData() { Title = "مشروعاتي" });
        }
    }
}