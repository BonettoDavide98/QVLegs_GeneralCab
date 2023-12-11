using System;
using System.Collections.Generic;

namespace QVLEGS.Class.Manager
{
    public class SchedaIO
    {

        public  AdLinkPCI adlink_0 = null;
        public AdLinkPCI adlink_1 = null;
        private DataType.Impostazioni config = null;

        public void Init(DataType.Impostazioni config)
        {
            this.config = config;

#if !_Simulazione
            if (config.TipologiaComunizazioneRisultato == DataType.Impostazioni.TipoComunizazioneRisultato.SchedaIO)
            {
                adlink_0 = new AdLinkPCI(0);
                adlink_0.Connect();

                adlink_1 = new AdLinkPCI(1);
                adlink_1.Connect();

                //adlink_0.WriteDO((ushort)this.config.IdxOutLedVerde, 1);
                //adlink_0.WriteDO((ushort)this.config.IdxOutLedRosso, 0);
                //adlink_0.WriteDO((ushort)this.config.IdxOutLedGiallo, 0);
            }
#endif
        }
        public int ReadAll_0()
        {
            int res = 0;
#if !_Simulazione
            try
            {
                if (config.TipologiaComunizazioneRisultato == DataType.Impostazioni.TipoComunizazioneRisultato.SchedaIO)
                    adlink_0.ReadAllDI(out res);
            }
            catch (Exception ex)
            {

                throw;
            }
#endif
            return res;
        }

        public int ReadAll_1()
        {
            int res = 0;
#if !_Simulazione
            try
            {
                if (config.TipologiaComunizazioneRisultato == DataType.Impostazioni.TipoComunizazioneRisultato.SchedaIO)
                    adlink_1.ReadAllDI(out res);
            }
            catch (Exception ex)
            {

                throw;
            }
#endif
            return res;
        }

//        public void SetOutput(DataType.ElaborateResult result)
//        {
//            try
//            {
//#if !_Simulazione
//                if (config.TipologiaComunizazioneRisultato == DataType.Impostazioni.TipoComunizazioneRisultato.SchedaIO)
//                {
//                    foreach (var item in result.ResultOutput)
//                    {
//                        switch (item.Key)
//                        {
//                            case "DO0":
//                                adlink_1.WriteDO(13, (ushort)(item.Value ? 1 : 0));
//                                break;

//                            case "DO1":
//                                adlink_1.WriteDO(10, (ushort)(item.Value ? 1 : 0));
//                                break;

//                            case "DO2":
//                                adlink_0.WriteDO(2, (ushort)(item.Value ? 1 : 0));
//                                break;

//                            case "DO3":
//                                adlink_1.WriteDO(14, (ushort)(item.Value ? 1 : 0));
//                                break;

//                            case "DO4":
//                                adlink_1.WriteDO(15, (ushort)(item.Value ? 1 : 0));
//                                break;

//                            case "DO5":
//                                adlink_1.WriteDO(12, (ushort)(item.Value ? 1 : 0));
//                                break;

//                            case "DO6":
//                                adlink_1.WriteDO(11, (ushort)(item.Value ? 1 : 0));
//                                break;

//                            case "DO7":
//                                adlink_1.WriteDO(8, (ushort)(item.Value ? 1 : 0));
//                                break;

//                            case "DO8":
//                                adlink_1.WriteDO(9, (ushort)(item.Value ? 1 : 0));
//                                break;
//                            case "DO9":
//                                adlink_0.WriteDO(7, (ushort)(item.Value ? 1 : 0));
//                                break;

//                            case "DO10":
//                                adlink_0.WriteDO(6, (ushort)(item.Value ? 1 : 0));
//                                break;

//                            case "DO11":
//                                adlink_0.WriteDO(5, (ushort)(item.Value ? 1 : 0));
//                                break;

//                            case "DO12":
//                                adlink_0.WriteDO(4, (ushort)(item.Value ? 1 : 0));
//                                break;

//                            case "DO13":
//                                adlink_0.WriteDO(3, (ushort)(item.Value ? 1 : 0));
//                                break;

//                            case "DO14":
//                                adlink_0.WriteDO(2, (ushort)(item.Value ? 1 : 0));
//                                break;

//                            case "DO15":
//                                adlink_0.WriteDO(1, (ushort)(item.Value ? 1 : 0));
//                                break;

//                            default:
//                                break;
//                        }
//                    }
//                }
//#endif
//            }
//            catch (Exception ex) { }
//        }

        public void ResetAll()
        {
            try
            {
#if !_Simulazione
                adlink_1.WriteDO(13, 0);
                adlink_1.WriteDO(10, 0);
                adlink_0.WriteDO(2, 0);
                adlink_1.WriteDO(14, 0);
                adlink_1.WriteDO(15, 0);
                adlink_1.WriteDO(12, 0);
                adlink_1.WriteDO(11, 0);
                adlink_1.WriteDO(8, 0);
                adlink_1.WriteDO(9, 0);
                adlink_0.WriteDO(7, 0);
                adlink_0.WriteDO(6, 0);
                adlink_0.WriteDO(5, 0);
                adlink_0.WriteDO(4, 0);
                adlink_0.WriteDO(3, 0);
                adlink_0.WriteDO(2, 0);
                adlink_0.WriteDO(1, 0);

#endif
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void WriteSingle(int scheda, ushort port, ushort value)
        {
            try
            {
#if !_Simulazione
                if (scheda == 0)
                    adlink_0.WriteDO(port, value);
                else
                    adlink_1.WriteDO(port, value);
#endif
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void Sent13B_allwaysOK()
        {
            try
            {
#if !_Simulazione
                adlink_1.WriteDO(11, 1);
                adlink_0.WriteDO(7, 1);
#endif
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void SetDone(bool done)
        {
            try
            {
#if !_Simulazione
                if (config.TipologiaComunizazioneRisultato == DataType.Impostazioni.TipoComunizazioneRisultato.SchedaIO)
                {
                    //busy
                    adlink_1.WriteDO(6, (ushort)(done ? 0 : 1));
                    //ready
                    adlink_1.WriteDO(3, (ushort)(done ? 1 : 0));
                }
#endif
            }
            catch (Exception ex) { }
        }

        public void SetRun(bool run)
        {
            try
            {
#if !_Simulazione
                if (config.TipologiaComunizazioneRisultato == DataType.Impostazioni.TipoComunizazioneRisultato.SchedaIO)
                {
                    adlink_1.WriteDO(7, (ushort)(run ? 1 : 0));
                    adlink_0.WriteDO(14, (ushort)(run ? 1 : 0));
                }
#endif
            }
            catch (Exception ex) { }
        }

    }
}
