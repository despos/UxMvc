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
    public class DateViewModel : ViewModelBase
    {
        public DateViewModel()
        {
            TheDate = DateTime.Today;
        }

        public DateTime? TheDate { get; set; }
    }
}