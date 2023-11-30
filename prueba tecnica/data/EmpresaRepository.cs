using Microsoft.EntityFrameworkCore;
using prueba_tecnica.models;

namespace prueba_tecnica.data
{
    /// <summary>
    /// Clase de repositorio para interactuar con la entidad 'tbl_empresa' en la base de datos.
    /// </summary>
    public class EmpresaRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Constructor para inicializar el repositorio con el contexto de base de datos especificado.
        /// </summary>
        /// <param name="contexto">El contexto de base de datos.</param>
        public EmpresaRepository(AppDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Recupera todas las entidades Empresa de la base de datos.
        /// </summary>
        /// <returns>Una lista de entidades Empresa.</returns>
        public async Task<List<Empresa>> GetAll()
        {
            return await _context.tbl_empresa.ToListAsync();
        }
        /// <summary>
        /// Recupera una entidad Empresa específica por su ID de la base de datos.
        /// </summary>
        /// <param name="id">El ID de la entidad Empresa.</param>
        /// <returns>La entidad Empresa con el ID especificado.</returns>
        public async Task<Empresa> GetById(int id)
        {
            return await _context.tbl_empresa.FindAsync(id);
        }
        /// <summary>
        /// Crea una nueva entidad Empresa en la base de datos.
        /// </summary>
        /// <param name="empresa">La entidad Empresa que se va a crear.</param>
        public async Task Create(Empresa empresa)
        {
            _context.tbl_empresa.Add(empresa);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Actualiza una entidad Empresa existente en la base de datos.
        /// </summary>
        /// <param name="empresa">La entidad Empresa que se va a actualizar.</param>
        public async Task Update(Empresa empresa)
        {
            _context.Entry(empresa).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Elimina una entidad Empresa específica por su ID de la base de datos.
        /// </summary>
        /// <param name="id">El ID de la entidad Empresa que se va a eliminar.</param>
        public async Task Delete(int id)
        {
            var empresa = await _context.tbl_empresa.FindAsync(id);
            _context.tbl_empresa.Remove(empresa);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Comprueba si una entidad Empresa con el codEmpresa especificado ya existe en la base de datos.
        /// </summary>
        /// <param name="codEmpresa">El codEmpresa a verificar.</param>
        /// <returns>True si existe una entidad con el codEmpresa especificado, de lo contrario, false.</returns>
        public async Task<bool> ExistsCodEmpresa(int codEmpresa)
        {
            return await _context.tbl_empresa.AnyAsync(e => e.cod_empresa == codEmpresa);
        }
    }
}
