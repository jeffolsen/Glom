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

                Describe("Without<Type>(() => Type)", () =>
                {
                    It("calls the passed in function if nothing of the type exists", () =>
                    {
                        Glom glom = new Glom();
                        
                        glom.Without<Mock>(_ => _.Add(new Mock()));

                        Expect(glom.One<Mock>() is Mock);
                    });

                    It("returns the return of the function if it is called", () =>
                    {
                        Glom glom = new Glom();
                        
                        Glommable glommable = glom.Without<Mock>(_ => _.Add(new Mock()));

                        Expect(glommable is Mock);
                    });

                    It("returns the found element and doesn't call the function if the element already exists", () =>
                    {
                        Glom glom = new Glom();
                        glom.Add(new MockA());

                        Glommable glommable = glom.Without<Mock>(_ => _.Add(new MockB()));

                        Expect(glommable is MockA);
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
