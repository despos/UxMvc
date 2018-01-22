///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using Mvc.Ux.Demos.Backend.Model;
using Mvc.Ux.Demos.Backend.Persistence;
using Mvc.Ux.Demos.Common;

namespace Mvc.Ux.Demos.Application
{
    public class CountryService
    {
        private readonly CountryRepository _countryRepository = new CountryRepository();

        public Country GetCountryViewModel(string code)
        {
            var country = _countryRepository.Find(code);
            country.Population = country.Population.ToIntFormat();
            country.AreaInSqKm = country.AreaInSqKm.ToIntFormat();
            return country;
        }

        public Country GetCountryViewModelForEdit(string code)
        {
            var country = _countryRepository.Find(code);
            return country;
        }
    }
}