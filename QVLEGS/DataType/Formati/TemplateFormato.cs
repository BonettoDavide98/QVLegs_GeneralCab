﻿namespace QVLEGS.DataType
{
    public class TemplateFormato
    {

        public static TemplateFormato Template1
        {
            get
            {
                return new TemplateFormato()
                {
                    Name = "TEMPLATE_1",
                    IsCircle = false,
                    AlgIntegritaEnable = true,
                    AlgDisegniEnable = false,
                    AlgCrepeEnable = false,
                    AlgDimensioniEnable = true,
                    AlgColoreEnable = false,
                    AlgColore2Enable = false,

                    AlgSbordamentoEnable = false,
                    AlgAltezzaEnable = true,
                    AlgDimensioniLatoEnable = false,
                    AlgRakeDimensioniLatoEnable = false,

                    AlgControlloTop3DEnable = false,

                    AlgDistanzaLato3DEnable = false,
                    AlgBuchiLato3DEnable = false,
                };
            }
        }

        public static TemplateFormato Template2
        {
            get
            {
                return new TemplateFormato()
                {
                    Name = "TEMPLATE_2",
                    IsCircle = true,
                    AlgIntegritaEnable = true,
                    AlgDisegniEnable = false,
                    AlgCrepeEnable = false,
                    AlgDimensioniEnable = true,
                    AlgColoreEnable = false,
                    AlgColore2Enable = false,

                    AlgSbordamentoEnable = false,
                    AlgAltezzaEnable = true,
                    AlgDimensioniLatoEnable = false,
                    AlgRakeDimensioniLatoEnable = false,

                    AlgControlloTop3DEnable = false,

                    AlgDistanzaLato3DEnable = false,
                    AlgBuchiLato3DEnable = false,
                };
            }
        }

        public static TemplateFormato GetTemplateByName(string name)
        {
            if (Template1.Name == name)
                return Template1;
            else if (Template2.Name == name)
                return Template2;
            else
                return null;
        }

        public string Name { get; set; }
        public bool IsCircle { get; set; }

        public bool AlgIntegritaEnable { get; set; }
        public bool AlgDisegniEnable { get; set; }
        public bool AlgCrepeEnable { get; set; }
        public bool AlgDimensioniEnable { get; set; }
        public bool AlgColoreEnable { get; set; }
        public bool AlgColore2Enable { get; set; }
        public bool AlgSbordamentoEnable { get; set; }
        public bool AlgAltezzaEnable { get; set; }
        public bool AlgDimensioniLatoEnable { get; set; }
        public bool AlgRakeDimensioniLatoEnable { get; set; }
        public bool AlgControlloTop3DEnable { get; set; }
        public bool AlgDistanzaLato3DEnable { get; set; }
        public bool AlgBuchiLato3DEnable { get; set; }

    }
}
