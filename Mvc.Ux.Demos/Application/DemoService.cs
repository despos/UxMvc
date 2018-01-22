///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System.Linq;
using Mvc.Ux.Demos.Backend.Persistence;
using Mvc.Ux.Demos.Models.Demo;

namespace Mvc.Ux.Demos.Application
{
    public class DemoService
    {
        private readonly CountryRepository _countryRepository = new CountryRepository();

        public CountryListViewModel GetCountryListViewModel()
        {
            var all = _countryRepository.All().ToList();
            var model = new CountryListViewModel
            {
                Countries = all
            };
            return model;
        }
    }
}