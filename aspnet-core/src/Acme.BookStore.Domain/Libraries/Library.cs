using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Emailing;


namespace Acme.BookStore.Libraries
{
    public class Library : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BuiltDate { get; set; }
        
        private Library()
        {
            // this constructor is for deserialization / ORM purpose
        }

        internal Library(
            Guid id,
            [NotNull] string name,
            DateTime builtDate,
            [NotNull] string address)
        {
            SetName(name);
            Address = address;
            BuiltDate = builtDate;
        }

        internal Library ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: LibraryConsts.LibraryNameMaxLength);
        }

    }
}
