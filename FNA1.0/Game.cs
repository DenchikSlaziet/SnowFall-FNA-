using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNA1._0
{
    public static class Game
    {
            static void Main(string[] args)
            {
                using (Logic Snowfall = new Logic())
                {
                 Snowfall.Run();
                }
            }
    }
}

