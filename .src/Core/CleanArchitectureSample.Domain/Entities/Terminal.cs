using System;
using System.Collections.Generic;

namespace CleanArchitectureSample.Domain.Entities
{
    public partial class Terminal
    {
        public Terminal()
        {
            TerminalPackages = new HashSet<TerminalPackage>();
        }

        public int Id { get; set; }
        public string Tid { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }

        public virtual ICollection<TerminalPackage> TerminalPackages { get; set; }
    }
}
