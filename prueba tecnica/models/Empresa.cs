using System.ComponentModel.DataAnnotations;

namespace prueba_tecnica.models
{
    public class Empresa
    {
        // Clave primaria de la empresa.
        [Key]
        public int cod_empresa { get; set; }

        // Número de RUC de la empresa.
        public string ruc { get; set; }

        // Razón social de la empresa.
        public string razon_social { get; set; }

        // Dirección física de la empresa.
        public string direccion { get; set; }

        // Indica si la empresa está activa o no.
        public bool Activo { get; set; }
    }
}