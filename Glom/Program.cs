using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.IO;

namespace Glom
{
    class Program
    {
        static void Expect(bool expectation, [CallerFilePath] string path = "", [CallerLineNumber] int lineNumber = 0)
        {
            if (!expectation)
            {
                throw new Exception("Failed expectation: " + File.ReadLines(path).Skip(lineNumber - 1).First().Trim());
            }
        }

        static void It(string descriptor, Action test)
        {
            try
            {
                test.Invoke();
                System.Diagnostics.Debug.WriteLine("PASS: It " + descriptor);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("FAIL: It " + descriptor + " EXCEPTION " + e);
            }
        }

        static void Main(string[] args)
        {
            It("should fail false expectations", () =>
            {
                Expect(1 == 2); // because i'm god
            });
        }
    }
}
