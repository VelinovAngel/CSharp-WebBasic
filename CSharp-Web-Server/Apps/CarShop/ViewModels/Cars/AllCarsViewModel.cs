namespace CarShop.ViewModels.Cars
{
    public class AllCarsViewModel
    {
        public string Model { get; set; }

        public int Year { get; set; }

        public string Image { get; set; }

        public string PlateNumber { get; set; }

        public int RemainingIssues { get; set; }

        public int FixedIssues { get; set; }
    }
}
