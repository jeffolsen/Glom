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

        void Test()
        {
            Describe("Glom", () =>
            {
                It("lets you add glommables", () =>
                {
                    Glom glom = new Glom();
                    glom.Add(new Mock());
                    Expect(glom.Count == 1);
                });

                It("sets the glom property of glommables when they are glommed on", () =>
                {
                    Glom glom = new Glom();
                    Glommable glommable = new Mock();
                    glom.Add(glommable);
                    Expect(glommable.Glom == glom);
                });

                Describe("All<Type>", () =>
                {
                    Glom glom = new Glom();
                    glom.Add(new MockA());
                    glom.Add(new MockA());

                    It("finds all of a type", () =>
                    {
                        Expect(glom.All<MockA>().Length == 2);
                    });

                    It("finds subclasses of a type", () =>
                    {
                        Expect(glom.All<Mock>().Length == 2);
                    });

                    It("returns an empty list when nothing is found", () =>
                    {
                        Expect(glom.All<MockB>().Length == 0);
                    });
                });

                Describe("One<Type>", () =>
                {
                    Glom glom = new Glom();
                    glom.Add(new MockA());

                    It("returns the first of a type", () =>
                    {
                        Expect(glom.One<MockA>() is MockA);
                    });

                    It("returns null if nothing is found", () =>
                    {
                        Expect(glom.One<MockB>() == null);
                    });
                });
            });

            Describe("Glommable.Destroy", () =>
            {
                Glom glom = new Glom();
                Glommable glommable = new Mock();
                glom.Add(glommable);
                glommable.Destroy();

                It("removes the glommable from the glom", () =>
                {
                    Expect(glom.One<Mock>() == null);
                });

                It("sets glommable's glom to null", () =>
                {
                    Expect(glommable.Glom == null);
                });

                It("sets glommable.IsDestroyed to true", () =>
                {
                    Expect(glommable.IsDestroyed == true);
                });
            });
        }

        class Mock : Glommable
        {
        }

        class MockA : Mock
        {
        }

        class MockB : Mock
        {
        }
    }
}
