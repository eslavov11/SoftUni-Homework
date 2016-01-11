namespace Blobs.GameObjects.Behaviors
{
    using Interfaces;

    public class AggressiveBehavior : GameObjects.Behaviors.Behavior
    {
        private const int DefaultAggressiveBehaviorDamageRate = 2;
        private const int DefaultAggressiveBehaviorDamageTurnSubtraction = 5;

        public AggressiveBehavior()
        {
        }

        public override void Trigger(IBlob blob)
        {
            blob.Damage *= DefaultAggressiveBehaviorDamageRate;
        }

        public override void ApplyBehaviorTurn(IBlob blob)
        {
            if (blob.InitialDamage <= blob.Damage - DefaultAggressiveBehaviorDamageTurnSubtraction)
            {
                blob.Damage -= DefaultAggressiveBehaviorDamageTurnSubtraction;
            }
        }
    }
}
