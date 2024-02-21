using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TableGenerator
{
    public class Car
    {
        [DisplayName("Identification")]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public int MaxSpeed { get; set; }
        public float Weight { get; set; }
    }
}
