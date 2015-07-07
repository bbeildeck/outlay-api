using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Outlay.Modules
{
    public class ExpenseModule : NancyModule
    {
        public ExpenseModule()
        {
            Get["/"] = parameters => "Hello..";
        }
    }
}