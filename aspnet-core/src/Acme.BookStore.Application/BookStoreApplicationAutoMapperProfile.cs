using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.Libraries;
using AutoMapper;

namespace Acme.BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorLookupDto>();
        CreateMap<Library, LibraryLookupDto>();
        CreateMap<Library, LibraryDto>();
        CreateMap<CreateUpdateLibraryDto, Library>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
