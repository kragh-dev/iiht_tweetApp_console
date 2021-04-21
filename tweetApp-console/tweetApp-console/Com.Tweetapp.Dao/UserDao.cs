using System;
using System.Collections.Generic;
using System.Text;
using Com.Tweetapp.Model;
using System.Linq;

namespace Com.Tweetapp.Dao
{
    class UserDao : IUserDao
    {
        tweetAppDbContext tweetApp = new tweetAppDbContext();
        public AppUser UserLogin(string emailId, string password)
        {
            AppUser user = tweetApp.AppUser.Where(appUser => appUser.Email == emailId).FirstOrDefault();
            if (user != null)
            {
                if(user.Password == password)
                {
                    return user;
                }
                else
                {
                    throw new Exception("Incorrect password...");
                }
            }
            else
            {
                throw new Exception("No such user...");
            }
        }

        public string UserRegistration(AppUser user)
        {
            try
            {
                tweetApp.AppUser.Add(user);
                tweetApp.SaveChanges();
                return "Registration Successful...";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string ResetPassword(string emailId, string oldPassword, string newPassword)
        {
            AppUser user = tweetApp.AppUser.Where(appUser => appUser.Email == emailId).FirstOrDefault();
            if (user != null && user.Password == oldPassword)
            {
                try
                {
                    if (user.Password != newPassword)
                    {
                        user.Password = newPassword;
                        tweetApp.SaveChanges();
                        return "Password reset successfully...";
                    }
                    else
                    {
                        return "You cannot use the same password again...";
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else if (user != null && user.Password != oldPassword)
            {
                throw new Exception("Incorrect password...");
            }
            else
            {
                throw new Exception("No such user...");
            }
        }

        public string ForgotPassword(string emailId, string dob, string newPassword)
        {
            AppUser user = tweetApp.AppUser.Where(appUser => appUser.Email == emailId).FirstOrDefault();
            if(user != null)
            {
                try
                {
                    if(user.Password != newPassword)
                    {
                        user.Password = newPassword;
                        tweetApp.SaveChanges();
                        return "Password reset successfully...";
                    }
                    else
                    {
                        return "You cannot use the same password again...";
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }
            }
            else
            {
                throw new Exception("No such user...");
            }
        }

        public List<AppUser> GetAppUsers()
        {
            return tweetApp.AppUser.ToList();
        }
    }
}
