using System;

namespace QVLEGS.DataType
{
    public class Definizione_Turni
    {
        public short NomeTurno { get; set; }
        public TimeSpan OraInizioTurno { get; set; }
        public TimeSpan OraFineTurno { get; set; }
        public short Giorno { get; set; }
    }
}
