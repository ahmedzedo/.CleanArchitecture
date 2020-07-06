using System;
using System.Collections.Generic;

namespace CleanArchitectureSample.Domain.Entities
{
    public partial class PackageConfigFile
    {
        public int Id { get; set; }
        public int? PackageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Package Package { get; set; }
    }
}
