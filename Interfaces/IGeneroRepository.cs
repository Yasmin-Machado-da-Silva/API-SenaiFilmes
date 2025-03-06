using api_filmes_senai.Domains;

namespace api_filmes_senai.Interfaces
{
    /// <summary> 
    /// interface para genero: contrato
    /// toda classe que herdar (implementar) essa interface, deverá implementar todos os metodos definidos aqui dentro
    /// </summary>
    public interface IGeneroRepository
    {
        //CRUD Metodos
        //C create cadastrar um novo projeto
        //R READ listar todos os objetos
        //U Update alterar um objeto
        //D deleto um objeto

        //metodo = TipoDeRetorno NomeDoMetodo(Argumentos ou Parametros)

        void Cadastrar(Genero novoGenero);
            List<Genero> Listar();
        void Atualizar(Guid id, Genero genero);

        void Deletar (Guid id);

        Genero BuscarPorId(Guid id);
    }
}
