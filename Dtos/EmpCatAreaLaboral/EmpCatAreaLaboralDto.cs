namespace Cavex.Principal.API.Dtos.EmpCatAreaLaboral
{
    public class EmpCatAreaLaboralDto
    {
        /// <summary>
        /// Representa un area laboral registrada en el catalogo.
        /// </summary>
        
            /// <summary>
            /// Identificador unico del area laboral.
            /// </summary>
            /// <example>1</example>
            public int Id { get; set; }

            /// <summary>
            /// Nombre o valor principal del area laboral.
            /// </summary>
            /// <example>Recursos Humanos</example>
            public string StrValor { get; set; } = string.Empty;

            /// <summary>
            /// Descripcion opcional del area laboral.
            /// </summary>
            /// <example>Area responsable de administracion de personal.</example>
            public string? StrDescripcion { get; set; }

            /// <summary>
            /// Identificador del estatus.
            /// </summary>
            /// <example>1</example>
            public int IdCatStatus { get; set; }
    }
}
