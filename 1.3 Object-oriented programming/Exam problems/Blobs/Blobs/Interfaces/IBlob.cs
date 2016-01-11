namespace Blobs.Interfaces
{
    /// <summary>
    /// Holds all properties and methods for a blob.
    /// </summary>
    public interface IBlob : IAttacker, IDestroyable
    {
        string Name { get; }

        IBehavior Behavior { get; }

        IAttack Attack { get; }

        bool BehaviorIsTriggered { get; set; }

        bool BehaviorTriggeredInBattle { get; set; }

        void PerformAttack(IBlob targetBlob);

        void UpdateBehavior();
    }
}
