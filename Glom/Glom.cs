﻿using System;
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

        public T[] All<T>() where T : Glommable
        {
            return glommedOn.Where(_ => _ is T).Select(_ => (T)_).ToArray();
        }

        public T One<T>() where T : Glommable
        {
            return (T)glommedOn.FirstOrDefault(_ => _ is T);
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
