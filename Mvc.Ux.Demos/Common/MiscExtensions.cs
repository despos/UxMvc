///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//  

using System;

namespace Mvc.Ux.Demos.Common
{
    public static class MiscExtensions
    {
        /// <summary>
        /// Parse a given string to a number and format as a number
        /// </summary>
        /// <param name="theString">String to parse</param>
        /// <param name="defaultFormat">Default numeric format</param>
        /// <param name="defaultText">Text to return if not a number</param>
        /// <returns>Modified string</returns>
        public static String ToIntFormat(this String theString, String defaultFormat = "{0:n0}", String defaultText = "")
        {
            Decimal number;
            var success = Decimal.TryParse(theString, out number);
            if (!success)
                return theString;

            return String.Format(defaultFormat, number);
        }
    }
}