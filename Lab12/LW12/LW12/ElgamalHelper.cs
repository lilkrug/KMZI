using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LW12
{
    internal class ElgamalHelper
    {
        public int p, g, x, y, k, a, H, m, k1;
        public BigInteger b;
        public ElgamalHelper(int p, int g, int x, int k, int H, int m)
        {
            this.p = p;
            this.g = g;
            this.x = x;
            this.k = k;
            this.H = H;
            this.m = m;

            y = (int)BigInteger.ModPow(g, x, p);
            a = (int)BigInteger.ModPow(g, k, p);
            k1 = InvertedNumber(k, p - 1);
            b = new BigInteger((k1 * (H - (x * a) % m) % m) % m);
        }

        public static int InvertedNumber(int a, int n)
        {
            int res = 0;
            for (int i = 0; i < 10000; i++)
                if (((a * i) % n) == 1) 
                    return (i);
            return (res);
        }
    }
}
