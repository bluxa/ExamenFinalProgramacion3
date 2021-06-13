using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalProgramacion3
{
    public class Estudiante : InterfazComparador
    {
        public string Apellidos { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
        public string Lab1 { get; set; }
        public string Lab2 { get; set; }
        public string Lab3 { get; set; }
        public string Lab4 { get; set; }

        public Estudiante(string apellidos, string nombre, string email, string id, string lab1, string lab2, string lab3, string lab4)
        {
            Apellidos = apellidos;
            Nombre = nombre;
            Email = email;
            Id = id;
            Lab1 = lab1;
            Lab2 = lab2;
            Lab3 = lab3;
            Lab4 = lab4;
        }

        public Estudiante()
        {
        }

        public bool BusquedaAvanzada(object q)
        {
            Estudiante info_Usuario = (Estudiante)q;
            return (info_Usuario.Id.StartsWith(Id) == true);
        }

        public bool UsuarioIgual(object q)
        {
            Estudiante info_Usuario = (Estudiante)q;
            return (info_Usuario.Id.CompareTo(Id) == 0);
        }

        public bool UsuarioMayor(object q)
        {
            Estudiante info_Usuario = (Estudiante)q;
            return (info_Usuario.Id.CompareTo(Id) == 1);
        }

        public bool UsuarioMenor(object q)
        {
            Estudiante info_Usuario = (Estudiante)q;
            return (info_Usuario.Id.CompareTo(Id) == -1);
        }

        public override string ToString()
        {
            return Environment.NewLine+"[" + Nombre + ",  " + Apellidos + ",  " + Id + "]"+Environment.NewLine;
        }
    }
}
