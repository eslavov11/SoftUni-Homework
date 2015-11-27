using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BankOfKurtovoKonare.Interfaces
{
    public interface IAccountable
    {
        decimal Deposit { get; }

        decimal Interest(int months);
    }
}
