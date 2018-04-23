using System;
using System.Collections.Generic;
using System.Text;

namespace WorldQuiz.Models
{
    public class Country
    {

        public List<Currency> Currencies { get; set; }

        public string Name { get; set; }

        public string Capital { get; set; }
    }
}
