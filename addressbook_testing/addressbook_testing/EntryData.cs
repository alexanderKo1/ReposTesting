﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_testing
{
    class EntryData
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
