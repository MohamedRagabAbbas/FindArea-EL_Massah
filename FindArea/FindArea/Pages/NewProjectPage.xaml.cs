using FindArea.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Globalization;

namespace FindArea.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewProjectPage : ContentPage
    {
        int test = -1;
        string Image_Path;
        public NewProjectPage()
        {
            InitializeComponent();
        }
        private void compute_Clicked(object sender, EventArgs e)
        {
            L_D1.Text = findArea(Convert.ToDouble(E_1_1.Text), Convert.ToDouble(E_1_2.Text), Convert.ToDouble(E_1_3.Text)).ToString();
            L_D2.Text = findArea(Convert.ToDouble(E_2_1.Text), Convert.ToDouble(E_2_2.Text), Convert.ToDouble(E_2_3.Text)).ToString();
            L_D3.Text = findArea(Convert.ToDouble(E_3_1.Text), Convert.ToDouble(E_3_2.Text), Convert.ToDouble(E_3_3.Text)).ToString();
            L_D4.Text = findArea(Convert.ToDouble(E_4_1.Text), Convert.ToDouble(E_4_2.Text), Convert.ToDouble(E_4_3.Text)).ToString();
            L_D5.Text = findArea(Convert.ToDouble(E_5_1.Text), Convert.ToDouble(E_5_2.Text), Convert.ToDouble(E_5_3.Text)).ToString(); 
            SL1.Text = findArea2(Convert.ToDouble(E_6_1.Text), Convert.ToDouble(E_6_2.Text), Convert.ToDouble(E_6_3.Text), Convert.ToDouble(E_6_4.Text)).ToString();
            SL2.Text = findArea2(Convert.ToDouble(E_7_1.Text), Convert.ToDouble(E_7_2.Text), Convert.ToDouble(E_7_3.Text), Convert.ToDouble(E_7_4.Text)).ToString();
            L_D6.Text = (Convert.ToDouble(L_D1.Text) + Convert.ToDouble(L_D2.Text) + Convert.ToDouble(L_D3.Text) + Convert.ToDouble(L_D4.Text) + Convert.ToDouble(L_D5.Text)+ Convert.ToDouble(SL1.Text)+ Convert.ToDouble(SL2.Text)).ToString();
        }
        private double findArea(double x, double y, double z)
        {
            if (x == 0 | y == 0 | z == 0)
                return 0;
            double d = (x + y + z) / 2.0;
            return Math.Sqrt(d * Math.Abs(d - z) * Math.Abs(d - y) * Math.Abs(d - x));
        }

        private double findArea2(double x, double y, double z, double s)
        {
            if (x == 0 | y == 0 | z == 0 | s == 0) 
                return 0;
            double d1 = (x + z) / 2.0;
            double d2 = (y + s) / 2.0;
            return (d1 * d2);
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            int flag = 0;
            if(string.IsNullOrEmpty(L_D6.Text) | L_D6.Text=="المساحة الكلية")
            {
                flag = 1;
                await DisplayAlert("تحزير", "لم تتم حساب المساحة الكلية", "حسناً");
            }
            else if(test==-1)
            {
                flag = 1;
                await DisplayAlert("تحزير", " لم تتم إلتقاط الصورة", "حسناً");
            }
            else if (string.IsNullOrEmpty(owner_name.Text))
            {
                flag = 1;
                await DisplayAlert("تحزير", "ادخل اسم صاحب الارض", "حسناً");
            }
            if (flag==1)
            {
                await DisplayAlert("تحزير", "لم يتم حفظ البيانات من فضلك اعد المحاولة", "حسناً");
                return;
            }
            DB.Add(new Project() { Name = owner_name.Text, Date = (GetNow()).ToString("dd:MM:yyyy"), ImagePath = Image_Path, TotalArea= Math.Round(Convert.ToDouble(L_D6.Text),4).ToString() });
            await DisplayAlert("تحزير", "تم حفظ البيانات بشكل ناجح", "حسناً");
            Save.IsEnabled = false;
        }

        private static DateTime GetNow()
        {
            return DateTime.Now;
        }

        private async void PickPhoto_Clicked(object sender, EventArgs e)
        {
            var cross_media = CrossMedia.Current;
            if (cross_media.IsCameraAvailable && cross_media.IsTakePhotoSupported)
            {
                var file = await cross_media.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions { Name = owner_name.Text + GetNow().ToString("dd:MM:yyyy") + ".jpg", Directory = "Pictures" });
                await DisplayAlert("", "تم التقاط الصورة بنجاح", "حسنا");
                if (file == null)
                    return;
                test = 0;
                Image_Path = file.Path;
                I_photo.Source = ImageSource.FromFile(file.Path);
            }
            else
            {
                test = 1;
                await DisplayAlert("تحزير", "الكاميرا ليست متاحة", "حسنا");
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Calculator());
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SavedData());
        }
    }
}

