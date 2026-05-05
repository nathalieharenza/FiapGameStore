using GameStore.Entities;
using GameStore.Data;

namespace GameStore.Repositories;

public class UsuarioRepository : EfRepository<Usuario>, IUsuarioRepository
{
    public UsuarioRepository(ApplicationDbContext context) : base(context)
    {
    }
}

