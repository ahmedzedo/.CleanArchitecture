using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitectureSample.Infrastructure.Helpers
{
    public class Errors
    {
        public Dictionary<string, string> Items { get; private set; }

        public bool IsValid => Items.Count <= 0;

        public void AddError(string Name, string Message)
        {
            Items.Add(Name, Message);
        }
        public Errors()
        {
            Items = new Dictionary<string, string>();
        }
    }
}
