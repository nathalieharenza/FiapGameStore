using GameStore.Entities;
using GameStore.Data;

namespace GameStore.Repositories;

public class JogoRepository : EfRepository<Jogo>, IJogoRepository
{
    public JogoRepository(ApplicationDbContext context) : base(context)
    {
    }
}

