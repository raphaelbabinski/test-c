using FluentValidation;

namespace GrupoBoticario.Product.Business.Models._Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(f => f.Sku)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido");

            RuleFor(f => f.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(5, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLenght} e {MaxLenght} caracteres");
        }
    }
}
