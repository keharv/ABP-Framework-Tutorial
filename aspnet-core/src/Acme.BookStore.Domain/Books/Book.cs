﻿using System;
using Volo.Abp.Domain.Entities.Auditing;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.BookStore.Books
{
    public class Book : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public BookType Type { get; set; }
        public DateTime PublishDate { get; set; }
        public float Price { get; set; }

        public Guid AuthorId { get; set; }

        public Guid LibraryId { get; set; }
    }
}
