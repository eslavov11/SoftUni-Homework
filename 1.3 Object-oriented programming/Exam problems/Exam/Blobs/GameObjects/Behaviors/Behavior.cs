namespace Blops.Models.Behavior
{
    using Interfaces;

    public abstract class Behavior : IBehavior
    {
        protected Behavior()
        {
        }

        //public string BehaviorName { get; private set; }

       // public IBlob Blob { get; private set; }

        public abstract void Trigger(IBlob blob);

        public abstract void ApplyBehaviorTurn(IBlob blob);
    }
}
