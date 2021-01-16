using System.Collections.Generic;

namespace Domain
{
    public class User : BaseItem
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public ICollection<Project> AssignedProjects { get; set; }
    }
}