using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonServicesBackend.Bases
{
    public abstract class BaseTag : BaseAddedByEntity
    {
        [MaxLength(1024)]
        public string Description { get; set; }

        [Required, StringLength(64)]
        public string Name { get; set; }

        [Required, StringLength(64)]
        public string UrlSlug { get; set; }
    }
}
