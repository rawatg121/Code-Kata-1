using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Kata
{
    class KataConstructorInjection
    {
        KataConsumer obj;
        public KataConstructorInjection()
        {
            obj = new KataConsumer(new KataConcrete());
        }
        public void StartTrip()
        {
            obj.StartTrip();
        }
    }
}
