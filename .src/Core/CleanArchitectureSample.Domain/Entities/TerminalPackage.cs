using System;
using System.Collections.Generic;

namespace CleanArchitectureSample.Domain.Entities
{
    public partial class TerminalPackage
    {
        public int Id { get; set; }
        public int? TerminalId { get; set; }
        public int? PackageId { get; set; }

        public virtual Package Package { get; set; }
        public virtual Terminal Terminal { get; set; }
    }
}
