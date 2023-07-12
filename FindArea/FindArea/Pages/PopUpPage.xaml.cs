using FindArea.Model;
using Plugin.Media;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
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
    public partial class PopUpPage : PopupPage
    {
        public PopUpPage( string name , string date ,string path)
        {
            InitializeComponent();
            lable.Text = name;
            lable2.Text = date;
            iamge.Source = ImageSource.FromFile(path);


        }
        private void close_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.PopAsync();
        }
    }
}