using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izeem.Service.Exceptions;

public class IzeemException : Exception
{
    public int StatusCode { get; set; }
    public IzeemException(int statusCode = 500, string message = "Something went wrong") : base(message)
    {
        StatusCode = statusCode;
    }
}