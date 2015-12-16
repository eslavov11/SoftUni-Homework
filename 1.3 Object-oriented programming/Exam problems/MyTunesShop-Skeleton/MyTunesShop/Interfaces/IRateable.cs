using System.Collections.Generic;

namespace MyTunesShop.Interfaces
{
    public interface IRateable
    {
        IList<int> Ratings { get; }

        void PlaceRating(int rating);
    }
}
