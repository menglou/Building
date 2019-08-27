﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class AESHelper
    {
        // AES密钥 AES加密位： 128位，加密模式：CBC， 填充模式：Zeros
        private byte[] keyArray = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10};
        private byte[] ivArray = new byte[] {0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a, 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x10};


        // AES 加密
        public byte[] AESEncrypt(string text)
        {
            byte[] data = Encoding.Unicode.GetBytes(text);
            SymmetricAlgorithm aes = Rijndael.Create();
            aes.Key = keyArray;
            aes.IV = ivArray;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.Zeros;
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                    cs.FlushFinalBlock();
                    byte[] cipherBytes = ms.ToArray(); // 得到加密后的字节数组
                    cs.Close();
                    ms.Close();
                    aes.Clear();
                    return cipherBytes;
                }
            }
        }

        // AES 解密
        public string AESDecrypt(byte[] data)
        {
            SymmetricAlgorithm aes = Rijndael.Create();
            aes.Key = keyArray;
            aes.IV = ivArray;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.Zeros;
            byte[] decryptBytes = new byte[data.Length];
            using (MemoryStream ms = new MemoryStream(data))
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    cs.Read(decryptBytes, 0, decryptBytes.Length);
                    cs.Close();
                    ms.Close();
                }
            }
            aes.Clear();
            return System.Text.Encoding.Unicode.GetString(decryptBytes).Replace("\0", " ");
        }
    }
}
