using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoByJhon.Entidades
{
    internal class Jugador
    {
        public string Nombre { get; set; }
        public int Puntos { get; set; }
        public bool Turno { get; set; }
        public bool Ataque { get; set; }
        public bool Defensa { get; set; }
        public int Contador { get; set; }
        public bool AtaqueEspecial { get; set; }
        public bool RecuperacionEspecial { get; set; }

        public string puntajeTotal()
        {
            return "Puntos de "+Nombre+" son: "+Puntos;
        }

    }
}
