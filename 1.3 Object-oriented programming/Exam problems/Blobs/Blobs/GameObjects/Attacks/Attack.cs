namespace Blobs.GameObjects.Attacks
{
    using Interfaces;

    public abstract class Attack : IAttack
    {
        protected Attack()
        {
        }
        
        public decimal AttackIncreaseRate { get; protected set; }

        public decimal HealthLossRate { get; protected set; }
    }
}
