namespace Blops.Interfaces
{
    public interface IAttack
    {
        decimal AttackIncreaseRate { get; }

        decimal HealthLossRate { get; }
    }
}
