///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System.Linq;
using Mvc.Ux.Demos.Backend.Model;
using Mvc.Ux.Demos.Backend.Persistence;
using Mvc.Ux.Demos.Common;
using Mvc.Ux.Demos.Models.Demo;
using PagedList;

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

        public CountryListViewModel GetCountryListViewModel()
        {
            var all = _countryRepository.All().ToList();
            var model = new CountryListViewModel
            {
                Countries = all,
                Header = new HeaderViewModel(all.Count())
            };
            return model;
        }

        public PagedCountryListViewModel GetPagedCountryListViewModel(int pageIndex, int pageSize)
        {
            var all = _countryRepository.All().ToList();
            var model = new PagedCountryListViewModel
            {
                Header = new HeaderViewModel(all.Count),
                CountriesInPage = new PagedList<Country>(all, pageIndex, pageSize)
            };
            return model;
        }
    }
}