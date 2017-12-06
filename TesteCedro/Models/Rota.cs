using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TesteCedro.Services;

namespace TesteCedro.Models
{
    public class Rota : Operacao
    {

        public List<Produto> PegaProdutos()
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("DefautConnection");

            List<Produto> produtos = new List<Produto>();
            try
            {
                using (SqlConnection conexao = new SqlConnection(conexaoString))
                {
                    SqlCommand comando = new SqlCommand("SelecionaTodosProdutos", conexao);
                    comando.CommandType = CommandType.StoredProcedure;
                    conexao.Open();
                    SqlDataReader leitor = comando.ExecuteReader();
                    while (leitor.Read())
                    {
                        Produto produto = new Produto();
                        produto.IDProduto = Convert.ToInt32(leitor["IDProduto"]);
                        produto.Nome = leitor["Nome"].ToString();
                        produto.Descricao = leitor["Descricao"].ToString();
                        produto.Valor = Convert.ToInt32(leitor["Valor"]);
                        produto.Imagem = leitor["Imagem"].ToString();

                        produtos.Add(produto);
                    }
                }
                return produtos;
            }
            catch
            {
                throw;
            }
        }

        public void AdicionaProduto(Produto produto)
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());

            var conexaoString = configuration.GetConnectionString("DefautConnection");

            using (SqlConnection conexao = new SqlConnection(conexaoString))
            {
                try
                {

                    SqlCommand comando = new SqlCommand("InsereProduto", conexao);
                    comando.CommandType = CommandType.StoredProcedure;

                    SqlParameter parametroNome = new SqlParameter();
                    parametroNome.ParameterName = "@Nome";
                    parametroNome.Value = produto.Nome;
                    comando.Parameters.Add(parametroNome);

                    SqlParameter parametroDescricao = new SqlParameter();
                    parametroDescricao.ParameterName = "@Descricao";
                    parametroDescricao.Value = produto.Descricao;
                    comando.Parameters.Add(parametroDescricao);

                    SqlParameter parametroValor = new SqlParameter();
                    parametroValor.ParameterName = "@Valor";
                    parametroValor.Value = produto.Valor;
                    comando.Parameters.Add(parametroValor);

                    SqlParameter parametroImagem = new SqlParameter();
                    parametroImagem.ParameterName = "@Imagem";
                    parametroImagem.Value = produto.Imagem;
                    comando.Parameters.Add(parametroImagem);

                    conexao.Open();
                    comando.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }

        public void EditaProduto(Produto produto)
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());
            var conexaoString = configuration.GetConnectionString("DefautConnection");

            using (SqlConnection conexao = new SqlConnection(conexaoString))
            {
                try
                {

                    SqlCommand comando = new SqlCommand("EditaProduto", conexao);
                    comando.CommandType = CommandType.StoredProcedure;

                    SqlParameter parametroIDProduto = new SqlParameter();
                    parametroIDProduto.ParameterName = "@IDProduto";
                    parametroIDProduto.Value = produto.IDProduto;
                    comando.Parameters.Add(parametroIDProduto);

                    SqlParameter parametroNome = new SqlParameter();
                    parametroNome.ParameterName = "@Nome";
                    parametroNome.Value = produto.Nome;
                    comando.Parameters.Add(parametroNome);

                    SqlParameter parametroDescricao = new SqlParameter();
                    parametroDescricao.ParameterName = "@Descricao";
                    parametroDescricao.Value = produto.Descricao;
                    comando.Parameters.Add(parametroDescricao);

                    SqlParameter parametroValor = new SqlParameter();
                    parametroValor.ParameterName = "@Valor";
                    parametroValor.Value = produto.Valor;
                    comando.Parameters.Add(parametroValor);

                    SqlParameter parametroImagem = new SqlParameter();
                    parametroImagem.ParameterName = "@Imagem";
                    parametroImagem.Value = produto.Imagem;
                    comando.Parameters.Add(parametroImagem);

                    conexao.Open();
                    comando.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }

        public void ExcluiProduto(int id)
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());

            var conexaoString = configuration.GetConnectionString("DefautConnection");

            using (SqlConnection conexao = new SqlConnection(conexaoString))
            {

                try
                {

                    SqlCommand comando = new SqlCommand("ExcluiProduto", conexao);
                    comando.CommandType = CommandType.StoredProcedure;

                    SqlParameter parametroIDProduto = new SqlParameter();
                    parametroIDProduto.ParameterName = "@IDProduto";
                    parametroIDProduto.Value = id;
                    comando.Parameters.Add(parametroIDProduto);

                    conexao.Open();
                    comando.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
            }
        }

        public void DetalhaProduto(int id)
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());

            var conexaoString = configuration.GetConnectionString("DefautConnection");

            using (SqlConnection conexao = new SqlConnection(conexaoString))
                try
                {

                    SqlCommand comando = new SqlCommand("SelecionaProdutoEspecifico", conexao);
                    comando.CommandType = CommandType.StoredProcedure;

                    SqlParameter parametroIDProduto = new SqlParameter();
                    parametroIDProduto.ParameterName = "@IDProduto";
                    parametroIDProduto.Value = id;
                    comando.Parameters.Add(parametroIDProduto);

                    conexao.Open();
                    comando.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
        }

        public void CompraProduto(int id)
        {
            var configuration = ConfigurationHelper.GetConfiguration(Directory.GetCurrentDirectory());

            var conexaoString = configuration.GetConnectionString("DefautConnection");

            using (SqlConnection conexao = new SqlConnection(conexaoString))
                try
                {

                    SqlCommand comando = new SqlCommand("SelecionaProdutoEspecifico", conexao);
                    comando.CommandType = CommandType.StoredProcedure;

                    SqlParameter parametroIdProduto = new SqlParameter();
                    parametroIdProduto.ParameterName = "@IDProduto";
                    parametroIdProduto.Value = id;
                    comando.Parameters.Add(parametroIdProduto);

                    conexao.Open();
                    comando.ExecuteNonQuery();
                }
                catch
                {
                    throw;
                }
        }
    }

}
