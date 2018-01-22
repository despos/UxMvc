///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System.Collections.Generic;
using Mvc.Ux.Demos.Backend.Model;

namespace Mvc.Ux.Demos.Models.Demo
{
    public class CountryListViewModel : ViewModelBase
    {
        public CountryListViewModel()
        {
            Countries = new List<Country>();
        }

        public IList<Country> Countries { get; set; }
    }
}