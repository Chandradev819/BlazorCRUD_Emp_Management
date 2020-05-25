using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCRUD.ViewModel
{
    public class PaginatedEmpsViewModel<TEntity> where TEntity : class
    {
        public int ActualPage { get; private set; }

        public int ItemsPerPage { get; private set; }

        public long TotalItems { get; private set; }

        public int TotalPages { get; set; }

        public IEnumerable<TEntity> Data { get; private set; }

        public PaginatedEmpsViewModel(int pageIndex, int pageSize, long count, IEnumerable<TEntity> data)
        {
            ActualPage = pageIndex;
            ItemsPerPage = pageSize;
            TotalItems = count;
            TotalPages = (int)Math.Ceiling(((decimal)count / pageSize));
            Data = data;
        }
    }
}
