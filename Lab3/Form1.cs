using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private string inputFilePath;
        private string outputFilePath;
        private string inputFilePathForRSA;
        private string outputFilePathForRSA;
        private string privateKey = "private.key";
        private string publicKey = "public.key";

        private RSA rsa;

        private byte[] _buffer;

        private byte Length_key = 32;

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = publicKey;
            textBox4.Text = privateKey;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    inputFilePath = openFileDialog.FileName;
                }
            }

            uiInputFileName.Text = inputFilePath;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outputFilePath = saveFileDialog1.FileName;              
            }

            uiOutputFileName.Text = outputFilePath;
        }
        //asdfa
        private void uiEncryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                var watch = new Stopwatch();
                watch.Start();
                var InputStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);
                using (FileStream fstream = new FileStream(outputFilePath, FileMode.OpenOrCreate))//зчитуємо вміст файлу і записуємо в fstream
                {
                    _buffer = new byte[InputStream.Length];//ініціалізуємо масив байтів довжини яка зчиталась

                    InputStream.Read(_buffer, 0, _buffer.Length);//записуємо весь вміст байтів в буфер

                    var rc5 = new RC5.RC5(uiKeyField.Text, _buffer);

                    _buffer = rc5.Encrypte_RC5_CBC_Pad();//зашифрований вміст файлу

                    fstream.Position = 0;

                    fstream.Write(_buffer, 0, _buffer.Length);//записуємо вміст файлу
                }
                watch.Stop();
                textBox5.Text = "" + watch.ElapsedMilliseconds;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "\n" + exception.StackTrace);
            }
        }

        private void uiDecryptButton_Click(object sender, EventArgs e)
        {
            try
            {
                var watch = new Stopwatch();
                watch.Start();
                using (FileStream fstream = new FileStream(inputFilePath, FileMode.OpenOrCreate))
                {
                    _buffer = new byte[fstream.Length];

                    fstream.Read(_buffer, 0, _buffer.Length);

                    var rc5 = new RC5.RC5(uiKeyField.Text, _buffer);

                    _buffer = rc5.Decrypte_RC5_CBC_Pad();
                }

                using (FileStream fstream = new FileStream(outputFilePath, FileMode.OpenOrCreate))
                {
                    fstream.Write(_buffer, 0, _buffer.Length);
                }
                watch.Stop();
                textBox5.Text = "" + watch.ElapsedMilliseconds;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "\n" + exception.StackTrace);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    inputFilePathForRSA = openFileDialog.FileName;
                }
            }

            textBox3.Text = inputFilePathForRSA;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outputFilePathForRSA = saveFileDialog1.FileName;
            }

            textBox2.Text = outputFilePathForRSA;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            rsa = new RSA(publicKey, privateKey);
            rsa.MakeKey();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    publicKey = openFileDialog.FileName;
                }
            }

            textBox1.Text = publicKey;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    privateKey = openFileDialog.FileName;
                }
            }

            textBox4.Text = privateKey;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rsa = new RSA(publicKey, privateKey);
            var watch = new Stopwatch();
            watch.Start();
            rsa.EncryptFile(inputFilePathForRSA, outputFilePathForRSA);
            watch.Stop();
            textBox6.Text = "" + watch.ElapsedMilliseconds;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            rsa = new RSA(publicKey, privateKey);
            var watch = new Stopwatch();
            watch.Start();
            rsa.DecryptFile(inputFilePathForRSA, outputFilePathForRSA);
            watch.Stop();
            textBox6.Text = "" + watch.ElapsedMilliseconds;
        }
    }
}
