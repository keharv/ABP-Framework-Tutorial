using System;
using System.Threading.Tasks;
using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.Libraries;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore
{
    public class BookStoreDataSeederContributor
        : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;


        private readonly ILibraryRepository _libraryRepository;
        private readonly LibraryManager _libraryManager;
        

        public BookStoreDataSeederContributor(
            IRepository<Book, Guid> bookRepository,
            IAuthorRepository authorRepository,
            AuthorManager authorManager,
            ILibraryRepository libraryRepository,
            LibraryManager libraryManager)
        {
            _bookRepository = bookRepository;
            _libraryRepository = libraryRepository;
            _authorRepository = authorRepository;
            _authorManager = authorManager;
            _libraryManager = libraryManager;
        }

        public async Task SeedAsync(DataSeedContext context)
        {

            //clear the database

            if (await _bookRepository.GetCountAsync() > 0)
            {
                return;
            }

            var downtownIndianapolis = await _libraryRepository.InsertAsync(
                /*
                new Library
                {
                    Name = "Downtown Indianapolis",
                    Address = "40 E St. Clair St, Indianapolis, IN, 46204",
                    BuiltDate = new DateTime(1917, 4, 8)
                },
                autoSave: true*/
                await _libraryManager.CreateAsync(
                    "Downtown Indianapolis",
                    new DateTime(1917, 4, 8),
                    "40 E St. Clair St, Indianapolis, IN 46204"
                 )
            );


            var eastSideIndianapolis = await _libraryRepository.InsertAsync(
/*                new Library
                {
                    Name = "Indianapolis Public Library - East",
                    Address = "2822 E Washington St, Indianapolis, IN, 46201",
                    BuiltDate = new DateTime(1910, 8, 13)
                },
                autoSave: true*/
                await _libraryManager.CreateAsync(
                    "Indianapolis Public Library - East",
                    new DateTime(1910, 8, 13),
                    "2822 E Washington St, Indianapolis, IN, 46201"
                )
            );
            var orwell = await _authorRepository.InsertAsync(
                await _authorManager.CreateAsync(
                    "George Orwell",
                    new DateTime(1903, 06, 25),
                    "Orwell produced literary criticism and poetry, fiction and polemical journalism; and is best known for the allegorical novella Animal Farm (1945) and the dystopian novel Nineteen Eighty-Four (1949)."
                )
            );

            var douglas = await _authorRepository.InsertAsync(
                await _authorManager.CreateAsync(
                    "Douglas Adams",
                    new DateTime(1952, 03, 11),
                    "Douglas Adams was an English author, screenwriter, essayist, humorist, satirist and dramatist. Adams was an advocate for environmentalism and conservation, a lover of fast cars, technological innovation and the Apple Macintosh, and a self-proclaimed 'radical atheist'."
                )
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    AuthorId = orwell.Id, // SET THE AUTHOR
                    LibraryId = downtownIndianapolis.Id,
                    Name = "1984",
                    Type = BookType.Dystopia,
                    PublishDate = new DateTime(1949, 6, 8),
                    Price = 19.84f
                },
                autoSave: true
            );

            await _bookRepository.InsertAsync(
                new Book
                {
                    AuthorId = douglas.Id, // SET THE AUTHOR
                    LibraryId = eastSideIndianapolis.Id,
                    Name = "The Hitchhiker's Guide to the Galaxy",
                    Type = BookType.ScienceFiction,
                    PublishDate = new DateTime(1995, 9, 27),
                    Price = 42.0f
                },
                autoSave: true
            );
        }
    }
}