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
        private readonly CustomerRepository _customerRepository = new CustomerRepository();

        public CountryListViewModel GetCountryListViewModel()
        {
            var all = _countryRepository.All().ToList();
            var model = new CountryListViewModel
            {
                Countries = all
            };
            return model;
        }

        public CustomerListViewModel GetCustomerListViewModel()
        {
            var all = _customerRepository.FindAll();
            var model = new CustomerListViewModel
            {
                Customers = all
            };
            return model;
        }

        public CustomerListViewModel TryDeleteCustomer(int id)
        {
            _customerRepository.Delete(id);
            return GetCustomerListViewModel();
        }
    }
}