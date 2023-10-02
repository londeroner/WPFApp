namespace WPFApp.Models
{
    public class BuildingModel : DomainModel
    {
        public int FloorCount { get; set; }
        public string Address { get; set; }
        public bool IsLiving { get; set; }

        public BuildingModel() : base("Building") 
        {

        }
    }
}
