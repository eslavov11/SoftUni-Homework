namespace Blobs.Interfaces
{
    /// <summary>
    /// Holds behavior for all attacking units.
    /// </summary>
    public interface IAttacker
    {
        int Damage { get; set; }

        int InitialDamage { get; }
    }
}
