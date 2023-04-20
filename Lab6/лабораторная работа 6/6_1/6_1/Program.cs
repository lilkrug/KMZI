﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

			Console.WriteLine("Лаба N6");
			Console.WriteLine("Изучение устройства и функциональных особенностей шифровальной машины «Энигма»");

            var enigma = new Enigma();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('N');
            

            var encoded = enigma.Crypt(stringBuilder.ToString(), 1, 1, 1);
            Console.WriteLine();

              var decoded = enigma.Crypt(encoded, 1, 1, 1);
             Console.WriteLine();
             Console.WriteLine($"Encoded:{encoded}\n" +
                       $"Decoded:{decoded}");
            Console.WriteLine();


            Console.ReadLine();
        }
    }
}
