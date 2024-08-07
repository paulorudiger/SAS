using SAS.Interfaces;
using System.Security.Cryptography;

namespace SAS.Criptografia
{
    public class Criptografia : ICriptografia
    {
        private readonly bool _isSimetrica;
        private readonly Aes _aes;
        private readonly RSA _rsa;

        public Criptografia(bool isSimetrica)
        {
            _isSimetrica = isSimetrica;

            if (_isSimetrica)
            {
                _aes = Aes.Create();
                _aes.Key = Convert.FromBase64String("IUuji2euszvQeyKXcDqiQARomCX3oM+5Xl6xALZxj/w="); // Defina sua chave simétrica
                _aes.IV = Convert.FromBase64String("qKEGjr/fJOH6uDnTWaPTZQ=="); // Defina seu vetor de inicialização
            }
            else
            {
                _rsa = RSA.Create();
                _rsa.ImportRSAPublicKey(Convert.FromBase64String("MIIBCgKCAQEAzU5TAl78UL7kgyNPKf8afxGdU7hnlwAfi5XgnVofzfbWgkeyMMizEcARNwXTrZnom3HR2RqMZgSa9FfZR6EcJ21VhxyUOZq6OgC1SCjgwpVBYABh8Lz2h6/KmGd5x8j8u4HZh33QBIWOG+97w0ZOMocJAGCgoGjCQ1yUyRtyQ78vEvbPB8zXrbLuScCfXtAHBzdYqhvz+2HdWieK4oACsicxY7ypDkM8Dxx224qxfZEUyg12+bGq+Plu684NPvVkc2+39nvMNNZLHfo8MSLIU6bvdSOvB9hgZQfwdGST0ko07xvNpofmBkAcavYRQeIB+b4UFoVyG/DgknrE/vYR8QIDAQAB"), out _);
                _rsa.ImportRSAPrivateKey(Convert.FromBase64String("MIIEogIBAAKCAQEAzU5TAl78UL7kgyNPKf8afxGdU7hnlwAfi5XgnVofzfbWgkeyMMizEcARNwXTrZnom3HR2RqMZgSa9FfZR6EcJ21VhxyUOZq6OgC1SCjgwpVBYABh8Lz2h6/KmGd5x8j8u4HZh33QBIWOG+97w0ZOMocJAGCgoGjCQ1yUyRtyQ78vEvbPB8zXrbLuScCfXtAHBzdYqhvz+2HdWieK4oACsicxY7ypDkM8Dxx224qxfZEUyg12+bGq+Plu684NPvVkc2+39nvMNNZLHfo8MSLIU6bvdSOvB9hgZQfwdGST0ko07xvNpofmBkAcavYRQeIB+b4UFoVyG/DgknrE/vYR8QIDAQABAoIBACPltQfuGcn4hrYTP21FaJmdN9gCn0I8yEc8zohU0MjPhxRCevqirQTGg3wObcOl7JD5ZsrCJJhV584faiNnHSgbqt+z9IrZ7gPkSc4zL5F2TXb+uiFAuQ5ig1cAiL+Q+ffDLYjOS8funjluN0KekV+uUrmZK5zAlG74yh8byG/ltppmXl8tarj2N8+sZruW0RN6+cSJvD7jkFepPWntM0geHMrZfgc49/gk6oZfbQOJYm3V80wFNiLqWx2lNNrPxNTU83V3lv63Bggf7ffLzEblM9YnTQDErds34S5/deTIjLOWBnwTy2vU8cDqD1ShEBRvxp5OlC7YmBDPTnShYq0CgYEA3Xs4PQmJtNco6X9KmxogCp2bX0O+ZleJtkBUC8B188dVjBvTq2eaoCrasWmHYftEGvcXwhG1qdWBEYirzoCi2C53Z+k4B46o9nTWzdWmZ4eoqYYinjvBVrHk/sdxfrmzbIghkvkbCTCET+XRPUrLarQR27wDnIT4ZHa476EMUE8CgYEA7U27HNPMMojzrA6HHtTWqjcS6Ns9Y0S5AUBC3Mfb9xKkrRnWbbeo6tzjGXvjd3odew8dRM1X18LWIJOJ2WgNQXAGZy/vpVInaodcQ2cV97EKNYFgTLw8PkTvxnuhMhauHiobC7zbNrJh+hkQiY5Na8lOaTuVXxBUTmm9Vkueqb8CgYB3A+zfl82A+RHKD5X2rN5E9hZ05cFd23JsFjtTqVN48Ue+J4HiHKVRplWoek2+0DfzyY3hwoR9Q/a8hlXUfPmE88tEcmWiYf3XmkeHimSGQ7bViff2UaP+Q1ALvP73GzEYhDqOcQAfOwwOpy9+IUAYEbV6/5htNmMIEWgllMQ6LwKBgFrkYPzjqtzYU+zdC6glgatkuNtzzgmNswblpDaIXpo+C9E5ikYwCIUc4edK6o9CuLP/0AggVrsPp5CGslARaLJdxDYVyEacNvi4rAAtJd7fcreXvFjn6HM5WFW/2Lgks8BeBEn0pkpG/PwcSZdGaCUWz+/CoK3uxTvbiGfbQwRlAoGAI1GbLHCSgdTC3g2Zk0Nb98evvgU2iczc9kBILAO9v1D2B+76iX+2QcEcYmAvYEsNmftTQFWs1l48WWokFC3pJmW6B9Z2XL4IPL0hUTbGbBavlscLF5r92AtIu0pjzy8NndiCtlKz3BLBlRFFKhWpLlbnbYENRv3E9iwxeVQhsSw="), out _);
            }
        }

        public byte[] CriptografarDados(byte[] dados)
        {
            if (_isSimetrica)
            {
                return CriptografarDadosSimetrico(dados);
            }
            else
            {
                return CriptografarDadosAssimetrico(dados);
            }
        }

        public byte[] DescriptografarDados(byte[] dadosCriptografados)
        {
            if (_isSimetrica)
            {
                return DescriptografarDadosSimetrico(dadosCriptografados);
            }
            else
            {
                return DescriptografarDadosAssimetrico(dadosCriptografados);
            }
        }

        private byte[] CriptografarDadosSimetrico(byte[] dados)
        {
            byte[] encrypted;
            ICryptoTransform encryptor = _aes.CreateEncryptor(_aes.Key, _aes.IV);
            using (var ms = new System.IO.MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    cs.Write(dados, 0, dados.Length);
                }
                encrypted = ms.ToArray();
            }
            return encrypted;
        }

        private byte[] DescriptografarDadosSimetrico(byte[] dadosCriptografados)
        {
            byte[] decrypted;
            ICryptoTransform decryptor = _aes.CreateDecryptor(_aes.Key, _aes.IV);
            using (var ms = new System.IO.MemoryStream(dadosCriptografados))
            {
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (var msDecrypted = new System.IO.MemoryStream())
                    {
                        cs.CopyTo(msDecrypted);
                        decrypted = msDecrypted.ToArray();
                    }
                }
            }
            return decrypted;
        }

        private byte[] CriptografarDadosAssimetrico(byte[] dados)
        {
            return _rsa.Encrypt(dados, RSAEncryptionPadding.OaepSHA256);
        }

        private byte[] DescriptografarDadosAssimetrico(byte[] dadosCriptografados)
        {
            return _rsa.Decrypt(dadosCriptografados, RSAEncryptionPadding.OaepSHA256);
        }
    }

}

