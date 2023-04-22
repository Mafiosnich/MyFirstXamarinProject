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
                BackgroundColor = Color.FromHex("#282828")
            };

            double a = Convert.ToDouble(Coeficents[0].Text);
            double b = Convert.ToDouble(Coeficents[1].Text);
            double c = Convert.ToDouble(Coeficents[2].Text);
            double discriminant = Math.Pow(b, 2) - 4 * a * c;

            Label DiscriminantBanner = new Label()
            {
                Text = "Дискриминант:",
                TextColor = Color.FromHex("#DCDCDC"),
                FontSize = 30,
                Margin = new Thickness(22, 30, 22, 5),
                HorizontalOptions = LayoutOptions.Fill
            };
            // {b}^2 - 4 * {a} * {c} = {discriminant}

            Label Discriminant = new Label()
            {
                Text = $"{b}^2 - 4 * {a} * {c} = {discriminant}",
                TextColor = Color.FromHex("#DCDCDC"),
                FontSize = 30,
                Margin = new Thickness(22, 5, 22, 10),
                HorizontalOptions = LayoutOptions.Fill
            };

            Results.Children.Add(DiscriminantBanner);
            Results.Children.Add(Discriminant);

            Label NoEquationRoots = new Label()
            {
                Text = "Нет корней уравнения",
                TextColor = Color.FromHex("#DCDCDC"),
                FontSize = 30,
                Margin = new Thickness(22, 20, 20, 5),
                HorizontalOptions = LayoutOptions.Fill
            };

            Label OneEquationRoot = new Label()
            {
                Text = $"x = {-b} / 2 * {a} = {-b / (2 * a)}",
                TextColor = Color.FromHex("#DCDCDC"),
                FontSize = 30,
                Margin = new Thickness(22, 10, 22, 5),
                HorizontalOptions = LayoutOptions.Fill
            };

            Label FirstEquationRoot = new Label()
            {
                Text = $"x1 = {-b} + √{discriminant} / 2 * {a} = {(-b + Math.Sqrt(discriminant)) / (2 * a)}\n",
                TextColor = Color.FromHex("#DCDCDC"),
                FontSize = 30,
                Margin = new Thickness(22, 20, 22, 0),
                HorizontalOptions = LayoutOptions.Fill
            };

            Label SecondEquationRoot = new Label()
            {
                Text = $"x2 = {-b} - √{discriminant} / 2 * {a} = {(-b - Math.Sqrt(discriminant)) / (2 * a)}",
                TextColor = Color.FromHex("#DCDCDC"),
                FontSize = 30,
                Margin = new Thickness(22, -25, 22, 5),
                HorizontalOptions = LayoutOptions.Fill
            };

            if (discriminant < 0)
            {
                Discriminant.Text += " < 0";
                Results.Children.Add(NoEquationRoots);
            }

            if (discriminant == 0)
            {
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