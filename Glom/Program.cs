using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glom
{
    class Program : MakeshiftSpec
    {
        static void Main(string[] args)
        {
            new Program().Test();
        }

        void Test() {
            Describe("Glom", () =>
            {
                It("should let you add glommables", () =>
                {
                    Glom glom = new Glom();
                    glom.Add(new MockGlommable() { });
                    Expect(glom.Count == 1);
                });
            });
        }

        class MockGlommable : Glommable
        {
                
        }
    }
}
