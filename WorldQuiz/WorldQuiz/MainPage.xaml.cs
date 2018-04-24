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

		protected override void OnAppearing()
		{
			base.OnAppearing();

           // CountryService service = new CountryService();

		   // service.GetAllCountriesFromAPIAsync();
		}
	}
}
