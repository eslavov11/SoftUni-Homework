using System;
using System.Linq;
using TheSlum.Characters;
using TheSlum.GameObjects.Items;

namespace TheSlum.GameEngine
{
    public class GameObjectEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    PrintCharactersStatus(characterList);
                    break;
                case "create":
                    CreateCharacter(inputParams);
                    break;
                case "add":
                    AddItem(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            Character character;
            string characterType = inputParams[1];
            string id = inputParams[2];
            int x = int.Parse(inputParams[3]);
            int y = int.Parse(inputParams[4]);
            Team team = (Team)Enum.Parse(typeof(Team), inputParams[5]);

            switch (characterType)
            {
                case "mage":
                    character = new Mage(id, x, y, team);
                    break;
                case "warrior":
                    character = new Warrior(id, x, y, team);
                    break;
                case "healer":
                default:
                    character = new Healer(id, x, y, team);
                    break;
            }

            characterList.Add(character);
        }

        protected new void AddItem(string[] inputParams)
        {
            Item item;
            Character character = characterList.Where(x => x.Id == inputParams[1]).FirstOrDefault();
            string itemName = inputParams[2];
            string id = inputParams[3];
            switch (itemName)
            {
                case "axe":
                    item = new Axe(itemName);
                    break;
                case "shield":
                    item = new Shield(itemName);
                    break;
                case "injection":
                    item = new Injection(itemName);
                    break;
                case "pill":
                default:
                    item = new Pill(itemName);
                    break;
            }
            character.AddToInventory(item);
        }
    }
}