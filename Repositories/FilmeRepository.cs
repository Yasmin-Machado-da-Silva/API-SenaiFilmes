using api_filmes_senai.Domains;
using api_filmes_senai.Interfaces;
using API_Filmes_SENAI.Context;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_filmes_senai.Repositories
{
    public class FilmeRepository : IFilmeRepository

    {
        private readonly Filme_Context _context;
        public FilmeRepository(Filme_Context context)
        {
            _context = context;
        }
        public void Atualizar(Guid id, Filme filme)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id)!;
                if (filmeBuscado != null)
                {
                    filmeBuscado.Titulo = filme.Titulo;
                    filmeBuscado.IdGenero = filme.IdGenero;

                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Filme BuscarPorId(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id)!;

                return filmeBuscado;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(Filme novoFilme)
        {
            try
            {
                //Adiciona um novo genero na tabel Generos(BD)
                _context.Filme.Add(novoFilme);

                //Após o cadastro, salva as alterações(BD)
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filme.Find(id);
                if (filmeBuscado != null)
                {
                    _context.Filme.Remove(filmeBuscado);
                }
                _context.SaveChanges();


            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filme> Listar()
        {
            try
            {
                List<Filme> listaDeFilme = _context.Filme
                    .Include(g => g.Genero)
                    .Select(f=> new Filme
                    {
                        IdFilme = f.IdFilme,
                        Titulo = f.Titulo,

                        Genero= new Genero
                        {
                            IdGenero = f.IdGenero,
                            Nome = f.Genero!.Nome
                        }

                    })
                    .ToList();
                return listaDeFilme;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filme> ListarPorGenero(Guid idGenero)
        {
            throw new NotImplementedException();
        }
    }
}
