namespace WPFApp.Models
{
    public class ParcelModel : DomainModel
    {
        public string Number { get; set; }
        public string Location { get; set; }

        public ParcelModel() : base("Parcel")
        {

        }

    }
}
