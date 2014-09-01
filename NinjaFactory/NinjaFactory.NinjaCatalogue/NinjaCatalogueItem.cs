namespace NinjaFactory.NinjaCatalogue
{
    public class NinjaCatalogueItem
    {
        public int NinjaId { get; set; }
        public string Name { get; set; }
        public int KillCount { get; set; }
        public string Weapon { get; set; }
        public decimal Price { get; set; }
        public string SpecialtyName { get; set; }
        public int JobsCount { get; set; }
        public int SuccessfullJobsCount { get; set; }
        public double SuccessRate { get; set; }

    }
}
