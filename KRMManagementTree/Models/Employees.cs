using System;

namespace KRMManagementTree.Models
{
    public class Employees : IComparable<Employees>
    {
        // Model structure for employee

        // Id must be unique
        public int Id { get; set; }
        // employees name
        public string Name { get; set; }
        // identifies management hierarchy
        public int ManagerId { get; set; }

        // sorts in order based on managers id then name e.g. if two manager id's are the same, sort by name
        public int CompareTo(Employees other)
        {
            if (other.ManagerId < ManagerId && other.Id == 1)
                return 1;

            else if (other.ManagerId == ManagerId)
                return Name.CompareTo(other.Name);

            return 1;

        }

        // Would've also had some validation at the backend to account for extra security
        
    }
}
