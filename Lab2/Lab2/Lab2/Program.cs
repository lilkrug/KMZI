   using Lab2.DocumentReader;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            const string fileName = "Lab2-1.xls";

            List<char> spainAlphabet = new List<char>()
            {
                'a','b','c','d','e','f','g','h','i','j','k',
                'l','m','n','o','p','r','s','t','u','v','w'
            };

            List<char> serbichAlphabet = new List<char>()
            {
                '\u0430','\u0431','\u0432','\u0433',
                '\u0434','\u0435','\u0454','\u0436','\u0437',
                '\u0438','\u0456','\u0457','\u0439','\u043A',
                '\u043B','\u043C','\u043D','\u043E','\u043F',
                '\u0440','\u0441','\u0442','\u0443','\u0444',
                '\u0445','\u0446','\u0447','\u0448','\u0449',
                '\u044C','\u044E','\u044F',
            };
            while (choice != 5)
            {
                Console.Clear();

                Console.WriteLine("Выберите номер задания:\n- 1\n- 2\n- 3\n- 4\n- 5-выйти");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.Clear();
                            EntropyChecker spainChecker = new EntropyChecker(spainAlphabet, 0, "Испанский");
                            EntropyChecker serbichChecker = new EntropyChecker(serbichAlphabet, 0, "Сербский");

                            string spainText = spainChecker.OpenDocument("spain.txt").ReadToEnd().ToLower();
                            string serbichText = spainChecker.OpenDocument("serbich.txt").ReadToEnd().ToLower();

                            Regex regex = new Regex(@"\W");
                            spainText = regex.Replace(spainText, "");
                            serbichText = regex.Replace(serbichText, "");

                            Dictionary<char, int> spainDict = spainChecker.alphabetListToDictionary();
                            Dictionary<char, int> serbichDict = serbichChecker.alphabetListToDictionary();

                            spainChecker.getSymbolsCounts(spainText, spainDict);
                            serbichChecker.getSymbolsCounts(serbichText, serbichDict);

                            Dictionary<char, double> chancesSpain = spainChecker.getSymbolsChances(spainText, spainDict);
                            Dictionary<char, double> chancesSerbich = serbichChecker.getSymbolsChances(serbichText, serbichDict);

                            spainChecker.computeTextEntropy(chancesSpain);
                            serbichChecker.computeTextEntropy(chancesSerbich);


                            spainChecker.printAlphabet();
                            spainChecker.printChances(chancesSpain);
                            spainChecker.printAlhabetEntropy();


                            serbichChecker.printAlphabet();
                            serbichChecker.printChances(chancesSerbich);
                            serbichChecker.printAlhabetEntropy();

                            double sumSpain = 0;
                            double sumSerbich = 0;
                            foreach (KeyValuePair<char, double> x in chancesSpain)
                            {
                                sumSpain += x.Value;
                            }
                            foreach (KeyValuePair<char, double> x in chancesSerbich)
                            {
                                sumSerbich += x.Value;
                            }

                            Console.WriteLine($"Сумма шансов для сербского языка: {sumSerbich}");
                            Console.WriteLine($"Сумма шансов для испанского языка: {sumSpain}");

                            ExcelDocumentCreator<char,double> excel = new ExcelDocumentCreator<char, double>(new System.IO.FileInfo(fileName));
                            excel.createWorksheet("first");
                            excel.addValuesFromDict(chancesSpain, "first", 0);
                            excel.addValuesFromDict(chancesSerbich, "first", 3);
                            excel.pack.Save();
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();

                            EntropyChecker spainChecker = new EntropyChecker(new List<char>(){ '0', '1' }, 0, "Бинарный код");
                            EntropyChecker serbichChecker = new EntropyChecker(new List<char>() { '0', '1' }, 0, "Бинарный код");

                            string spainText = spainChecker.OpenDocument("spain.txt").ReadToEnd().ToLower();
                            string serbichText = spainChecker.OpenDocument("serbich.txt").ReadToEnd().ToLower();

                            Regex regex = new Regex(@"\W");
                            spainText = regex.Replace(spainText, "");
                            serbichText = regex.Replace(serbichText, "");

                            string binTextSpain = "";
                            string binTextSerbich = "";

                            var textChr = Encoding.UTF8.GetBytes(spainText);
                            foreach (int chr in textChr)
                            {
                                binTextSpain += Convert.ToString(chr, 2).PadLeft(8, '0');
                            }

                            textChr = Encoding.UTF8.GetBytes(serbichText);
                            foreach (int chr in textChr)
                            {
                                binTextSerbich += Convert.ToString(chr, 2).PadLeft(8, '0');
                            }

                            Dictionary<char, int> spainDict = spainChecker.alphabetListToDictionary();
                            Dictionary<char, int> serbichDict = serbichChecker.alphabetListToDictionary();

                            spainChecker.getSymbolsCounts(binTextSpain, spainDict);
                            serbichChecker.getSymbolsCounts(binTextSerbich, serbichDict);

                            Dictionary<char, double> chancesSpain = spainChecker.getSymbolsChances(binTextSpain, spainDict);
                            Dictionary<char, double> chancesSerbich = serbichChecker.getSymbolsChances(binTextSerbich, serbichDict);

                            spainChecker.computeTextEntropy(chancesSpain);
                            serbichChecker.computeTextEntropy(chancesSerbich);


                            spainChecker.printAlphabet();
                            spainChecker.printChances(chancesSpain);
                            spainChecker.printAlhabetEntropy();


                            serbichChecker.printAlphabet();
                            serbichChecker.printChances(chancesSerbich);
                            serbichChecker.printAlhabetEntropy();

                            double sumSpain = 0;
                            double sumSerbich = 0;
                            foreach (KeyValuePair<char, double> x in chancesSpain)
                            {
                                sumSpain += x.Value;
                            }
                            foreach (KeyValuePair<char, double> x in chancesSerbich)
                            {
                                sumSerbich += x.Value;
                            }

                            Console.WriteLine($"Сумма шансов для сербского языка: {sumSerbich}");
                            Console.WriteLine($"Сумма шансов для испанского языка: {sumSpain}");

                            ExcelDocumentCreator<char, double> excel = new ExcelDocumentCreator<char, double>(new System.IO.FileInfo(fileName));
                            excel.createWorksheet("second");
                            excel.addValuesFromDict(chancesSpain, "second", 0);
                            excel.addValuesFromDict(chancesSerbich, "second", 3);
                           

                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();

                            EntropyChecker spainChecker = new EntropyChecker(spainAlphabet, 0, "Испанский");
                            EntropyChecker serbichChecker = new EntropyChecker(serbichAlphabet, 0, "Сербский");
                            EntropyChecker spainCheckerBin = new EntropyChecker(new List<char>() { '0', '1' }, 0, "Бинарный код (испанский)");
                            EntropyChecker serbichCheckerBin = new EntropyChecker(new List<char>() { '0', '1' }, 0, "Бинарный код (сербский)");

                            string spainText = "kruglikalexeivictorovich";
                            string serbichText = "кругликалексейвикторович";

                            string binTextSpain = "";
                            string binTextSerbich = "";

                            var textChr = Encoding.UTF8.GetBytes(spainText);
                            foreach (int chr in textChr)
                            {
                                binTextSpain += Convert.ToString(chr, 2).PadLeft(8, '0');
                            }

                            textChr = Encoding.UTF8.GetBytes(serbichText);
                            foreach (int chr in textChr)
                            {
                                binTextSerbich += Convert.ToString(chr, 2).PadLeft(8, '0');
                            }

                            Dictionary<char, int> spainDict = spainChecker.alphabetListToDictionary();
                            Dictionary<char, int> serbichDict = serbichChecker.alphabetListToDictionary();
                            Dictionary<char, int> spainDictBin = spainCheckerBin.alphabetListToDictionary();
                            Dictionary<char, int> serbichDictBin = serbichCheckerBin.alphabetListToDictionary();

                            spainChecker.getSymbolsCounts(spainText, spainDict);
                            serbichChecker.getSymbolsCounts(serbichText, serbichDict);
                            spainCheckerBin.getSymbolsCounts(binTextSpain, spainDictBin);
                            serbichCheckerBin.getSymbolsCounts(binTextSerbich, serbichDictBin);

                            Dictionary<char, double> chancesSpain = spainChecker.getSymbolsChances(spainText, spainDict);
                            Dictionary<char, double> chancesSerbich = serbichChecker.getSymbolsChances(serbichText, serbichDict);
                            Dictionary<char, double> chancesSpainBin = spainCheckerBin.getSymbolsChances(binTextSpain, spainDictBin);
                            Dictionary<char, double> chancesSerbichBin = serbichCheckerBin.getSymbolsChances(binTextSerbich, serbichDictBin);

                            spainChecker.computeTextEntropy(chancesSpain);
                            serbichChecker.computeTextEntropy(chancesSerbich);
                            spainCheckerBin.computeTextEntropy(chancesSpainBin);
                            serbichCheckerBin.computeTextEntropy(chancesSerbichBin);


                            spainChecker.printAlphabet();
                            spainChecker.printChances(chancesSpain);
                            spainChecker.printAlhabetEntropy();

                            Console.WriteLine($"Количество информации сообщения. Язык - {spainChecker.AlphabetName}: {spainChecker.AlphabetEntropy *spainText.Length}");

                            serbichChecker.printAlphabet();
                            serbichChecker.printChances(chancesSerbich);
                            serbichChecker.printAlhabetEntropy();

                            Console.WriteLine($"Количество информации сообщения. Язык - {serbichChecker.AlphabetName}: {serbichChecker.AlphabetEntropy * serbichText.Length}");

                            spainCheckerBin.printAlphabet();
                            spainCheckerBin.printChances(chancesSpainBin);
                            spainCheckerBin.printAlhabetEntropy();

                            Console.WriteLine($"Количество информации сообщения. Язык - {spainCheckerBin.AlphabetName}: {spainCheckerBin.AlphabetEntropy * binTextSpain.Length}");

                            serbichCheckerBin.printAlphabet();
                            serbichCheckerBin.printChances(chancesSerbichBin);
                            serbichCheckerBin.printAlhabetEntropy();

                            Console.WriteLine($"Количество информации сообщения. Язык - {serbichCheckerBin.AlphabetName}: {serbichCheckerBin.AlphabetEntropy * binTextSerbich.Length}");


                            double sumSpain = 0;
                            double sumSerbich = 0;
                            double sumSpainBin = 0;
                            double sumSerbichBin = 0;
                            foreach (KeyValuePair<char, double> x in chancesSpain)
                            {
                                sumSpain += x.Value;
                            }
                            foreach (KeyValuePair<char, double> x in chancesSerbich)
                            {
                                sumSerbich += x.Value;
                            }

                            foreach (KeyValuePair<char, double> x in chancesSpainBin)
                            {
                                sumSpainBin += x.Value;
                            }
                            foreach (KeyValuePair<char, double> x in chancesSerbichBin)
                            {
                                sumSerbichBin += x.Value;
                            }

                            Console.WriteLine($"Сумма шансов для сербского языка: {sumSerbich}");
                            Console.WriteLine($"Сумма шансов для испанского языка: {sumSpain}");
                            Console.WriteLine($"Сумма шансов для сербского языка (бинарный): {sumSerbichBin}");
                            Console.WriteLine($"Сумма шансов для испанского языка (бинарный): {sumSpainBin}");

                            ExcelDocumentCreator<char, double> excel = new ExcelDocumentCreator<char, double>(new System.IO.FileInfo(fileName));
                            excel.createWorksheet("third");
                            excel.addValuesFromDict(chancesSpain, "third", 0);
                            excel.addValuesFromDict(chancesSerbich, "third", 3);
                            excel.addValuesFromDict(chancesSpainBin, "third", 5);
                            excel.addValuesFromDict(chancesSerbichBin, "third", 7);
                            


                            Console.ReadKey();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();

                            EntropyChecker spainCheckerBin = new EntropyChecker(new List<char>() { '0', '1' }, 0, "Бинарный код (испанский)");
                            EntropyChecker serbichCheckerBin = new EntropyChecker(new List<char>() { '0', '1' }, 0, "Бинарный код (сербский)");

                            string spainText = "kruglikalexeivictorovich";
                            string serbichText = "кругликалексейвикторович";

                            string binTextSpain = "";
                            string binTextSerbich = "";

                            var textChr = Encoding.UTF8.GetBytes(spainText);
                            foreach (int chr in textChr)
                            {
                                binTextSpain += Convert.ToString(chr, 2).PadLeft(8, '0');
                            }

                            textChr = Encoding.UTF8.GetBytes(serbichText);
                            foreach (int chr in textChr)
                            {
                                binTextSerbich += Convert.ToString(chr, 2).PadLeft(8, '0');
                            }

                            Dictionary<char, int> spainDictBin = spainCheckerBin.alphabetListToDictionary();
                            Dictionary<char, int> serbichDictBin = serbichCheckerBin.alphabetListToDictionary();

                            spainCheckerBin.getSymbolsCounts(binTextSpain, spainDictBin);
                            serbichCheckerBin.getSymbolsCounts(binTextSerbich, serbichDictBin);

                            Dictionary<char, double> chancesSpainBin = spainCheckerBin.getSymbolsChances(binTextSpain, spainDictBin);
                            Dictionary<char, double> chancesSerbichBin = serbichCheckerBin.getSymbolsChances(binTextSerbich, serbichDictBin);

                            spainCheckerBin.printAlphabet();
                            spainCheckerBin.printChances(chancesSpainBin);
                            spainCheckerBin.printAlhabetEntropy();
                            serbichCheckerBin.printAlphabet();
                            serbichCheckerBin.printChances(chancesSerbichBin);
                            serbichCheckerBin.printAlhabetEntropy();

                            Console.WriteLine($"Ошибка = 0.1. Количество информации сообщения. Язык - {spainCheckerBin.AlphabetName}: {spainCheckerBin.computeTextEntropyWithError(chancesSpainBin, 0.5) * binTextSpain.Length}");
                            Console.WriteLine($"Ошибка = 0.5. Количество информации сообщения. Язык - {spainCheckerBin.AlphabetName}: {spainCheckerBin.computeTextEntropyWithError(chancesSpainBin, 1) * binTextSpain.Length}");
                            Console.WriteLine($"Ошибка = 1. Количество информации сообщения. Язык - {spainCheckerBin.AlphabetName}: {spainCheckerBin.computeTextEntropyWithError(chancesSpainBin, 0.9) * binTextSpain.Length}");

                            Console.WriteLine($"Ошибка = 0.1. Количество информации сообщения. Язык - {serbichCheckerBin.AlphabetName}: {serbichCheckerBin.computeTextEntropyWithError(chancesSerbichBin,0.5) * binTextSpain.Length}");
                            Console.WriteLine($"Ошибка = 0.5. Количество информации сообщения. Язык - {serbichCheckerBin.AlphabetName}: {serbichCheckerBin.computeTextEntropyWithError(chancesSerbichBin, 1) * binTextSpain.Length}");
                            Console.WriteLine($"Ошибка = 1. Количество информации сообщения. Язык - {serbichCheckerBin.AlphabetName}: {serbichCheckerBin.computeTextEntropyWithError(chancesSerbichBin, 0.9) * binTextSpain.Length}");


                            Console.ReadKey();

                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
    }
}
