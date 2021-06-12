using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinalProgramacion3
{
    public interface InterfazComparador
    {
        bool UsuarioIgual(object q);
        //public bool UsuarioDiferente(object q);
        //public bool ContraseñaIgual(object q);
        //public bool ContraseñaDiferente(object q);
        bool UsuarioMayor(object q);
        bool UsuarioMenor(object q);
        bool BusquedaAvanzada(object q);
    }
}
