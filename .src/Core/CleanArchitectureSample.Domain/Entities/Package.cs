using System;
using System.Collections.Generic;

namespace CleanArchitectureSample.Domain.Entities
{
    public partial class Package
    {
        public Package()
        {
            Attatchments = new HashSet<Attatchment>();
            PackageConfigFiles = new HashSet<PackageConfigFile>();
            TerminalPackages = new HashSet<TerminalPackage>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Attatchment> Attatchments { get; set; }
        public virtual ICollection<PackageConfigFile> PackageConfigFiles { get; set; }
        public virtual ICollection<TerminalPackage> TerminalPackages { get; set; }
    }
}
