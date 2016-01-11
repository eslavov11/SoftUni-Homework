namespace Blobs.Interfaces
{
    /// <summary>
    /// Interface which holds all behavior that a destroyable unit has.
    /// </summary>
    public interface IDestroyable
    {
        int Health { get; set; }

        int InitialHealth { get; }
    }
}
