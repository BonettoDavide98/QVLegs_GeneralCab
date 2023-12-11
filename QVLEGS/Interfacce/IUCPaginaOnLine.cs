using QVLEGS.Class;
using QVLEGS.DataType;
using QVLEGS.DBL;

namespace QVLEGS.Pagine
{
    public interface IUCPaginaOnLine
    {
        void ActivateDisplay();
        void Init(AppManager appManager, int idStazione, Impostazioni impostazioni, object repaintLock);
        void SetShowMode(UCPaginaOnLine.ShowMode showMode);
        void Translate(LinguaManager linguaManager);
    }
}