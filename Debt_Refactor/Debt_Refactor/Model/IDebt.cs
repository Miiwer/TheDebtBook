using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debt_Refactor.Model
{
    public interface IDebt
    {
        double amount { get; set; }
        DateTime date { get; set; }
    }
}
