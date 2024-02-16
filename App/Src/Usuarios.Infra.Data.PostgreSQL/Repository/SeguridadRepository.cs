using Microsoft.EntityFrameworkCore;
using Usuarios.Domain.Core.Data;
using Usuarios.Domain.Entities;
using Usuarios.Domain.Interfaces;
using Usuarios.Infra.Data.PostgreSQL.Context;

namespace Usuarios.Infra.Data.PostgreSQL.Repository
{
    public class SeguridadRepository : ISeguridadRepository
    {
        protected readonly UsuariosContext Db;
        protected readonly DbSet<Seguridad> DbSet;

        public IUnitOfWork UnitOfWork => Db;

        public SeguridadRepository(UsuariosContext context)
        {
            Db = context;
            DbSet = Db.Set<Seguridad>();
        }

        public void Crear(Seguridad modelo)
        {
            DbSet.Add(modelo);
        }

        public void Modificar(Seguridad modelo)
        {
            DbSet.Update(modelo);
        }

        public async Task<Seguridad> BuscaPorId(Guid id)
        {
            return await DbSet.AsNoTracking().Where(item => item.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Seguridad> BuscaPorIdUsuario(Guid idUsuario)
        {
            return await DbSet.AsNoTracking().Where(item => item.IdUsuario == idUsuario).FirstOrDefaultAsync();
        }

        public async Task<int> ObtieneIntentosPorId(Guid id)
        {
            int intentos = 0; 
            var seguridad = await DbSet.AsNoTracking().Where(item => item.Id == id).FirstOrDefaultAsync();

            return intentos = (seguridad == null) ? 0 : seguridad.Intentos;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
