using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        private string inputFilePath;
        private string outputFilePath;

        private byte[] _buffer;

        private byte Length_key = 32;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    inputFilePath = openFileDialog.FileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
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
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + "\n" + exception.StackTrace);
            }
        }
    }
}
