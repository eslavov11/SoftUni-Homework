namespace RPG.Characters
{
    using Bridge.Weapons;

    public abstract class Character
    {
        protected Character(Weapon weapon)
        {
            this.Weapon = weapon;
        }

        public Weapon Weapon { get; protected set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} wields weapon {this.Weapon.GetType().Name}";
        }
    }
}
