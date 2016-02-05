using RPG.Weapons;

namespace RPG.Characters
{
    using RPG.Weapons;

    public class MageWithSword 
    {
        public Sword Weapon { get; set; }

        public override string ToString()
        {
            return string.Format("{0} wields weapon {1}",
                "Mage", "Sword");
        }
    }
}
