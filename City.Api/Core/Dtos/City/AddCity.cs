namespace City.Api.Core.Dtos.City
{
    public class AddCity
    {
        public string Name { get; set; } = "İStanbul0";
        public int Populasyon { get; set; } = 1700000;
        public RgbCity Class { get; set; } = RgbCity.Marmara;
    }
}
