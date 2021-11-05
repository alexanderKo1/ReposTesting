using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_testing
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string lastName;
        public ContactData(string firstName)
        {
            this.firstName = firstName;
        }
        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (FirstName == other.firstName && LastName == other.LastName);
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }
        public override string ToString()
        {
            return "FirstName = " + FirstName + "; LastName = " + LastName;
        }
        public int CompareTo(ContactData other)
        {
            int r1;
            int r2;

            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            r1 = FirstName.CompareTo(other.FirstName);
            r2 = LastName.CompareTo(other.LastName);

            if (r1 == 0)
            { 
                return r2;
            }
            return r1;
        }

        public string FirstName
            {
                get
                {
                    return firstName;
                }
                set
                {
                    firstName = value;
                }
            }
            public string LastName
            {
                get
                {
                    return lastName;
                }
                set
                {
                    lastName = value;
                }
            }
        }
}
