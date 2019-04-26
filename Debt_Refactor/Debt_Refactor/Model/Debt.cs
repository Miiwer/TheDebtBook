using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Refactor.Model
{
    public class Debt : IDebt
    {
        public double amount { get; set; }
        public DateTime date { get; set; }
    }
}