using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("ArefRuqaa-Regular.ttf", Alias ="font1")]
[assembly: ExportFont("NotoNastaliqUrdu-Regular.ttf", Alias = "font2")]
[assembly: ExportFont("Amiri-Bold.ttf", Alias ="font3")]
[assembly: ExportFont("Amiri-BoldItalic.ttf", Alias ="font31")]
[assembly: ExportFont("Amiri-Italic.ttf", Alias ="font32")]
[assembly: ExportFont("Amiri-Regular.ttf", Alias ="font33")]
[assembly: ExportFont("Oswald-VariableFont_wght.ttf", Alias ="number1")]
[assembly: ExportFont("KdamThmorPro-Regular.ttf", Alias ="number2")]
namespace FindArea
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Pages.MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
