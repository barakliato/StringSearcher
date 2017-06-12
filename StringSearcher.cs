using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithems
{
    public static class StringSearcher
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
        public static bool RabinKarpSearch(string text, string prash)
        {
            for (int i = 0; i < text.Length - prash.Length; i++)
            {
                if (Compare(prash, text, i))
                    return true;
            }

            return false;
        }

        public class BoyerMoore
        {
            private readonly string _prash;
            private readonly IDictionary<char, int> _badMatchTable;                     

            /// <summary>
            /// Boyer Moore algorithm.
            /// using bad match table
            /// </summary>
            /// <param name="prash">The value we are searching</param>
            public BoyerMoore(string prash)
            {              
                _prash = prash;
                _badMatchTable = new Dictionary<char, int>();
                for (int i = 0; i < prash.Length - 1; i++)
                {
                    var c = prash[i];
                    var length = prash.Length - i - 1;
                    if (_badMatchTable.ContainsKey(c))
                        _badMatchTable[c] = length;
                    else
                        _badMatchTable.Add(c, length);                    
                }

                var last = prash[prash.Length - 1];
                if (_badMatchTable.ContainsKey(prash[prash.Length - 1]))
                    _badMatchTable[last] = prash.Length;
                else
                    _badMatchTable.Add(last, prash.Length);
            }

            public bool Search(string text)
            {
                var start = _prash.Length - 1;
                int i = start;
                while (i < text.Length)
                {
                    bool found = true;
                    for (int j = start; j > -1; j--)
                    {
                        var shift = _prash.Length - 1 - j;
                        var c = text[i - shift];
                        if (c != _prash[j])
                        {
                            i += _badMatchTable.ContainsKey(c)
                                ? _badMatchTable[c]
                                : _prash.Length;

                            found = false;
                            break;
                        }
                    }

                    if (found)
                        return true;
                }

                return false;
            }
        }
    }
}
