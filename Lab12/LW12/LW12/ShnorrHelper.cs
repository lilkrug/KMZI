using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LW12
{
    internal class ShnorrHelper
    {
        public BigInteger p, q, g, obg, y, a, hash, b, dov, X, hash2;
        public int x;
        public ShnorrHelper(BigInteger p, BigInteger q, BigInteger g, BigInteger obg, int x, string text)
        {
            this.p = p;
            this.q = q;
            this.g = g;
            this.obg = obg;
            this.x = x;

            y = BigInteger.ModPow(obg, x, p);
            a = BigInteger.Pow(g, 13) % p;
            hash = GetHash(text + a.ToString());
            b = (13 + x * hash) % q;
            dov = BigInteger.ModPow(g, b, p);
            X = (BigInteger.ModPow(g, b, p) * BigInteger.ModPow(y, hash, p)) % p;
            hash2 = GetHash((text + X.ToString()));
        }

        public static BigInteger GetHash(string input)
        {
            var md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
            return new BigInteger(hash.Concat(new byte[] { 0 }).ToArray());
        }
    }
}
