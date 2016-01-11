namespace Blobs.GameObjects.Behaviors
{
    using Interfaces;

    public class InflatedBehavior : Behavior
    {
        private const int DefaultInflatedBehaviorHealthBonus = 50;
        private const int DefaultInflatedBehaviorHealthTurnSubtraction = 10;

        public InflatedBehavior()
        {
        }

        public override void Trigger(IBlob blob)
        {
            blob.Health += DefaultInflatedBehaviorHealthBonus;
        }

        public override void ApplyBehaviorTurn(IBlob blob)
        {
            blob.Health -= DefaultInflatedBehaviorHealthTurnSubtraction;
        }
    }
}
