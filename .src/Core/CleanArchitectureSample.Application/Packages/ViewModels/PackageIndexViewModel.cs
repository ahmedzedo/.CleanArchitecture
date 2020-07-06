using CleanArchitectureSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureSample.Application.ViewModels
{
    public class PackageIndexViewModel
    {
        public PackageIndexViewModel()
        {
            Results = new List<Package>();
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Package> Results { get; set; } = new List<Package>();
    }
}
