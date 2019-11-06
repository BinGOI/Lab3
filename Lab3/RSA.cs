using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class RSA
    {
        public RSA(string PubKeyPath, string PrivKeyPath)
        {
            pubKeyPath = PubKeyPath;
            priKeyPath = PrivKeyPath;
        }

        readonly string pubKeyPath;
        readonly string priKeyPath;

        public void MakeKey()
        {
            //створюємо новий провайдер з довжиною ключа 2048 біт
            RSACryptoServiceProvider csp = new RSACryptoServiceProvider(2048);

            RSAParameters privKey = csp.ExportParameters(true);
            
            RSAParameters pubKey = csp.ExportParameters(false);
            //конвертація і запис ключів у файл
            string pubKeyString;
            {
                var sw = new StringWriter();
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                xs.Serialize(sw, pubKey);
                pubKeyString = sw.ToString();
                File.WriteAllText(pubKeyPath, pubKeyString);
            }
            string privKeyString;
            {
                var sw = new StringWriter();
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                xs.Serialize(sw, privKey);
                privKeyString = sw.ToString();
                File.WriteAllText(priKeyPath, privKeyString);
            }
        }
        public void EncryptFile(string inFilePath, string outFilePath)
        {
            //зчитуєм публічний ключ
            string pubKeyString;
            {
                using (StreamReader reader = new StreamReader(pubKeyPath)) { pubKeyString = reader.ReadToEnd(); }
            }
            
            var sr = new StringReader(pubKeyString);
            var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));

            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            csp.ImportParameters((RSAParameters)xs.Deserialize(sr));
            byte[] bytesPlainTextData = File.ReadAllBytes(inFilePath);

            var bytesCipherText = csp.Encrypt(bytesPlainTextData, false);
            string encryptedText = Convert.ToBase64String(bytesCipherText);
            File.WriteAllText(outFilePath, encryptedText);
        }
        public void DecryptFile(string inFilePath, string outFilePath)
        {

            RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
            string privKeyString;
            {
                privKeyString = File.ReadAllText(priKeyPath);
                var sr = new StringReader(privKeyString);
                var xs = new System.Xml.Serialization.XmlSerializer(typeof(RSAParameters));
                RSAParameters privKey = (RSAParameters)xs.Deserialize(sr);
                csp.ImportParameters(privKey);
            }
            string encryptedText;
            using (StreamReader reader = new StreamReader(inFilePath)) { encryptedText = reader.ReadToEnd(); }
            byte[] bytesCipherText = Convert.FromBase64String(encryptedText);

            byte[] bytesPlainTextData = csp.Decrypt(bytesCipherText, false);

            File.WriteAllBytes(outFilePath, bytesPlainTextData);
        }
    }
}
