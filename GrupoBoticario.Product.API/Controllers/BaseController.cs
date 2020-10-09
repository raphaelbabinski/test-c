using GrupoBoticario.Product.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrupoBoticario.Product.API.Controllers
{
    public class BaseController : ControllerBase
    {
        private readonly INotifier _notifier;

        public BaseController(INotifier notifier)
        {
            _notifier = notifier;
        }

        public bool ValidOperation()
        {
            return !_notifier.HasNotification();
        }
    }
}