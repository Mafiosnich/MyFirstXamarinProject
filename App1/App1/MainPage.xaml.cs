using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public static Entry[] Inputs = new Entry[]
        {
            new Entry()
            {
                Placeholder = "Введите коэфицент a",
                PlaceholderColor = Color.FromHex("#BEBEBE"),
                BackgroundColor = Color.FromHex("#282828"),
                TextColor = Color.FromHex("#DCDCDC"),
                FontSize = 20,
                Margin = new Thickness(20, 0, 20, 10),
                HorizontalOptions = LayoutOptions.Fill,
                Keyboard = Keyboard.Numeric,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing
            },

            new Entry()
            {
                Placeholder = "Введите коэфицент b",
                PlaceholderColor = Color.FromHex("#BEBEBE"),
                BackgroundColor = Color.FromHex("#282828"),
                TextColor = Color.FromHex("#DCDCDC"),
                FontSize = 20,
                Margin = new Thickness(20, 0, 20, 10),
                HorizontalOptions = LayoutOptions.Fill,
                Keyboard = Keyboard.Numeric,
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing
            },

            new Entry()
            {
                Placeholder = "Введите коэфицент c",
                PlaceholderColor = Color.FromHex("#BEBEBE"),
                BackgroundColor = Color.FromHex("#282828"),
                TextColor = Color.FromHex("#DCDCDC"),
                FontSize = 20,
                Margin = new Thickness(20, 0, 20, 10),
                HorizontalOptions = LayoutOptions.Fill,
                Keyboard = Keyboard.Numeric,
                
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing
            }
        };

        private void PrintError()
        {
            for (int i = 0; i < Inputs.Length; i++)
            {
                if (string.IsNullOrEmpty(Inputs[i].Text))
                {
                    Inputs[i].Text = null;
                    Inputs[i].PlaceholderColor = Color.Red;
                    Inputs[i].Placeholder = "Обязательное поле";
                }

                else if (Inputs[i].Text[0] == '0')
                {
                    Inputs[i].Text = null;
                    Inputs[i].PlaceholderColor = Color.Red;
                    Inputs[i].Placeholder = "Некоректные данные";
                }
            }
        }
        
        private async void ResultButtonClicked(object sender, EventArgs e)
        {
            

            bool hasInvalid = Inputs.Any(input => string.IsNullOrEmpty(input.Text) || input.Text[0] == '0');

            if (hasInvalid)
            {
                PrintError();
                return;
            }

            await Navigation.PushAsync(new ResultPage
            {
                Coeficents = Inputs
            });
        }
        protected override void OnAppearing()
        {
            StackLayout multipliers = new StackLayout()
            {
                BackgroundColor = Color.FromHex("#282828")
            };

            Label[] Labels = new Label[]
            {
                new Label()
                {
                    Text = "Коэфицент a:",
                    TextColor = Color.FromHex("#DCDCDC"),
                    FontSize = 25,
                    Margin = new Thickness (22, 30, 20, 5),
                    HorizontalOptions = LayoutOptions.Fill
                },

                new Label()
                {
                    Text = "Коэфицент b:",
                    TextColor = Color.FromHex("#DCDCDC"),
                    FontSize = 25,
                    Margin = new Thickness(22, 30, 20, 5),
                    HorizontalOptions = LayoutOptions.Fill
                },

                new Label()
                {
                    Text = "Коэфицент c:",
                    TextColor = Color.FromHex("#DCDCDC"),
                    FontSize = 25,
                    Margin = new Thickness(22, 30, 20, 5),
                    HorizontalOptions = LayoutOptions.Fill
                }
            };

            

            for (int i = 0 ; i < Labels.Length && i < Inputs.Length; i++)
            {
                multipliers.Children.Add(Labels[i]);
                multipliers.Children.Add(Inputs[i]);
            }

            Button ResultButton = new Button()
            {
                HorizontalOptions = LayoutOptions.Fill,
                Text = "Вычислить",
                TextColor = Color.FromHex("#DCDCDC"),
                BackgroundColor = Color.FromHex("#484848"),
                Margin = new Thickness(20, 0, 20, 0),
                FontSize = 15
            };

            ResultButton.Clicked += ResultButtonClicked;

            multipliers.Children.Add(ResultButton);

            Content = multipliers;
        }
    }
}
