using IntegradorSofftek.DTOs;

namespace IntegradorSofftek.Helpers
{
    public class PaginateHelper
    {
        public static PaginateDataDTO<T> Paginate<T>(List<T> itemsToPaginate, int currentPage, string url)
        {
            int pageSize = 10;
            var totalItems = itemsToPaginate.Count();
            var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            var paginatedItems = itemsToPaginate.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            var prevUrl = currentPage > 1 ? $"{url}?page={currentPage - 1}" : null;
            var nextUrl = currentPage < totalPages ? $"{url}?page={currentPage + 1}" : null;

            return new PaginateDataDTO<T>
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalPages = totalPages,
                TotalItems = totalItems,
                PrevUrl = prevUrl,
                NextUrl = nextUrl,
                Items = paginatedItems
            };
        }
    }
}
