using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glom
{
    class Glom : IEnumerable<Glommable>
    {
        List<Glommable> glommedOn = new List<Glommable>();

        public void Add(Glommable glommable)
        {
            glommedOn.Add(glommable);
            glommable.Glom = this;
        }

        public List<T> All<T>()
        {
            throw new NotImplementedException();
        }

        public T One<T>()
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get
            {
                return glommedOn.Count;
            }
        }

        public IEnumerator<Glommable> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
