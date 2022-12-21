using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.Libraries
{
    public class LibraryManager : DomainService
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryManager(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        public async Task<Library> CreateAsync(
            [NotNull] string name,
            DateTime builtDate,
            [NotNull] string address = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingLibrary = await _libraryRepository.FindByNameAsync(name);
            if (existingLibrary != null)
            {
                throw new LibraryAlreadyExistsException(name);
            }

            return new Library(
                GuidGenerator.Create(),
                name,
                builtDate,
                address
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Library library,
            [NotNull] string newName)
        {
            Check.NotNull(library, nameof(library));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingLibrary = await _libraryRepository.FindByNameAsync(newName);
            if (existingLibrary != null && existingLibrary.Id != library.Id)
            {
                throw new LibraryAlreadyExistsException(newName);
            }

            library.ChangeName(newName);
        }
    }
}