using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Shared.ReturnObjects
{
    public class Result
    {
        public string Message { get; init; }
        public bool Succeed { get; init; } 
        public Result(string message, bool result)
        {
            Message = message;
            Succeed = result; 
        }
    }
}
