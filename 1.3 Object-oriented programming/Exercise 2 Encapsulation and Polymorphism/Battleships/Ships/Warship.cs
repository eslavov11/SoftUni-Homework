namespace Battleships.Ships
{
    using System;

    public class Warship : BattleShip
    {

        public Warship(string name, double lengthInMeters, double volume)
            : base (name, lengthInMeters, volume)
        {
        }

        public override string Attack(Ship ship)
        {
            return "Victory is ours!";
        }
    }
}
