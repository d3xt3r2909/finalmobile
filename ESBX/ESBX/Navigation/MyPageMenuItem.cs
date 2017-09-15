using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX.Navigation
{

    public class MyPageMenuItem
    {
        public MyPageMenuItem()
        {
            TargetType = typeof(KreiranjeSalate);
        }
        
       
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}