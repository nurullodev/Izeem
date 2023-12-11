using Izeem.Service.DTOs.Carts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izeem.Service.Interfaces.Carts;

public interface ICartService
{
    Task<CartResultDto> RetrieveByUserIdAsync(long userId);
}