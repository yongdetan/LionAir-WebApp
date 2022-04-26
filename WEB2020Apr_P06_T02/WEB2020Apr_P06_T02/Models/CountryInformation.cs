using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB2020Apr_P06_T02.Models
{
    public class CountryInformation
    {
        public string Name { get; set; }

        public string Region { get; set; }

        public int Population { get; set; }

        public List<string> Timezones { get; set; }

        public string Capital { get; set; }

        public List<Language> Languages { get; set; }

    }
    public class Language
    {
        public string Name { get; set; }
    }

}
