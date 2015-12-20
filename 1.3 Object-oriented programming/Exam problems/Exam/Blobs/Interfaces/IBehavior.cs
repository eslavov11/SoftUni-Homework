namespace Blops.Interfaces
{
    public interface IBehavior
    {
        void Trigger(IBlob blob);

        void ApplyBehaviorTurn(IBlob blob);
    }
}
