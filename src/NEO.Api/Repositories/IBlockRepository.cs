using NEO.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEO.Api.Repository
{
    public interface IBlockRepository
    {
        Task<IEnumerable<Block>> GetAll();
    }
}
