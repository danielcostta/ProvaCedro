using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteCedro.Models
{
    interface Operacao
    {
        List<Produto> PegaProdutos();

        void AdicionaProduto(Produto produto);

        void EditaProduto(Produto produto);

        void ExcluiProduto(int id);

        void DetalhaProduto(int id);

        void CompraProduto(int id);

    }
}
