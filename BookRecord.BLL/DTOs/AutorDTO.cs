using BookRecord.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRecord.BLL.DTOs;

public class AutorDTO
{
    public int AutorId { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string CiudadProcedencia { get; set; } = null!;

    public string CorreoElectronico { get; set; } = null!;

    //public virtual ICollection<Libro> Libros { get; set; } = new List<Libro>();
}
