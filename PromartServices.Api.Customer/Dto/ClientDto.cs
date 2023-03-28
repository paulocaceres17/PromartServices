using System;

namespace PromartServices.Api.Customer.Dto
{
    public class ClientDto
    {
        public Guid id { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public int edad { get; set; }
    }
}
