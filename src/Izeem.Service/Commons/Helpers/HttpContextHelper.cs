﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Izeem.Service.Commons.Helpers;

public class HttpContextHelper
{
    public static IHttpContextAccessor Accessor { get; set; }
    public static HttpContext HttpContext => Accessor?.HttpContext;
    public static IHeaderDictionary ResponseHeaders => HttpContext?.Response?.Headers;
    public static long? UserId => long.TryParse(HttpContext?.User?.FindFirst("id")?.Value, out _tempUserId) ? _tempUserId : null;
    public static string UserRole => HttpContext?.User?.FindFirst("role")?.Value;

    private static long _tempUserId;
}
