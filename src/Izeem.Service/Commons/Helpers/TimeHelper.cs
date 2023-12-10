using Izeem.Domain.Constants;

namespace Izeem.Service.Commons.Helpers;

public class TimeHelper
{
    public static DateTime GetDateTime()
    {
        var time = DateTime.UtcNow;
        return time.AddHours(TimeConstant.UTC);
    }
}
