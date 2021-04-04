using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooker.Logic;

namespace Pluralsight.AdvCShColls.TourBooker.Logic
{
	public class AppData
	{
		public List<Country> AllCountries { get; private set; }
		//public SortedList<string, Country> AllCountriesByKey { get; private set; }
		public Dictionary<CountryCode,Country> AllCountriesByKey { get; private set; }

		public void Initialize(string csvFilePath)
		{
			CsvReader reader = new CsvReader(csvFilePath);
			//this.AllCountries = reader.ReadAllCountries();

			// during the module, the above line is changed to
			this.AllCountries = reader.ReadAllCountries().OrderBy(x=>x.Name).ToList();

			//var dict = this.AllCountries.ToDictionary(x => x.Code, StringComparer.OrdinalIgnoreCase);
			//this.AllCountriesByKey = new SortedList<string, Country>(dict);

			this.AllCountriesByKey = this.AllCountries.ToDictionary(x => x.Code);


		}
	}
}
