using System;
using System.Collections.Generic;

namespace CleanArchitectureSample.Domain.Entities
{
    public partial class Attatchment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public int? PackageId { get; set; }

        public virtual Package Package { get; set; }
    }
}
