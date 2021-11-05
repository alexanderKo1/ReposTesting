﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_testing
{
    public class EntryData : IEquatable<EntryData>, IComparable<EntryData>
    {
        private string firstName;
        private string lastName;
        public EntryData(string firstName)
        {
            this.firstName = firstName;
        }
        public EntryData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public bool Equals(EntryData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return firstName == other.firstName;
        }
        public override int GetHashCode()
        {
            return firstName.GetHashCode();
        }
        public override string ToString()
        {
            return "name = " + firstName;
        }
        public int CompareTo(EntryData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return firstName.CompareTo(other.firstName);
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
