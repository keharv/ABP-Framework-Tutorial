using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Books
{
    public class LibraryLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
