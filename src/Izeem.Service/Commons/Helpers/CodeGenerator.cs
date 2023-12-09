using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izeem.Service.Commons.Helpers;

public class CodeGenerator
{
    public static int RandomCodeGenerator()
    {
        Random random = new Random();
        return random.Next(10000, 99999);
    }
}
