using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.BookStore.Libraries
{
    public class CreateUpdateLibraryDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BuiltDate { get; set; } = DateTime.Now;
    }
}
