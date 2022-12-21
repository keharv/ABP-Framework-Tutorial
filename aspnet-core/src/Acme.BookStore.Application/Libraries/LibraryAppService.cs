using Acme.BookStore.Permissions;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Libraries
{
    public class LibraryAppService :
        CrudAppService<
            Library, //The Book entity
            LibraryDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateLibraryDto>, //Used to create/update a book
        ILibraryAppService //implement the IBookAppService
    {
        public LibraryAppService(IRepository<Library, Guid> repository)
            : base(repository)
        {
            GetPolicyName = BookStorePermissions.Libraries.Default;
            GetListPolicyName = BookStorePermissions.Libraries.Default;
            CreatePolicyName = BookStorePermissions.Libraries.Create;
            UpdatePolicyName = BookStorePermissions.Libraries.Edit;
            DeletePolicyName = BookStorePermissions.Libraries.Delete;
        }
    }
}