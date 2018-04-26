using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
        string baseUrl = "http://restcountries.eu/rest/v2/";

        public async void GetAllCountriesFromAPIAsync()
        {
            string queryFilter = "?fields=name;capital;currencies;flag;";

            string url = baseUrl + queryFilter;

       
            try
            {
                HttpResponseMessage response = await client.GetAsync(new Uri(url));

                string responseBody = response.Content.ReadAsStringAsync().Result;

                var countries = JsonConvert.DeserializeObject<List<Country>>(responseBody);

                //Now let's insert the record

                using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App._dB_PATH))
                {
                    conn.CreateTable<Country>();
                    conn.Execute("DELETE FROM Country");
                    conn.InsertAll(countries, true);

                   
                }

            }
            catch (Exception ex)
            {

            }

        }

        public List<Country> GetNextPossibleAnswers()
        {
            List<Country> countryResponse = new List<Country>();


            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App._dB_PATH))
            {
                conn.CreateTable<Country>();
                countryResponse = conn.Table<Country>().ToList().OrderBy(s => Guid.NewGuid()).Take(4).ToList();
            }

            return countryResponse;
        }
    }
}
