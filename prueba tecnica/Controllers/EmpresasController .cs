using Microsoft.AspNetCore.Mvc;
using prueba_tecnica.data;
using prueba_tecnica.models;

namespace prueba_tecnica.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresasController : ControllerBase
    {
        private readonly EmpresaRepository _empresaRepository;

        // Constructor que recibe una instancia de EmpresaRepository mediante inyección de dependencias.
        public EmpresasController(EmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        // Método HTTP GET para obtener todas las empresas.
        [HttpGet]
        public async Task<ActionResult<List<Empresa>>> GetEmpresas()
        {
            var empresas = await _empresaRepository.GetAll();
            return Ok(empresas);
        }

        // Método HTTP GET para obtener una empresa por su ID.
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(int id)
        {
            var empresa = await _empresaRepository.GetById(id);

            if (empresa == null)
            {
                return NotFound();
            }

            return Ok(empresa);
        }

        // Método HTTP POST para crear una nueva empresa.
        [HttpPost]
        public async Task<ActionResult<Empresa>> CreateEmpresa(Empresa empresa)
        {
            // Verificar si el cod_empresa ya existe en la base de datos.
            if (await _empresaRepository.ExistsCodEmpresa(empresa.cod_empresa))
            {
                ModelState.AddModelError("cod_empresa", "El código de empresa ya existe.");
                return BadRequest(ModelState);
            }

            await _empresaRepository.Create(empresa);

            return CreatedAtAction(nameof(GetEmpresa), new { id = empresa.cod_empresa }, empresa);
        }

        // Método HTTP PUT para actualizar una empresa por su ID.
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmpresa(int id, Empresa empresa)
        {
            if (id != empresa.cod_empresa)
            {
                return BadRequest();
            }

            try
            {
                await _empresaRepository.Update(empresa);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Método HTTP DELETE para eliminar una empresa por su ID.
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            try
            {
                await _empresaRepository.Delete(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
