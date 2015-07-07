using Nancy;
using Outlay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.ModelBinding;

namespace Outlay.Modules
{
    public class ExpenseModule : NancyModule
    {
        public List<Expense> expenses = new List<Expense>
                {
                    new Expense { Id = 1, Value = 5000, Category = ExpenseCategory.Artist, Description = "Tiesto"},
                    new Expense { Id = 2, Value = 500, Category = ExpenseCategory.Electricity},
                    new Expense { Id = 3, Value = 3000, Category = ExpenseCategory.Liquor, Description = "Black label"},
                    new Expense { Id = 4, Value = 1000, Category = ExpenseCategory.Liquor, Description = "Grey Goose"}
                };

        public ExpenseModule()
        {
            Get["/"] = _ => "Oh, hai.";

            Get["/status"] = _ => HttpStatusCode.OK;

            Get["/expense"] = p =>
            {
                return Response.AsJson(expenses);
            };

            Get["/expense/{id}"] = p =>
            {
                var exp = expenses.SingleOrDefault(x => x.Id == p.id);
                if (exp == null)
                {
                    return HttpStatusCode.BadRequest;
                }

                return Response.AsJson(exp);
            };

            Post["/expense"] = p =>
            {
                Expense exp = this.Bind();
                expenses.Add(exp);

                return Response.AsJson(expenses);
            };
        }
    }
}