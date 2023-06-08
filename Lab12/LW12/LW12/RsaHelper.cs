using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LW12
{
    internal class RsaHelper
    {
        int n, eyler, d, e;
        List<string> sign;
        static char[] hashSymbols = new char[] { 
            '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '-', '#'
        };

        public RsaHelper(int p, int q)
        {
            sign = new List<string>();
            n = p * q;
            eyler = (p - 1) * (q - 1);
            d = GetD(eyler);
            e = GetE(d, eyler);
        }

        public int GetE(int d, int eyler)
        {
            int e = 10;

            while (true)
                if ((e * d) % eyler == 1) 
                    break;
                else 
                    e++;
            return (int)e;
        }

        public int GetD(int eyler)
        {
            int d = eyler - 1;
            for (int i = 2; i <= eyler; i++)
                if ((eyler % i == 0) && (d % i == 0))
                {
                    d--;
                    i = 1;
                }
            return d;
        }

        public List<string> Encrypt(string hash, int e, int n)
        {
            List<string> result = new List<string>();
            BigInteger bi;

            for (int i = 0; i < hash.Length; i++)
            {
                int index = Array.IndexOf(hashSymbols, hash[i]);

                bi = new BigInteger(index);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;
                result.Add(bi.ToString());
            }
            return result;
        }

        public string Decrypt(List<string> text, int d, int n)
        {
            string result = "";
            //text.Add("1");
            BigInteger bi;

            foreach (string i in text)
            {
                bi = new BigInteger(Convert.ToDouble(i));
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;
                int index = Convert.ToInt32(bi.ToString());
                result += hashSymbols[index].ToString();
            }

            return result;
        }

        public List<string> getSign(String text)
        {
            sign = Encrypt(text.GetHashCode().ToString(), e, n);
            return sign;
        }

        public string checkSign()
        {
            return Decrypt(sign, d, n);
        }
    }
}
