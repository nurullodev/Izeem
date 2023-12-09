using Izeem.Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izeem.Service.Commons.Helpers;

public class TimeHelper
{
    public static DateTime GetDateTime()
    {
        var time = DateTime.UtcNow;
        return time.AddHours(TimeConstant.UTC);
    }
}
