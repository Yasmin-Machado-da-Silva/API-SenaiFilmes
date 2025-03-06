using api_filmes_senai.Domains;

namespace api_filmes_senai.Interfaces
{
    public interface IFilmeRepository
    {
        void Cadastrar(Filme novoFilme);
        List<Filme> Listar();
        void Deletar(Guid id);

        Filme BuscarPorId(Guid id);

        void Atualizar(Guid id, Filme filme);

        List<Filme> ListarPorGenero (Guid idGenero);
    }

}
