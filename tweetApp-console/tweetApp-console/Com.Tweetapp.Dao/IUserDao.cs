using Com.Tweetapp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.Tweetapp.Dao
{
    interface IUserDao
    {
        AppUser UserLogin(string emailId, string password);
        string UserRegistration(AppUser user);
        string ResetPassword(string emailId, string oldPassword, string newPassword);
        string ForgotPassword(string emailId, string dob, string newPassword);
        List<AppUser> GetAppUsers();
    }
}
