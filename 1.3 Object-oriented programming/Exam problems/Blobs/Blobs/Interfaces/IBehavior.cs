namespace Blobs.Interfaces
{
    /// <summary>
    /// Holds methods which a behavior consists of.
    /// </summary>
    public interface IBehavior
    {
        void Trigger(IBlob blob);

        void ApplyBehaviorTurn(IBlob blob);
    }
}
