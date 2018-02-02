///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

namespace Mvc.Ux.Demos.Models.Demo
{
    public class HeaderViewModel
    {
        public HeaderViewModel(int count = 0)
        {
            Count = count;
        }

        public int Count { get; set; }
    }
}