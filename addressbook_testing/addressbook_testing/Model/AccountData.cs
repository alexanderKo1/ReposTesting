using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_testing
{
    public class AccountData //Данные о пользователе
    {
        private string username; //Поле. 
        private string password; 
        public AccountData (string username, string password) //Конструктор
        {
            this.username = username;
            this.password = password;
        }

        public string Username //Свойство для поля username
        {
            get 
            {
                return username;
            }
            set 
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }
    }
}
