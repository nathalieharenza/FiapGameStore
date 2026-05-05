using GameStore.Entities;
using GameStore.Data;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Repositories;

public class EfRepository<T> : IRepository<T> where T : EntityBase
{
    protected readonly DbSet<T> _dbSet;
    protected readonly ApplicationDbContext _context;

    public EfRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IList<T> ObterTodos()
    { 
        return _dbSet.ToList();
    }

    public T ObterPorId(Guid guid)
    {
        return _dbSet.FirstOrDefault(e => e.Id == guid)!;
    }

    public void Cadastrar(T entidade)
    {
        entidade.Id = Guid.NewGuid();
        _dbSet.Add(entidade);
        _context.SaveChanges();
    }

    public void Alterar(T entidade)
    {
       _dbSet.Update(entidade);
       _context.SaveChanges();
    }

    public void Deletar(Guid guid)
    {
        var entidade = ObterTodos().FirstOrDefault(e => e.Id == guid);
        if (entidade != null)
        {
            _dbSet.Remove(entidade);
            _context.SaveChanges();
        }
    }
}

