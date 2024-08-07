using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace City.Api.Core
{
    public class CityEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = "İstanbul";

        public int Populasyon { get; set; } = 1700000;
        public RgbCity Class { get; set; } = RgbCity.Marmara;
        public UserEntity? User { get; set; }
        

    }
}
