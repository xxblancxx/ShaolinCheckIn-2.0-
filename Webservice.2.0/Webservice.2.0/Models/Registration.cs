namespace Webservice._2._0
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registration")]
    public partial class Registration
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime TimeStamp { get; set; }

        public int Student { get; set; }

        public virtual Student Student1 { get; set; }
    }
}
