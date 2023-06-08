using System.Diagnostics;
using System.Numerics;

namespace LW12
{
    public partial class Form1 : Form
    {
        string selectedAlgorithm = "RSA";
        public Form1()
        {
            InitializeComponent();
            algorithmBox.SelectedIndex = 0;
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            resultBox.Text = "";
            if (selectedAlgorithm == "RSA")
            {
                RsaHelper rsa = new RsaHelper(101, 103);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                rsa.getSign(textBox.Text);
                string signCheck = rsa.checkSign();
                resultBox.Text += "�������� �������: " + signCheck + "\n";
                resultBox.Text += "��� ��������� ��������� H(m):" + textBox.Text.GetHashCode().ToString() + "\n";
                if (signCheck.Equals(textBox.Text.GetHashCode().ToString()))
                    resultBox.Text += "\n��������� ��������";
                else
                    resultBox.Text += "\n��������� �� ��������";

                stopWatch.Stop();
                timeLabel.Text = "�����: " + stopWatch.ElapsedMilliseconds + " ��";
            }
            else if (selectedAlgorithm == "Elgamal")
            {
                ElgamalHelper elgamal = new ElgamalHelper(2137, 2127, 1116, 7, 2119, 2136);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                var ya = BigInteger.ModPow(elgamal.y, elgamal.a, elgamal.p);
                var ab = BigInteger.ModPow(elgamal.a, elgamal.b, elgamal.p);
                var pr1 = BigInteger.ModPow(ya * ab, 1, elgamal.p);
                var pr2 = BigInteger.ModPow(elgamal.g, elgamal.H, elgamal.p);
                string resultStr;
                if (pr1 == pr2)
                    resultStr = "��������� ��������";
                else
                    resultStr = "��������� �� ��������";
                resultBox.Text += $"y^a * a^b: {pr1}\n" +
                    $"g^h mod p: {pr2}\n{resultStr}";

                stopWatch.Stop();
                timeLabel.Text = "�����: " + stopWatch.ElapsedMilliseconds + " ��";
            }
            else if (selectedAlgorithm == "Shnorr")
            {
                ShnorrHelper shnorr = new ShnorrHelper(2267, 103, 354, 967, 30, textBox.Text);
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                string result;
                if (shnorr.hash == shnorr.hash2)
                    result = "��������� ��������";
                else
                    result = "��������� �� ��������";
                resultBox.Text += $"h: {shnorr.hash}\n" +
                    $"H(��||x): {shnorr.hash2}\n{result}";

                stopWatch.Stop();
                timeLabel.Text = "�����: " + stopWatch.ElapsedMilliseconds + " ��";
            }
        }

        private void algorithmBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (algorithmBox.SelectedIndex)
            {
                case 0: selectedAlgorithm = "RSA"; break;
                case 1: selectedAlgorithm = "Elgamal"; break;
                case 2: selectedAlgorithm = "Shnorr"; break;
            }
        }
    }
}