using Microsoft.EntityFrameworkCore;
using Notas.Models;
using Microsoft.AspNetCore.Authentication;


namespace Block.Data   //Se nombra (Nombre de carpeta).(Nombre carpeta base de datos"Base")
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions <BaseContext> options): base(options)
        {
        }
                                                                //Se indica el nombre de la base de datos
        public DbSet <Nota /*Se indica el nombre del modelo */> Notas { get; set; } 
    }
}