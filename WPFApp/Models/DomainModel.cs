using System;

namespace WPFApp.Models
{
    public class DomainModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }

        public DomainModel(string name)
        {
            Name = name;
        }
    }
}
