using System.Collections.Generic;

namespace GrupoBoticario.Product.Business.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotification();
        string GetMessageNotification();
        void Handle(Notification notificacao);
    }
}