namespace Diplom_Anti_ice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Help")]
    public partial class Help
    {
        public int Id { get; set; }

        public Guid ID_Device { get; set; }

        public DateTime Date { get; set; }

        public virtual Device Device { get; set; }
    }
}
