using Microsoft.EntityFrameworkCore;
using Usuarios.Domain.Core.Data;
using Usuarios.Domain.Entities;
using Usuarios.Domain.Interfaces;
using Usuarios.Infra.Data.PostgreSQL.Context;

namespace Usuarios.Infra.Data.PostgreSQL.Repository
{
    public class LogRepository : ILogRepository
    {
        protected readonly UsuariosContext Db;
        protected readonly DbSet<Log> DbSet;

        public IUnitOfWork UnitOfWork => Db;

        public LogRepository(UsuariosContext context)
        {
            Db = context;
            DbSet = Db.Set<Log>();
        }

        public void Crear(Log modelo)
        {
            DbSet.Add(modelo);
        }

        public async Task<Log> BuscaPorId(Guid id)
        {
            return await DbSet.AsNoTracking().Where(item => item.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Log> BuscaPorIdUsuario(Guid idUsuario)
        {
            return await DbSet.AsNoTracking().Where(item => item.IdUsuario == idUsuario).FirstOrDefaultAsync();
        }

        public async Task<Log> ObtieneUltimaAccionReportadaUsuario(Guid id)
        {
            /*
            return await DbSet.AsNoTracking()
                .Where(item => item.Id == id)
                .OrderByDescending(item => item.FechaCreacion)
                .FirstOrDefaultAsync();             
             */

            return await DbSet.AsNoTracking()
                .Where(item => item.Id == id)
                .OrderByDescending(item => item.FechaCreacion)
                .FirstOrDefaultAsync();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
