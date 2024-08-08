// See https://aka.ms/new-console-template for more information
using SAS.Abstracoes;
using SAS.Criptografia;
using SAS.Interfaces;
using System.Text;

//Console.WriteLine("Hello, World!");


Console.WriteLine("Escolha o tipo de criptografia:");
Console.WriteLine("1. Simétrica");
Console.WriteLine("0. Assimétrica");
int escolha = int.Parse(Console.ReadLine());

// criação da instância da classe criptografia baseada na escolha do usuário (assimetrica ou simetrica)
ICriptografia criptografia = new Criptografia(escolha == 1);

// Exemplo de uso com texto
Texto texto = new Texto { Mensagem = "Mensagem secreta" }; // Criação de um objeto Texto (Encapsulamento e Abstração)
byte[] textoBytes = Encoding.UTF8.GetBytes(texto.Mensagem); // Conversão do texto para bytes
byte[] textoCriptografado = criptografia.CriptografarDados(textoBytes); // Criptografia usando o método da interface
byte[] textoDescriptografado = criptografia.DescriptografarDados(textoCriptografado); // Descriptografia usando o método da interface
texto.Mensagem = Encoding.UTF8.GetString(textoDescriptografado); // Conversão dos bytes de volta para texto

// Exibindo resultados criptografados e descriptografados
Console.WriteLine($"Texto Criptografado: {Convert.ToBase64String(textoCriptografado)}");
Console.WriteLine($"Texto Descriptografado: {texto.Mensagem}");

// Exemplo de uso com arquivo
Arquivo arquivo = new Arquivo { BytesArquivo = System.IO.File.ReadAllBytes("E:\\Facul\\SAS\\SAS\\ArquivoPCripto.txt") }; // Criação de um objeto Arquivo
byte[] arquivoCriptografado = criptografia.CriptografarDados(arquivo.BytesArquivo); // Criptografia usando o método da interface
File.WriteAllBytes("E:\\Facul\\SAS\\SAS\\ArquivoCriptografado.txt", arquivoCriptografado); // Salvando o arquivo criptografado na mesma pasta

byte[] arquivoDescriptografado = criptografia.DescriptografarDados(arquivoCriptografado); // Descriptografia usando o método da interface

Console.WriteLine($"Arquivo Criptografado: {Convert.ToBase64String(arquivoCriptografado)}");
Console.WriteLine($"Arquivo Descriptografado: {Convert.ToBase64String(arquivoDescriptografado)}");

