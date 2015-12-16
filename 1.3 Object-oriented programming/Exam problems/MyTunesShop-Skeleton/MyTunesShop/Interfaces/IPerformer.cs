using System.Collections.Generic;
using MyTunesShop.Models;

namespace MyTunesShop.Interfaces
{
    public interface IPerformer
    {
        string Name { get; }

        PerformerType Type { get; }

        IList<ISong> Songs { get; }
    }
}
