///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

namespace Mvc.Ux.Demos.Common
{
    public class CommandResponse
    {
        public static CommandResponse Ok = new CommandResponse {Success = true};
        public static CommandResponse Fail = new CommandResponse {Success = false};

        public bool Success { get; private set; }
        public string Message { get; private set; }
        public string RedirectUrl { get; private set; }

        public CommandResponse SetMessage(string message)
        {
            Message = message;
            return this;
        }
        public CommandResponse SetRedirect(string url)
        {
            RedirectUrl = url;
            return this;
        }
    }
}