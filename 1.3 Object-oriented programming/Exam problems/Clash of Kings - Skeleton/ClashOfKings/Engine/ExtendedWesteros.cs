namespace ClashOfKings.Engine
{
    using System.Linq;

    using ClashOfKings.Models;

    public class ExtendedWesteros : Westeros
    {
        private const int UpgradeHouseNumberOfCitiesThreshold = 10;
        private const int DowngradeHouseNumberOfCitiesThreshold = 5;

        public override void Update()
        {
            base.Update();

            this.UpgradeHouses();
            this.DowngradeHouses();
        }

        private void UpgradeHouses()
        {
            var housesToUpgrade = this.Houses
                .Where(h => !(h is GreatHouse) && h.ControlledCities.Count() >= UpgradeHouseNumberOfCitiesThreshold)
                .ToList();

            foreach (var house in housesToUpgrade)
            {
                var greatHouse = new GreatHouse(house.Name, house.TreasuryAmount, house.ControlledCities);

                this.Houses.Remove(house);
                this.Houses.Add(greatHouse);
            }
        }

        private void DowngradeHouses()
        {
            var housesToDowngrade = this.Houses
                .Where(h => (h is GreatHouse) && h.ControlledCities.Count() < DowngradeHouseNumberOfCitiesThreshold)
                .ToList();

            foreach (var greatHouse in housesToDowngrade)
            {
                var regularHouse = new House(greatHouse.Name, greatHouse.TreasuryAmount);

                foreach (var controlledCity in greatHouse.ControlledCities)
                {
                    regularHouse.AddCityToHouse(controlledCity);
                }

                this.Houses.Remove(greatHouse);
                this.Houses.Add(regularHouse);
            }
        }
    }
}
