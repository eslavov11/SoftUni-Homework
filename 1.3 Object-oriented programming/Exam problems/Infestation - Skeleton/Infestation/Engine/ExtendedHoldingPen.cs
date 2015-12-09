using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infestation.Supplements;
using Infestation.Units;

namespace Infestation.Engine
{
    public class ExtendedHoldingPen : HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    base.InsertUnit(tank);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    base.InsertUnit(marine);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    base.InsertUnit(queen);
                    break;
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    base.InsertUnit(parasite);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
            
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            var unitToInsert = base.GetUnit(commandWords[2]);
            var supplement = commandWords[1];
            switch (supplement)
            {
                case "HealthCatalyst":
                    unitToInsert.AddSupplement(new HealthCatalyst());
                    break;
                case "AggressionCatalyst":
                    unitToInsert.AddSupplement(new AggressionCatalyst());
                    break;
                case "PowerCatalyst":
                    unitToInsert.AddSupplement(new PowerCatalyst());
                    break;
                case "Weapon":
                    unitToInsert.AddSupplement(new Weapon());
                    break;
                default:
                    break;
                    //case "InfestationSpores":
                    //    unitToInsert.AddSupplement(new InfestationSpores());
                    //    break;
            }
        }
    }
}
