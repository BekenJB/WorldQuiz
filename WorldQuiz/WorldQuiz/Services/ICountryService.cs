
using System.Collections.Generic;
using System.Threading.Tasks;
using WorldQuiz.Models;

namespace WorldQuiz.Services
{
  public interface ICountryService
    {

        void GetAllCountriesFromAPIAsync();
        List<Country> GetNextPossibleAnswers();
    }
}
