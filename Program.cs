// See https://aka.ms/new-console-template for more information
using SAS.Abstracoes;
using SAS.Criptografia;
using SAS.Interfaces;
using System.Security.Cryptography;
using System.Text;

//Console.WriteLine("Hello, World!");


Console.WriteLine("Escolha o tipo de criptografia:");
Console.WriteLine("1. Simétrica");
Console.WriteLine("0. Assimétrica");
int escolha = int.Parse(Console.ReadLine());

ICriptografia criptografia = new Criptografia(escolha == 1);

// Exemplo de uso com texto
Texto texto = new Texto { Mensagem = "Mensagem secreta" };
byte[] textoBytes = Encoding.UTF8.GetBytes(texto.Mensagem);
byte[] textoCriptografado = criptografia.CriptografarDados(textoBytes);
byte[] textoDescriptografado = criptografia.DescriptografarDados(textoCriptografado);
texto.Mensagem = Encoding.UTF8.GetString(textoDescriptografado);

Console.WriteLine($"Texto Criptografado: {Convert.ToBase64String(textoCriptografado)}");
Console.WriteLine($"Texto Descriptografado: {texto.Mensagem}");

// Exemplo de uso com arquivo
Arquivo arquivo = new Arquivo { BytesArquivo = System.IO.File.ReadAllBytes("E:\\Facul\\SAS\\SAS\\ArquivoPCripto.txt") };
byte[] arquivoCriptografado = criptografia.CriptografarDados(arquivo.BytesArquivo);
File.WriteAllBytes("E:\\Facul\\SAS\\SAS\\ArquivoCriptografado.txt", arquivoCriptografado);

byte[] arquivoDescriptografado = criptografia.DescriptografarDados(arquivoCriptografado);

Console.WriteLine($"Arquivo Criptografado: {Convert.ToBase64String(arquivoCriptografado)}");
Console.WriteLine($"Arquivo Descriptografado: {Convert.ToBase64String(arquivoDescriptografado)}");

