namespace Cavex.Principal.API.RequestHelpers
{
    /// <summary>
    /// Parametros comunes para consultas paginadas desde query string.
    /// </summary>
    public class Pagination
    {
        private const int MaxPageSize = 100;

        /// <summary>
        /// Numero de pagina solicitada. La primera pagina inicia en 1.
        /// </summary>
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 10;

        /// <summary>
        /// Cantidad de registros por pagina, limitada para evitar consultas demasiado grandes.
        /// </summary>
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }

        /// <summary>
        /// Texto opcional usado por las specifications para filtrar resultados.
        /// </summary>
        public string? Search { get; set; }
    }
}
