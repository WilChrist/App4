using System;
using System.Collections.Generic;
using System.Text;

namespace App4.Model
{
    class UserOperation
    {
        SQLite.SQLiteConnection database;

        public UserOperation(SQLite.SQLiteConnection _database)
        {
            database = _database;
        }
        //public UserOperation() { }

        public User FindUserByEmailAndPassword(String email,String password)
        {
            User s = (User)database.Find<User>(email);
            if (s != null && s.Password.Equals(password))
            {
                return s;
            }
            else
            {
                return null;
            }
        }

        public void AddUser(User s)
        {
            database.Insert(s);
        }
    }
}
