namespace Blobs.GameObjects.Attacks
{
    public class BlobplodeAttack : Attack
    {
        private const decimal DefaultBlopplodeAttackIncreaseRate = 2;
        private const decimal DefaultBlopplodeHealthLossRate = 2;

        public BlobplodeAttack()
        {
            base.AttackIncreaseRate = DefaultBlopplodeAttackIncreaseRate;
            base.HealthLossRate = DefaultBlopplodeHealthLossRate;
        }
    }
}
