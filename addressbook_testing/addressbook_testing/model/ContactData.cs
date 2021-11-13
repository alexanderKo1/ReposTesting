using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_testing
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;

        public ContactData(string firstName)
        {
            FirstName = firstName;
        }
        public ContactData(string firstName, string secondName)
        {
            FirstName = firstName;
            SecondName = secondName;
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
            return (FirstName == other.FirstName && SecondName == other.SecondName);
        }
        public override int GetHashCode()
        {
            return FirstName.GetHashCode();
        }
        public override string ToString()
        {
            return "LastName = " + SecondName + "; FirstName = " + FirstName;
        }
        public int CompareTo(ContactData other)
        {
            int r1 = FirstName.CompareTo(other.FirstName);
            int r2 = SecondName.CompareTo(other.SecondName);

            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (r2 == 0)
            { 
                return r1;
            }
            return r2;
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Id { get; set; }

        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string AllPhones 
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else 
                {
                    return CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
    }
}
