using Microsoft.EntityFrameworkCore;
using Usuarios.Domain.Core.Data;
using Usuarios.Domain.Entities;
using Usuarios.Domain.Enumerations.Usuario;
using Usuarios.Domain.Interfaces;
using Usuarios.Infra.Data.PostgreSQL.Context;

namespace Usuarios.Infra.Data.PostgreSQL.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected readonly UsuariosContext Db;
        protected readonly DbSet<Usuario> DbSet;

        public IUnitOfWork UnitOfWork => Db;

        public UsuarioRepository(UsuariosContext context)
        {
            Db = context;
            DbSet = Db.Set<Usuario>();
        }

        public void Crear(Usuario modelo)
        {
            DbSet.Add(modelo);
        }

        public void Modificar(Usuario modelo)
        {
            DbSet.Update(modelo);
        }

        public void Eliminar(Usuario modelo)
        {
            DbSet.Remove(modelo);
        }

        public async Task<Usuario> BuscaPorId(Guid id)
        {
            return await DbSet.AsNoTracking().Where(item => item.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Usuario> BuscaPorIdPersona(Guid idPersona)
        {
            return await DbSet.AsNoTracking().Where(item => item.IdPersona == idPersona).FirstOrDefaultAsync();
        }

        public async Task<Usuario> BuscaPorNick(string nick)
        {
            return await DbSet.AsNoTracking().Where(item => item.Nick == nick).FirstOrDefaultAsync();
        }

        public async Task<IList<Usuario>> ObtieneUsuariosEstadoActivo()
        {
            return await DbSet.AsNoTracking().Where(item => item.Estado == EstadoEnum.ACTIVO.Name).ToListAsync();
        }

        public async Task<IList<Usuario>> ObtieneUsuariosEstadoInactivo()
        {
            return await DbSet.AsNoTracking().Where(item => item.Estado == EstadoEnum.INACTIVO.Name).ToListAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
