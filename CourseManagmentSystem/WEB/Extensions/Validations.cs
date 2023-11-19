using App.Domain.Models;
using FluentValidation;

namespace WEB.Extensions
{
    public static class Validations
    {
        public class CategoryValidation : AbstractValidator<Category>
        {
            public CategoryValidation()
            {
                RuleFor(i => i.Name).NotEmpty().WithName("Kategori Adı");
            }
        }
    }
}
