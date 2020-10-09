using FluentValidation;
using FluentValidation.Results;
using GrupoBoticario.Product.Business.Interfaces;
using GrupoBoticario.Product.Business.Models;

namespace GrupoBoticario.Product.Business.Service
{
    public abstract class BaseService
    {
        private readonly INotifier _notifier;

        public BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notifier(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notifier(error.ErrorMessage);
            }
        }

        protected void Notifier(string mensagem)
        {
            _notifier.Handle(new Notification(mensagem));
        }

        protected bool ExecuteValidate<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notifier(validator);
            return false;
        }
    }
}