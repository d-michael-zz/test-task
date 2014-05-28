using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            // Return true if precisely one row was inserted,
            // otherwise false
            return rowsAffected == 1;
        }
    }
}
