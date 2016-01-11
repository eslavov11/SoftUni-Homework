namespace Blobs.GameObjects.Attacks
{
    using Interfaces;

    public class PutridFartAttack : Attack
    {
        private const decimal DefaultPutridFartAttackIncreaseRate = 1;
        private const decimal DefaultPutridFartHealthLossRate = 1;

        public PutridFartAttack()
        {
            base.AttackIncreaseRate = DefaultPutridFartAttackIncreaseRate;
            base.HealthLossRate = DefaultPutridFartHealthLossRate;
        }
    }
}
