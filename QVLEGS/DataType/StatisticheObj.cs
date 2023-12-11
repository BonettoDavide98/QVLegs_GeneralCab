using System;
using System.Collections.Generic;
using System.Linq;

namespace QVLEGS.DataType
{
    public class StatisticheObj
    {

        public class ObjMisura
        {
            public string Nome { get; set; }
            public double Valore { get; set; }

            public ObjMisura(string nome, double valore)
            {
                this.Nome = nome;
                this.Valore = valore;
            }
        }

        public class ObjContatore
        {
            public string Nome { get; set; }
            public bool Valore { get; set; }

            public ObjContatore(string nome, bool valore)
            {
                this.Nome = nome;
                this.Valore = valore;
            }
        }

        public int IdStazione { get; set; }
        public int IdCamera { get; set; }
        public DateTime DataRiferimentoTurno { get; set; }
        public int NomeTurno { get; set; }
        public string IdFormato { get; set; }
        public DateTime TimeStamp { get; set; }

        public List<ObjMisura> Misure { get; set; }
        public void AddMisura(string nome, double valore)
        {
            this.Misure.Add(new ObjMisura(nome, valore));
        }

        public List<ObjContatore> Contatori { get; set; }
        public void AddObjContatore(string nome, bool valore)
        {
            this.Contatori.Add(new ObjContatore(nome, valore));
        }


        public StatisticheObj()
        {
            this.Misure = new List<ObjMisura>();
            this.Contatori = new List<ObjContatore>();
        }

        private static bool? AndAll(List<bool?> o)
        {
            int cntNull = o.Count(k => k == null);
            int cntTrue = o.Count(k => k == true);
            int cntFalse = o.Count(k => k == false);

            if (cntNull == o.Count)
            {
                return null;
            }
            else if (cntTrue > 0 && cntFalse == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
