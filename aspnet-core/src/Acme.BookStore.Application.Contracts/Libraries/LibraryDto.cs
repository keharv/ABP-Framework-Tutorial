using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Libraries
{
    public class LibraryDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }
        public DateTime BuiltDate { get; set; }
        public string Address { get; set; }

    }
}
