using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Demo63Assignment.Models.UtilityClass
{
    public class PaginatedList<T, K> : List<K>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public PaginatedList(List<K> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public bool PreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool NextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static async Task<PaginatedList<T, K>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize, IMapper _mapper)
        {
            var count = await source.CountAsync();
            var items = await _mapper.ProjectTo<K>(source).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T, K>(items, count, pageIndex, pageSize);
        }

    }
}
