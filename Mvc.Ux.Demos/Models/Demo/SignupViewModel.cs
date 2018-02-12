///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System;

namespace Mvc.Ux.Demos.Models.Demo
{
    public class SignupViewModel : ViewModelBase
    {
        public SignupViewModel()
        {
            Name = String.Empty;
            Address = String.Empty;
        }

        public string Name { get; set; }
        public string Address { get; set; }
    }
}