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
    public class CustomerListViewModel : ViewModelBase
    {
        public CustomerListViewModel()
        {
            Customers = new List<Customer>();
        }

        public IList<Customer> Customers { get; set; }
    }
}