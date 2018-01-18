///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
// M01 - Picking Items from a (Long) List
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System;

namespace Mvc.Ux.Demos.Common
{
    public class AutoCompleteItem
    {
        // Display text for the drop-down list (contains HTML styles)
        public String label { get; set; }

        // Unique ID of the returned item
        public String id { get; set; }

        // Value to copy in the textbox
        public String value { get; set; }
    }
}