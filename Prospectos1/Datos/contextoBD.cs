//Creacion de clase Contexto
// Se usa para manipular los datos en la BD
using System;
using Microsoft.EntityFrameworkCore;
using Prospectos1.Models;

namespace Prospectos1.Datos
{
    //Extendemos la clase con DbContext
    public class contextoBD:DbContext
    {
        //Indicamos las opciones de conexion a nuestro contexto
        public contextoBD(DbContextOptions<contextoBD> options) : base(options) {
        

        }
        //Creamos objeto Prospecto para manipular toda la información de la BD
        public DbSet<prospecto> prospectos { get; set; }
    }
}
