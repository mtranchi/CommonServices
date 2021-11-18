using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonServicesBackend.Bases
{
    public abstract class BaseAddedByEntity : BaseEntity
    {
        [Required, MaxLength(36)]
        public string AddedById { get; set; }
    }
}
