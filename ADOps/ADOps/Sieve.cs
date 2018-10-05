using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOps
{
    /// <summary>
    /// Of Eratosthenes
    /// </summary>
    public class Sieve
    {
        public int Limit { get; }

        public List<int> Primes { get { return primes ?? CalcPrimes(); } }
        private List<int> primes;

        /// <summary>
        /// Calculate all primes up to and including limit
        /// </summary>
        /// <param name="limit">All numbers up till and including limit</param>
        public Sieve(int limit)
        {
            if (limit < 2)
                throw new ArgumentException("Limit must be 2 or greater");
            Limit = limit;
        }

        private List<int> CalcPrimes()
        {
            primes = new List<int>();
            bool[] list = new bool[Limit + 1];
            list[0] = true;
            list[1] = true;
            int p = 2;
            int i = 2;
            int ip = i * p;

            while (p < Limit / 2)
            {
                while (p * i <= Limit)
                {
                    ip = i * p;
                    // mark non prime
                    list[ip] = true;
                    i++;
                }
                i = 2;
                // new p
                //p = list.FindIndex(p+1, b => b == false);
                for (int j = p + 1; j < list.Length; j++)
                {
                    if (!list[j])
                    {
                        p = j;
                        break;
                    }
                    else
                    {
                        p = -1;
                    }
                }

                if (p == -1)
                    break;
            }

            for (i = 0; i < list.Length; i++)
                if (!list[i])
                    primes.Add(i);
            
            return primes;
        }
    }
}
