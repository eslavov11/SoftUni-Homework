namespace Blobs.Interfaces
{
    /// <summary>
    /// Defines behavior for performing an attack.
    /// </summary>
    public interface IAttack
    {
        decimal AttackIncreaseRate { get; }

        decimal HealthLossRate { get; }
    }
}
