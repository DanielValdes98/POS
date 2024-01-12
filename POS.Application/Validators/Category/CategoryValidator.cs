using FluentValidation;
using POS.Application.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Application.Validators.Category
{
    public class CategoryValidator : AbstractValidator<CategoryRequestDTO>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage("El nombre de la categoria no puede ser nulo")
                .NotEmpty().WithMessage("El nombre de la categoria no puede estar vacio");
        }
    }
}
