using WinterIsComing.Core.Exceptions;
using WinterIsComing.Models.Units;

namespace WinterIsComing.Core
{
    using System;
    using Contracts;
    using Models;

    public static class UnitFactory
    {
        public static IUnit Create(UnitType type, string name, int x, int y)
        {
            switch (type)
            {
                case UnitType.IceGiant:
                    return new IceGiant(name, x, y);
                case UnitType.Mage:
                    return new Mage(name, x, y);
                case UnitType.Warrior:
                    return new Warrior(name, x, y);
                default:
                    throw new GameException("Ivalid hero name!");
            }
        }
    }
}
