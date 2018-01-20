///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
// M03 - Letting Users Pick a Date
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System;
using Mvc.Ux.Picking.Models;

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