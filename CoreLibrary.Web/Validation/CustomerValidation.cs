using CoreLibrary.Web.Models;
using FluentValidation;

namespace CoreLibrary.Web.Validation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public string NotEmptyMessage { get; } = "{PropertyName} alanı Boş Olamaz";
        public CustomerValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.Email).NotEmpty().WithMessage(NotEmptyMessage)
                .EmailAddress().WithMessage("Email Alanı Doğru Formatta Olmalıdır");
            RuleFor(x => x.Age).InclusiveBetween(18, 60).WithMessage("Age Aralığı 18-60 arasında olmalıdır");

            RuleFor(x => x.BirthDate).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("Yaşınız 18 yaşından büyük olmalıdır");
            RuleForEach(x => x.Address).SetValidator(new AddressValidator());
            RuleFor(x => x.Gender).IsInEnum().WithMessage("Cinsiyet Alanı erkek için 1 kadın 2 olmalıdır");
        }
    }
}
