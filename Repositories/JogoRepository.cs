using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroDeJogos.Entities;

namespace CadastroDeJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), new Jogo{Id = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"), Nome = "Fifa 21", Produtora = "EA", Preco = 200} }
            //{Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), new Jogo{Id = Guid.Parse("eb909ced-1862-4789-8641-1bba36c23db3"), Nome = "Fifa 20", Produtora = "EA", Preco = 150} }
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina -1) * quantidade).Take(quantidade).ToList());
        }
        
        public Task<Jogo> Obter(Guid id)
        {
            if(!jogos.ContainsKey(id)) return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }
        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //fecha a conexao com o banco
        }

    }
}