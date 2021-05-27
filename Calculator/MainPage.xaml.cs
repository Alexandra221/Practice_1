using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void Submit_Clicked(object sender, EventArgs e)
        {
            try
            {
                double first = Convert.ToDouble(First.Text);
                double result = first * 1.76;
                Page1 secondpage = new Page1();
                Navigation.PushAsync(secondpage);
                secondpage.Calculator(result);
            }
            catch (FormatException)
            {
                DisplayAlert("Ошибка", "Введите числовые данные", "Ввести заново");

            }


        }
    }

}
