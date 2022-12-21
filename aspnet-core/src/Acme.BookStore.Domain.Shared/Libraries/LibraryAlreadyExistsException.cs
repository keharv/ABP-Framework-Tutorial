using Volo.Abp;

namespace Acme.BookStore.Libraries
{
    public class LibraryAlreadyExistsException : BusinessException
    {
        public LibraryAlreadyExistsException(string name)
            : base(BookStoreDomainErrorCodes.LibraryAlreadyExists)
        {
            WithData("name", name);
        }
    }
}