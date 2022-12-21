using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;


namespace Acme.BookStore.Libraries
{
    public interface ILibraryRepository : IRepository<Library, Guid>
    {
        Task<Library> FindByNameAsync(string name);

        Task<List<Library>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}