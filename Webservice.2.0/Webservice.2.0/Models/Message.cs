namespace Webservice._2._0
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
            public int Id { get; set; }

            [Required]
            [StringLength(50)]
            public string Content { get; set; }

            public bool Frontpage { get; set; }

            public int Team { get; set; }

        public virtual Team Team1 { get; set; }
    }
}
