using FluentValidation;

namespace NEO.Api.Queries.Assets.Validator
{
    public class GetAllAssetsValidator : AbstractValidator<GetAllAssetsQuery> 
    {
        public GetAllAssetsValidator() 
        {
            RuleFor(a => a.PageNumber)
                 .InclusiveBetween(1, int.MaxValue)
                 .WithMessage($"The Page number should be between 1 and {int.MaxValue}");

            RuleFor(a => a.RegistersNumber)
                 .InclusiveBetween(1, 100)
                 .WithMessage("The Registers Number should be between 1 and 100");
        }
    }
}
