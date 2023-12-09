using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izeem.Domain.Configurations;

public class PaginationParams
{
    private const int maxSize = 25;
    private int pageSize;
    public int PageSize
    {
        get => pageSize == 0 ? maxSize : pageSize;
        set => pageSize = value > maxSize ? maxSize : value;
    }

    public int PageIndex { get; set; } = 1;
}
