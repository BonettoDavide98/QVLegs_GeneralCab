using QVLEGS.Class;
using QVLEGS.DataType;
using QVLEGS.DBL;

namespace QVLEGS.Pagine
{
    public interface IUCPaginaLive
    {
        void ActivateDisplay();
        void Init(AppManager appManager, int idStazione, Impostazioni impostazioni, object repaintLock);
        void Translate(LinguaManager linguaManager);
    }
}