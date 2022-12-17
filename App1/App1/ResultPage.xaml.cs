using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        public Entry[] Coeficents = new Entry[3];

        public ResultPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Title = "Результаты";

            StackLayout Results = new StackLayout()
            {
                BackgroundColor = Color.White
            };

            double a = Convert.ToDouble(Coeficents[0].Text);
            double b = Convert.ToDouble(Coeficents[1].Text);
            double c = Convert.ToDouble(Coeficents[2].Text);
            double discriminant = Math.Pow(b, 2) - 4 * a * c;

            Label Discriminant = new Label()
            {
                Text = $"Дискриминант: {discriminant}",
                TextColor = Color.Black,
                FontSize = 30,
                Margin = new Thickness(22, 35, 20, 10),
                HorizontalOptions = LayoutOptions.Fill
            };
            Results.Children.Add(Discriminant);

            Label NoEquationRoots = new Label()
            {
                Text = "Нет корней уравнения",
                TextColor = Color.Black,
                FontSize = 30,
                Margin = new Thickness(22, 20, 20, 5),
                HorizontalOptions = LayoutOptions.Fill
            };

            Label OneEquationRoot = new Label()
            {
                Text = $"x = {-b / (2 * a)}",
                TextColor = Color.Black,
                FontSize = 30,
                Margin = new Thickness(22, 10, 20, 5),
                HorizontalOptions = LayoutOptions.Fill
            };

            Label FirstEquationRoot = new Label()
            {
                Text = $"x1 = {(-b + Math.Sqrt(discriminant)) / (2 * a)}\n",
                TextColor = Color.Black,
                FontSize = 30,
                Margin = new Thickness(22, 20, 20, 0),
                HorizontalOptions = LayoutOptions.Fill
            };

            Label SecondEquationRoot = new Label()
            {
                Text = $"x2 = {(-b - Math.Sqrt(discriminant)) / (2 * a)}",
                TextColor = Color.Black,
                FontSize = 30,
                Margin = new Thickness(22, -25, 20, 5),
                HorizontalOptions = LayoutOptions.Fill
            };

            if (discriminant < 0)
            {
                Discriminant.Text += " < 0";
                Results.Children.Add(NoEquationRoots);
            }
            if (discriminant == 0)
            {
                Discriminant.Text += " = 0";
                Results.Children.Add(OneEquationRoot);
            }
            if (discriminant > 0)
            {
                Discriminant.Text += " > 0";
                Results.Children.Add(FirstEquationRoot);
                Results.Children.Add(SecondEquationRoot);
            }

            Content = Results;
        }
    }
}