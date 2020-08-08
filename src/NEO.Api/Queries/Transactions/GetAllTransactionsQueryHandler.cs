using MediatR;
using NEO.Api.Extensions;
using NEO.Api.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NEO.Api.Queries
{
    public class GetAllTransactionsQueryHandler : IRequestHandler<GetAllTransactionsQuery, Response>
    {
        private readonly ITransactionRepository transactionRepository;

        public GetAllTransactionsQueryHandler(ITransactionRepository transactionRepository) 
        {
            this.transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<Response> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken) 
        {
            var result = await transactionRepository.GetAll(request.RegistersNumber, request.RegistersIgnored);

            return new Response(result);
        }
    }
}
