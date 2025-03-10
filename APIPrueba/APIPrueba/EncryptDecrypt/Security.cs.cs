using BusinessLogic;
using System;
using System.Security.Cryptography;
using System.Text;

namespace EncryptDecrypt
{
    public class Security : ISecurity_BL
    {
        // Clave pública en Base64 (PKCS#1 o SubjectPublicKeyInfo dependiendo de cómo la obtuviste)
        // Debe ser la misma que usaste originalmente para encriptar.
        private const string _publicKey = "MIIBCgKCAQEA+d0PF19h06Z66l31ROQjqkRo4PXfIVZyQGeaKpD1vw8lAUKnlTx9H/N07LMT8r5/isyszCjPCA5WvgHbyr7ZakQ9yPDHzI9HYKIkBUd4nCi3qwGI0KQpfB2a0Cq9+BYCzGIHEawybhYmlOhkLiKDnKnrQ4inBjeHc3nZPliieH73IJn3wuVl6pjkBHp1iT6+4FPQ/g0xc1s9RyGa3/TadZbKGaInyEbvLhU4XvtwoR7a0EnC7jKB24SqtlGGhiKKsMAKJr+YRahfEpTNcAw04kIAVU31fOlsQZv+mBV9bAjh4FBrQzvHdUgEoAMWqqK11BuD3SeDBfo08mq+UocK4QIDAQAB";

        // Clave privada en Base64, proveniente por ejemplo de una variable de entorno
        private readonly string _privateKey = Environment.GetEnvironmentVariable("privateKey");

        /// <summary>
        /// Genera un par de claves RSA (pública y privada) en Base64.
        /// Esto es opcional, sólo se usa si no tienes ya las llaves.
        /// </summary>
        public (string PublicKey, string PrivateKey) GenerateKeys()
        {
            using var rsa = RSA.Create(2048);
            var publicKey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
            var privateKey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
            return (publicKey, privateKey);
        }

        /// <summary>
        /// Cifra un texto largo usando un enfoque híbrido (AES+RSA).
        /// Retorna un solo string en Base64 que contiene:
        /// EncryptedKey|IV|EncryptedData (todo en Base64 y separado por '|')
        /// </summary>
        public string EncryptLongData(string plainText)
        {
            // 1. Crear clave AES
            using var aes = Aes.Create();
            aes.KeySize = 256;
            aes.GenerateKey();
            aes.GenerateIV();

            byte[] encryptedData;
            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                var plainBytes = Encoding.UTF8.GetBytes(plainText);
                encryptedData = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);
            }

            // 2. Cifrar la clave AES con RSA
            using var rsa = RSA.Create();
            // Asegúrate de utilizar el método correcto según el formato de tu clave pública
            // Si es SubjectPublicKeyInfo, usa rsa.ImportSubjectPublicKeyInfo
            // Si es una clave pública en formato raw PKCS#1, usa rsa.ImportRSAPublicKey
            rsa.ImportRSAPublicKey(Convert.FromBase64String(_publicKey), out _);


            var encryptedKey = rsa.Encrypt(aes.Key, RSAEncryptionPadding.OaepSHA256);

            // 3. Combinar todo en un solo string
            // Formato: EncryptedKeyBase64|IVBase64|EncryptedDataBase64
            var finalString =
                Convert.ToBase64String(encryptedKey) + "|" +
                Convert.ToBase64String(aes.IV) + "|" +
                Convert.ToBase64String(encryptedData);

            return finalString;
        }

        /// <summary>
        /// Descifra un string encriptado por EncryptLongData.
        /// Espera una cadena con el formato: EncryptedKeyBase64|IVBase64|EncryptedDataBase64
        /// Devuelve el texto original descifrado.
        /// </summary>
        public string DecryptLongData(string cipher)
        {
            var parts = cipher.Split('|');
            if (parts.Length != 3)
            {
                throw new ArgumentException("El texto cifrado no tiene el formato esperado.");
            }

            var encryptedKey = Convert.FromBase64String(parts[0]);
            var iv = Convert.FromBase64String(parts[1]);
            var encryptedData = Convert.FromBase64String(parts[2]);

            // 1. Descifrar la clave AES con RSA privada
            using var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(_privateKey), out _);
            var aesKey = rsa.Decrypt(encryptedKey, RSAEncryptionPadding.OaepSHA256);

            // 2. Descifrar los datos con AES
            using var aes = Aes.Create();
            aes.Key = aesKey;
            aes.IV = iv;

            using var decryptor = aes.CreateDecryptor();
            var decryptedBytes = decryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            var decryptedText = Encoding.UTF8.GetString(decryptedBytes);

            return decryptedText;
        }
    }
}
