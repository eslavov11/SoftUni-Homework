namespace Blobs.GameObjects.Behaviors
{
    using Interfaces;

    public abstract class Behavior : IBehavior
    {
        protected Behavior()
        {
        }

        public abstract void Trigger(IBlob blob);

        public abstract void ApplyBehaviorTurn(IBlob blob);
    }
}
