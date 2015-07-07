using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Outlay.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
        public ExpenseCategory Category { get; set; }
    }
}