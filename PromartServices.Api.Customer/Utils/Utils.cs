using PromartServices.Api.Customer.Dto;
using System;

namespace PromartServices.Api.Customer.Utils
{
    public class Utils
    {
        public static int ObtenerEdad(DateTime fecha_nacimiento)
        {
            int edad = DateTime.Today.AddTicks(-fecha_nacimiento.Ticks).Year - 1;
            return edad;
        }
    }
}
