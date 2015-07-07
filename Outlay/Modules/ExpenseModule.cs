using Nancy;
using Outlay.Models;
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
            Get["/status"] = _ => "Hello..";

            Get["/expense/get"] = p =>
            {
                var expenses = new Expense[]
                {
                    new Expense { Id = 1, Value = 5000, Category = ExpenseCategory.Artist, Description = "Tiesto"},
                    new Expense { Id = 2, Value = 500, Category = ExpenseCategory.Electricity},
                    new Expense { Id = 3, Value = 3000, Category = ExpenseCategory.Liquor, Description = "Black label"},
                    new Expense { Id = 4, Value = 1000, Category = ExpenseCategory.Liquor, Description = "Grey Goose"}
                };

                return Response.AsJson<IEnumerable<Expense>>(expenses);
            };

            Get["/expense/get/{id}"] = p =>
            {
                var expenses = new Expense[]
                {
                    new Expense { Id = 1, Value = 5000, Category = ExpenseCategory.Artist, Description = "Tiesto"},
                    new Expense { Id = 2, Value = 500, Category = ExpenseCategory.Electricity},
                    new Expense { Id = 3, Value = 3000, Category = ExpenseCategory.Liquor, Description = "Black label"},
                    new Expense { Id = 4, Value = 1000, Category = ExpenseCategory.Liquor, Description = "Grey Goose"}
                };

                var exp = expenses.SingleOrDefault(x => x.Id == p.id);
                if (exp == null)
                {
                    return Negotiate
                        .WithStatusCode(HttpStatusCode.NotFound);
                }

                return Response.AsJson(exp);
            };
        }
    }
}