using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAS.Interfaces
{
    public interface ICriptografia
    {
        byte[] CriptografarDados(byte[] dados);
        byte[] DescriptografarDados(byte[] dadosCriptografados);
    }
}
