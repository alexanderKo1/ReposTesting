using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace addressbook_testing
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allMails;
        //private string address;
        public ContactData()
        {
        }
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
        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        [Column(Name = "lastname")]
        public string SecondName { get; set; }
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }
        [Column(Name = "address")]
        public string Address { get; set; }
        [Column(Name = "home")]
        public string HomePhone { get; set; }
        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }
        [Column(Name = "email")]
        public string EMail1 { get; set; }
        [Column(Name = "email2")]
        public string EMail2 { get; set; }
        [Column(Name = "email3")]
        public string EMail3 { get; set; }
        [Column(Name = "work")]
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
        public string AllMails
        {
            get
            {
                if (allMails != null)
                {
                    return allMails;
                }
                else
                {
                    return NewLine(EMail1) + NewLine(EMail2) + NewLine(EMail3).Trim();
                }
            }
            set
            {
                allMails = value;
            }
        }

        public string NewLine(string eMail)
        {
            if (eMail == null || eMail == "")
            {
                return "";
            }
            return eMail + "\r\n";
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[- ()]", "") + "\r\n";

            //phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
            //Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
        public static List<ContactData> GetAllContacts()
        {
            using (AddressbookDB db = new AddressbookDB())
            {
                return (from c in db.Contacts select c).ToList();
            }
        }
    }
}
