///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using Expoware.Youbiquitous.Extensions;

namespace Mvc.Ux.Demos.Models
{
    public class ViewModelBase
    {
        public ViewModelBase(string title = "")
        {
            if (title.IsNullOrWhitespace())
                title = "MVC-UX";
            Title = title;
        }

        public string Title { get; set; }
    }
}