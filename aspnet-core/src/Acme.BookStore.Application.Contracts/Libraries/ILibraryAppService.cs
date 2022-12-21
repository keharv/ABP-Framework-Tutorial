using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Libraries
{
    public interface ILibraryAppService :
        ICrudAppService<
            LibraryDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateLibraryDto>
    {

    }
}
