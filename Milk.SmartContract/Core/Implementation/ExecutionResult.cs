using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Milk.SmartContract.Core.Implementation
{
    public class ExecutionResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public string? Errors { get; set; }

    }
}
