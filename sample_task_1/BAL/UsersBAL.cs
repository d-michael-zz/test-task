using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSet1TableAdapters;

namespace BAL
{
    public class UsersBAL
    {
        private usersTableAdapter _usersAdapter = null;
        protected usersTableAdapter Adapter
        {
            get
            {
                if (_usersAdapter == null)
                    _usersAdapter = new usersTableAdapter();

                return _usersAdapter;
            }
        }


        [System.ComponentModel.DataObjectMethodAttribute
            (System.ComponentModel.DataObjectMethodType.Select, true)]
        public DAL.DataSet1.usersDataTable GetData()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethodAttribute
            (System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool AddUser(string email, string password)
        {
            // Create a new usersRow instance
            DAL.DataSet1.usersDataTable users = new DAL.DataSet1.usersDataTable();
            DAL.DataSet1.usersRow user = users.NewusersRow();

            user.email = email;
            user.password = password;

            // Add the new user
            users.AddusersRow(user);
            int rowsAffected = Adapter.Update(users);

            // Return true if  one row was inserted
            return rowsAffected == 1;
        }

        public List<string> GetUsersList()
        {
            List<string> users = new List<string>(); 
            DAL.DataSet1.usersDataTable grid = Adapter.GetData();

            foreach (DataRow row in grid.Rows)
            {
                users.Add(row[1].ToString());
            }
            return users;
        }

        public List<string> GetPassList()
        {
            List<string> pass = new List<string>(); 
            DAL.DataSet1.usersDataTable grid = Adapter.GetData();

            foreach (DataRow row in grid.Rows)
            {
                pass.Add(row[2].ToString());
            }
            return pass;
        }

    }
}
