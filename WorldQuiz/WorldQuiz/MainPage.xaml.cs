using System;
using System.Collections.Generic;
using System.Linq;
using WorldQuiz.Models;
using WorldQuiz.Services;
using Xamarin.Forms;

namespace WorldQuiz
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        List<Country> countries = new List<Country>();
        protected override void OnAppearing()
        {
            base.OnAppearing();

            CountryService service = new CountryService();

            countries = service.GetNextPossibleAnswers();

            if (countries.Count == 0)
            {
                service.GetAllCountriesFromAPIAsync();
            }


            GenerateNewButtons(countries);

        }


        private void ValidateAnswers(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            btn.Text = "Italy";
            btn.TextColor = new Color(2, 3, 4, 4);
            DisplayAlert("teting", "das", "dasas");
        }


        private void GenerateNewButtons(List<Country> countries)
        {

            var mainStackLayout = new StackLayout()
            {
                Spacing = 50
            };
            var questionStackLayout = new StackLayout()
            {
                Spacing = 80,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            var topPossibleAnswersStackLayout = new StackLayout()
            {
                Spacing = 5,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center
            };

            var bottomPossibleAnswersStackLayout = new StackLayout()
            {
                Spacing = 5,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center
            };

            var answerAreaLayout = new StackLayout()
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Label appNameLabel = new Label()
            {
                Text = "World Quiz",
                BackgroundColor = new Color(4, 5, 5, 4),
                FontSize = 15,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Label questionLabel = new Label()
            {
                Text = "What is capital of " + countries.FirstOrDefault().Name,
                BackgroundColor = new Color(4, 5, 5, 4),
                
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            int countryIndex = 0;
            foreach (var country in countries)
            {
                if (countryIndex == 0 || countryIndex == 1)
                {
                    Button button = new Button
                    {
                        Text = country.Capital,
                        Font = Font.SystemFontOfSize(NamedSize.Small),
                        BorderWidth = 1,
                        HeightRequest = 50,
                        WidthRequest = 100,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    };
                    topPossibleAnswersStackLayout.Children.Add(button);
                }
                else
                {
                    Button button = new Button
                    {
                        Text = country.Capital,
                        Font = Font.SystemFontOfSize(NamedSize.Small),
                        BorderWidth = 1,
                        HeightRequest = 50,
                        WidthRequest = 100,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    };
                    bottomPossibleAnswersStackLayout.Children.Add(button);
                }
               
                countryIndex++;
            }
     
            //   button.Clicked += OnButtonClicked;

           
            questionStackLayout.Children.Add(questionLabel);


            mainStackLayout.Children.Add(appNameLabel);
            mainStackLayout.Children.Add(questionStackLayout);
            answerAreaLayout.Children.Add(topPossibleAnswersStackLayout);
            answerAreaLayout.Children.Add(bottomPossibleAnswersStackLayout);

            mainStackLayout.Children.Add(answerAreaLayout);
            Content = mainStackLayout;

        }
    }
}
