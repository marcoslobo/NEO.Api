using RepoDb.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEO.Api.Models
{
    [Map("public.blocks")]
    public class Block
    {
        public long Index { get; set; }
    }
}
