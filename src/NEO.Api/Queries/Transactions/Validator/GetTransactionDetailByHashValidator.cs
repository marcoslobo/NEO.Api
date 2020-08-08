using FluentValidation;

namespace NEO.Api.Queries.Transactions.Validator
{
    public class GetTransactionDetailByHashValidator : AbstractValidator<GetTransactionDetailByHashQuery> 
    {
        public GetTransactionDetailByHashValidator() 
        {
            RuleFor(x => x.Hash).NotEmpty().WithMessage("Hash required")  
                                .Must(x => x.Length == 64)
                                .WithMessage("Hash must have 64 chars"); 
        }
    }
}
