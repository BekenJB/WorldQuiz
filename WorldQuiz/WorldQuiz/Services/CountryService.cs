using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using WorldQuiz.Models;

namespace WorldQuiz.Services
{
    public class CountryService : ICountryService
    {
        HttpClient client;

        public CountryService()
        {
            this.client = new HttpClient();

        }

        /// <summary>
        /// TODO: Remove hard coded values.
        /// </summary>
        string baseUrl = "https://restcountries.eu/rest/v2/";

        public async void GetAllCountriesFromAPIAsync()
        {
            string queryFilter = "?fields=name;capital;currencies;flag;";

            string url = baseUrl + queryFilter;

            HttpResponseMessage response = await client.GetAsync(new Uri(url));

            string responseBody = response.Content.ReadAsStringAsync().Result;

            var countries = JsonConvert.DeserializeObject<List<Country>>(responseBody);

            //Now let's insert the record

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App._dB_PATH))
            {
                conn.CreateTable<Country>();

                conn.InsertAll(countries, true);
            }
            
        }
    }
}
