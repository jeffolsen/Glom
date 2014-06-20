using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.IO;

namespace Glom
{
    class MakeshiftSpec
    {
        string description;

        protected void Expect(bool expectation, [CallerFilePath] string path = "", [CallerLineNumber] int lineNumber = 0)
        {
            if (!expectation)
            {
                throw new Exception("Failed expectation: " + File.ReadLines(path).Skip(lineNumber - 1).First().Trim());
            }
        }

        protected void Pending(string reason)
        {
            throw new Exception("Pending " + reason);
        }

        protected void Describe(string descriptor, Action body)
        {
            string oldDescription = description;
            description += " " + descriptor;
            body.Invoke();
            description = oldDescription;
        }

        protected void It(string descriptor, Action test)
        {
            try
            {
                test.Invoke();
                System.Diagnostics.Debug.WriteLine("PASS: " + description + " " + descriptor);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("FAIL: " + description + " " + descriptor + " EXCEPTION " + e);
            }
        }
    }
}
