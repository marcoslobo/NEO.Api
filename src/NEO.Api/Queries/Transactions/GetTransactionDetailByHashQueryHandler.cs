using MediatR;
using NEO.Api.Extensions;
using NEO.Api.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace NEO.Api.Queries
{
    public class GetTransactionDetailByHashQueryHandler : IRequestHandler<GetTransactionDetailByHashQuery, Response>
    {
        private readonly ITransactionRepository transactionRepository;

        public GetTransactionDetailByHashQueryHandler(ITransactionRepository transactionRepository) 
        {
            this.transactionRepository = transactionRepository ?? throw new ArgumentNullException(nameof(transactionRepository));
        }

        public async Task<Response> Handle(GetTransactionDetailByHashQuery request, CancellationToken cancellationToken)
        {
            return new Response(await transactionRepository.GetDetailByHash(request.Hash));
        }
    }
}
