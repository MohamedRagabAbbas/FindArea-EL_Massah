using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FindArea.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Calculator : ContentPage
    {
        Stack<string> last = new Stack<string>();
        public bool is_equal = false;
        public Calculator()
        {
            InitializeComponent();
        }
        private void B_reset_Clicked(object sender, EventArgs e)
        {
            E_input.Text = "";
            is_equal = false;
        }

        private void B_division_Clicked(object sender, EventArgs e)
        {
            E_input.Text += " / ";
            is_equal = false;

        }

        private void B_multiplication_Clicked(object sender, EventArgs e)
        {
            E_input.Text += " * ";
            is_equal = false;

        }

        private void B_minus_Clicked(object sender, EventArgs e)
        {
            E_input.Text += " - ";
            is_equal = false;

        }

        private void B_number7_Clicked(object sender, EventArgs e)
        {
            if (is_equal)
                E_input.Text = "";
            E_input.Text += '7';
            is_equal = false;

        }

        private void B_number8_Clicked(object sender, EventArgs e)
        {
            if (is_equal)
                E_input.Text = "";
            E_input.Text += '8';
            is_equal = false;

        }

        private void B_number9_Clicked(object sender, EventArgs e)
        {
            if (is_equal)
                E_input.Text = "";
            E_input.Text += '9';
            is_equal = false;

        }

        private void B_plus_Clicked(object sender, EventArgs e)
        {
            E_input.Text += " + ";
            is_equal = false;

        }

        private void B_number4_Clicked(object sender, EventArgs e)
        {
            if (is_equal)
                E_input.Text = "";
            E_input.Text += '4';
            is_equal = false;

        }

        private void B_number5_Clicked(object sender, EventArgs e)
        {
            if (is_equal)
                E_input.Text = "";
            E_input.Text += '5';
            is_equal = false;

        }

        private void B_number6_Clicked(object sender, EventArgs e)
        {
            if (is_equal)
                E_input.Text = "";
            E_input.Text += '6';
            is_equal = false;

        }

        private void B_number1_Clicked(object sender, EventArgs e)
        {
            if (is_equal)
                E_input.Text = "";
            E_input.Text += '1';
            is_equal = false;

        }

        private void B_number2_Clicked(object sender, EventArgs e)
        {
            if (is_equal)
                E_input.Text = "";
            E_input.Text += '2';
            is_equal = false;

        }

        private void B_number3_Clicked(object sender, EventArgs e)
        {
            if (is_equal)
                E_input.Text = "";
            E_input.Text += '3';
            is_equal = false;

        }

        private void B_equal_Clicked(object sender, EventArgs e)
        {
            if (E_input.Text == null)
                return;
            if (!validation(E_input.Text))
                return;
            string expression = E_input.Text;
            DataTable dt = new DataTable();
            var v = dt.Compute(expression, "");
            E_input.Text = v.ToString();
            is_equal = true;
            last.Push(E_input.Text.ToString());
        }

        private void B_number0_Clicked(object sender, EventArgs e)
        {
            if (is_equal)
                E_input.Text = "";
            E_input.Text += '0';
            is_equal = false;

        }

        private void B_dot_Clicked(object sender, EventArgs e)
        {
            if (is_equal)
                E_input.Text = "";
            E_input.Text += '.';
            is_equal = false;

        }

        private void B_back_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(E_input.Text))
                return;
            if (string.IsNullOrWhiteSpace(E_input.Text[E_input.Text.Length - 1].ToString()))
            {
                E_input.Text = E_input.Text.Remove(E_input.Text.Length - 1);
                last.Push(E_input.Text);
                if (E_input.Text == null)
                    return;
                E_input.Text = E_input.Text.Remove(E_input.Text.Length - 1);
                last.Push(E_input.Text);
                if (E_input.Text == null)
                    return;
            }
            E_input.Text = E_input.Text.Remove(E_input.Text.Length - 1);
            last.Push(E_input.Text);

        }

        private void B_rownd_Clicked(object sender, EventArgs e)
        {
            if (E_input.Text == null)
                return;
            if (!validation(E_input.Text))
                return;
            string expression = E_input.Text;
            DataTable dt = new DataTable();
            var v = dt.Compute(expression, "");
            E_input.Text = (Math.Round(Convert.ToDouble(v.ToString()), 3)).ToString();
            is_equal = true;
            last.Push(E_input.Text);
        }

        private void B_last_Clicked(object sender, EventArgs e)
        {
            if (last.Count == 0)
                return;
            E_input.Text = last.Peek();
            last.Pop();
            is_equal = true;
        }

        private void B_squar_Clicked(object sender, EventArgs e)
        {
            if (E_input.Text == null)
                return;
            if (!validation(E_input.Text))
                return;
            string expression = E_input.Text;
            DataTable dt = new DataTable();
            var v = dt.Compute(expression, "");
            E_input.Text = Math.Pow(Convert.ToDouble(v.ToString()), 2).ToString();
            is_equal = true;
            last.Push(E_input.Text);
        }

        private void B_root_Clicked(object sender, EventArgs e)
        {
            if (E_input.Text == null)
                return;
            if (!validation(E_input.Text))
                return;
            string expression = E_input.Text;
            DataTable dt = new DataTable();
            var v = dt.Compute(expression, "");
            E_input.Text = Math.Sqrt(Convert.ToDouble(v.ToString())).ToString();
            is_equal = true;
            last.Push(E_input.Text);
        }

        private void B_left_par_Clicked(object sender, EventArgs e)
        {
            if (is_equal)
                E_input.Text = "";
            E_input.Text += " ( ";
            is_equal = false;
        }

        private void B_right_par_Clicked(object sender, EventArgs e)
        {
            if (is_equal)
                E_input.Text = "";
            E_input.Text += " ) ";
            is_equal = false;
        }
        private bool validation(string expression)
        {
             if (E_input.Text == null)
                return false;
            else if (expression[expression.Length - 1] == '-' | expression[expression.Length - 1] == '+' | expression[expression.Length - 1] == '*' | expression[expression.Length - 1] == '/')
                return false;
            else if (expression.IndexOf(')') == -1 && expression.IndexOf('(') != -1)
                return false;
            else if (expression.IndexOf('(') == -1 && expression.IndexOf(')') != -1)
                return false;
            else if (expression.IndexOf('(') > expression.IndexOf(')'))
                return false;

            return true;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewProjectPage());
        }

        private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SavedData());
        }
    }
}