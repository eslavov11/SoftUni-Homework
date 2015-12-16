namespace MyTunesShop.Interfaces
{
    public interface ISong : IMedia, IRateable
    {
        IPerformer Performer { get; }

        string Genre { get; }

        int Year { get; }

        string Duration { get; }
    }
}
