using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Shared.ReturnObjects
{
    public record DataResult<T>
    {
        public string Message { get; init; }
        public bool Succeed { get; init; }
        public T Data { get; init; } 
        public DataResult(string message, bool result, T data)
        {
            Message = message;
            Succeed = result;
            Data = data;
        }
    }
}
