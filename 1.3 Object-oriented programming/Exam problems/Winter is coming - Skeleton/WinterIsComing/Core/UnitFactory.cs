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
                // TODO: Implement units
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
