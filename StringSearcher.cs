using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithems
{
    public static class StringSearcher
    {
        public static class RabinKarp
        {
            private static bool Compare(string prash, string text, int start)
            {
                for (int i = 0; i < prash.Length; i++, start++)
                    if (prash[i] != text[start])
                        return false;

                return true;
            }

            /// <summary>
            /// Search for prash in text using Rabin-Karp algorithem
            /// </summary>
            /// <returns></returns>
            public static bool Search(string text, string prash)
            {
                for (int i = 0; i < text.Length - prash.Length; i++)
                {
                    if(Compare(prash, text, i))
                        return true;
                }

                return false;
            }
        }
    }
}
