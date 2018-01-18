///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
// M01 - Picking Items from a (Long) List
//
// Author: Dino Esposito
// Youbiquitous.net
//

using Expoware.Youbiquitous.Extensions;

namespace Mvc.Ux.Picking.Models
{
    public class ViewModelBase
    {
        public ViewModelBase(string title = "")
        {
            if (title.IsNullOrWhitespace())
                title = "MVC-UX: Picking";
            Title = title;
        }

        public string Title { get; set; }
    }
}