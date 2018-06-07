using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc.Ux.Demos.Models.Extra
{
    public class SimpleFormInputModel : ViewModelBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool RememberMe { get; set; }
    }
}