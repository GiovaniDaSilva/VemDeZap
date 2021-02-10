using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace VemDeZap.Domain.Interfaces.Repositories.Base
{
    /*Classe foi retirada do Github: github.com/pauloanalista
      A mesma foi utilizada por ele no curso, sem muitas explicações, apenas foi utilizado.*/
    public interface IRepositoryBase<TEntidade, TId>
       where TEntidade : class
       where TId : struct
    {
        IQueryable<TEntidade> ListarPor(Expression<Func<TEntidade, bool>> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        IQueryable<TEntidade> ListarEOrdenadosPor<TKey>(Expression<Func<TEntidade, bool>> where, Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties);

        TEntidade ObterPor(Func<TEntidade, bool> where, params Expression<Func<TEntidade, object>>[] includeProperties);

        bool Existe(Func<TEntidade, bool> where);

        IQueryable<TEntidade> Listar(params Expression<Func<TEntidade, object>>[] includeProperties);

        IQueryable<TEntidade> ListarOrdenadosPor<TKey>(Expression<Func<TEntidade, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntidade, object>>[] includeProperties);

        TEntidade ObterPorId(TId id, params Expression<Func<TEntidade, object>>[] includeProperties);

        TEntidade Adicionar(TEntidade entidade);

        TEntidade Editar(TEntidade entidade);

        void Remover(TEntidade entidade);

        void AdicionarLista(IEnumerable<TEntidade> entidades);
    }
}
