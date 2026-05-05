using GameStore.Entities;

namespace GameStore.Repositories;

public interface IRepository<T> where T : EntityBase
{
    IList<T> ObterTodos();
    T ObterPorId(Guid guid);
    void Cadastrar(T entidade);
    void Alterar(T entidade);
    void Deletar(Guid guid);
}

