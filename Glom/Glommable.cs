using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glom
{
    abstract class Glommable
    {
        Glom glom;

        public Glom Glom
        {
            get
            {
                return glom;
            }

            internal set
            {
                glom = value;
            }
        }
    }
}
