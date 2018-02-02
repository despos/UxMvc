///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using Mvc.Ux.Demos.Backend.Model;
using PagedList;

namespace Mvc.Ux.Demos.Models.Demo
{
    public class PagedCountryListViewModel : ViewModelBase
    {
        public PagedCountryListViewModel()
        {
            Header = new HeaderViewModel();
        }

        public PagedList<Country> CountriesInPage { get; set; }
        public HeaderViewModel Header { get; set; }
    }
}