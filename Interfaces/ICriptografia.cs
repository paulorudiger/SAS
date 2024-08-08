namespace SAS.Interfaces
{
    public interface ICriptografia
    {
        byte[] CriptografarDados(byte[] dados);
        byte[] DescriptografarDados(byte[] dadosCriptografados);
    }
}
