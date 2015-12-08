using FarmersCreed.Units;

namespace FarmersCreed.Simulator
{
    public class ExtendedFarmSimulator : FarmSimulator
    {
        protected override void ProcessInput(string input)
        {
            string[] inputCommands = input.Split(' ');
            string action = inputCommands[0];

            switch (action)
            {
                case "feed":
                    {
                        string animalId = inputCommands[1];
                        string foodId = inputCommands[2];
                        int foodQuantity = int.Parse(inputCommands[3]);
                        base.farm.Feed(base.GetAnimalById(animalId), base.GetProductById(foodId) as Food, foodQuantity);
                    }
                    break;
                case "water":
                    {
                        string plantId = inputCommands[1];
                        base.farm.Water(base.GetPlantById(plantId));
                    }
                    break;
                case "exploit":
                    {
                        string farmUnitType = inputCommands[1];
                        string farmUnitId = inputCommands[2];
                        ExploitFarmUnit(farmUnitType, farmUnitId);
                    }
                    break;
                default:
                    base.ProcessInput(input);
                    break;
            }

        }
        
        protected override void AddObjectToFarm(string[] inputCommands)
        {
            string type = inputCommands[1];
            string id = inputCommands[2];

            switch (type)
            {
                case "CherryTree":
                    {
                        var cherryTree = new CherryTree(id);
                        this.farm.Plants.Add(cherryTree);
                    }
                    break;
                case "TobaccoPlant":
                    {
                        var tobaccoPlant = new TobaccoPlant(id);
                        this.farm.Plants.Add(tobaccoPlant);
                    }
                    break;
                case "Cow":
                    {
                        var cow = new Cow(id);
                        this.farm.Animals.Add(cow);
                    }
                    break;
                case "Swine":
                    {
                        var swine = new Swine(id);
                        this.farm.Animals.Add(swine);
                    }
                    break;
                default:
                    base.AddObjectToFarm(inputCommands);
                    break;
            }
        }


        private void ExploitFarmUnit(string farmUnitType, string farmUnitId)
        {
            switch (farmUnitType)
            {
                case "animal":
                    base.farm.Exploit(base.GetAnimalById(farmUnitId));
                    break;
                case "plant":
                    base.farm.Exploit(base.GetPlantById(farmUnitId));
                    break;
                default:
                    break;
            }
        }
    }
}
