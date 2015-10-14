namespace CheckIn_Webservice
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

        public DateTimeOffset TimeStamp { get; set; }

        public int Student { get; set; }

        public virtual Student Student1 { get; set; }
    }
}
