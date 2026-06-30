namespace Cavex.Principal.API.RequestHelpers
{
    /// <summary>
    /// Estructura estandar para devolver resultados paginados desde los endpoints de consulta.
    /// </summary>
    /// <typeparam name="T">Tipo de DTO incluido en la pagina.</typeparam>
    public class PagedResponse<T>
    {
        /// <summary>
        /// Numero de pagina devuelto.
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// Cantidad maxima de elementos solicitados por pagina.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Total de registros que cumplen el filtro antes de aplicar paginacion.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// Elementos incluidos en la pagina actual.
        /// </summary>
        public IReadOnlyList<T> Items { get; set; } = [];
    }
}
