using Com.Tweetapp.Dao;
using Com.Tweetapp.Model;
using System;
using System.Drawing;
using Console = Colorful.Console;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace tweetApp_console
{
    class Program
    {
        static void Main(string[] args)
        {
            UserDao userDao = new UserDao();
            TweetDao tweetDao = new TweetDao();
            AppUser user = new AppUser();
            Color mainColor = Color.FromArgb(255, 73, 156, 255);
            Color appColor = Color.FromArgb(255, 100, 149, 237);
        l1: Console.Clear();
            Console.WriteLine("Tweet App", mainColor);
            Console.ForegroundColor = Color.White;
            if(user.Email == null)
            {
                Console.Write("\nHome\n\n1. Register\n2. Login\n3. Forgot Password\n4. Exit\n\nEnter your choice: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            try
                            {
                                AppUser newUser = new AppUser();
                                Console.WriteLine("\nUser Registration", appColor);
                            l2:  Console.Write("\nFirst Name (Required): ");
                                var fName = Console.ReadLine();
                                if(fName == "")
                                {
                                    Console.WriteLine("\nFirst Name is required...", Color.DarkRed);
                                    goto l2;
                                }
                                else
                                {
                                    newUser.FirstName = fName;
                                }
                                Console.Write("\nLast Name (Optional): ");
                                newUser.LastName = Console.ReadLine();
                            l3: Console.Write("\nGender (Required)\n1. Male\n2. Female\n3. Others\n\nEnter your choice: ");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        {
                                            newUser.Gender = "Male";
                                            break;
                                        }
                                    case "2":
                                        {
                                            newUser.Gender = "Female";
                                            break;
                                        }
                                    case "3":
                                        {
                                            newUser.Gender = "Others";
                                            break;
                                        }
                                    default:
                                        {
                                            Console.WriteLine("\nEnter a valid option...", Color.Yellow);
                                            goto l3;
                                        }
                                }
                                Console.Write("\nDOB (dd-MM-yyyy) (Optional): ");
                                var dob = Console.ReadLine();
                                if(dob != "")
                                {
                                    CultureInfo provider = new CultureInfo("en-IN");
                                    newUser.Dob = DateTime.ParseExact(dob, "dd-MM-yyyy", provider);
                                }
                            l4: Console.Write("\nEmail (Required): ");
                                var email = Console.ReadLine();
                                if (email == "")
                                {
                                    Console.WriteLine("\nEmail is required...", Color.DarkRed);
                                    goto l4;
                                }
                                else
                                {
                                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                                    Match match = regex.Match(email);
                                    if (match.Success)
                                    {
                                        newUser.Email = email;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nEnter valid email...", Color.DarkRed);
                                        goto l4;
                                    }
                                }
                            l5: Console.Write("\nPassword (Required): ");
                                Console.ForegroundColor = Color.Black;
                                var password = Console.ReadLine();
                                Console.ForegroundColor = Color.White;
                                if (password == "")
                                {
                                    Console.WriteLine("\nPassword is required...", Color.DarkRed);
                                    goto l5;
                                }
                                else
                                {
                                    newUser.Password = password;
                                }
                                var status = userDao.UserRegistration(newUser);
                                if(status == "Registration Successful...")
                                {
                                    Console.WriteLine("\n" + status, Color.LightGreen);
                                }
                                else
                                {
                                    Console.WriteLine("\n" + status, Color.DarkRed);
                                }
                                System.Threading.Thread.Sleep(1500);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\n" + e.Message, Color.DarkRed);
                                System.Threading.Thread.Sleep(1500);
                            }
                            goto l1;
                        }
                    case "2":
                        {
                            try
                            {
                                Console.WriteLine("\nUser Login", appColor);
                                Console.Write("\nEmail: ");
                                var email = Console.ReadLine();
                                Console.Write("Password: ");
                                Console.ForegroundColor = Color.Black;
                                var password = Console.ReadLine();
                                Console.ForegroundColor = Color.White;
                                user = userDao.UserLogin(email, password);
                                Console.WriteLine("\nLogin Successful...", Color.LightGreen);
                                System.Threading.Thread.Sleep(1500);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\n"+e.Message, Color.DarkRed);
                                System.Threading.Thread.Sleep(1500);
                            }
                            goto l1;
                        }
                    case "3":
                        {
                            try
                            {
                                Console.WriteLine("\nForgot Password", appColor);
                            l6: Console.Write("\nEmail (Required): ");
                                var email = Console.ReadLine();
                                if (email == "")
                                {
                                    Console.WriteLine("\nEmail is required...", Color.DarkRed);
                                    goto l6;
                                }
                                Console.Write("\nDOB (dd-MM-yyyy) (Leave it blank if not provided while registration): ");
                                var dob = Console.ReadLine();
                            l7: Console.Write("\nNew Password (Required): ");
                                Console.ForegroundColor = Color.Black;
                                var password = Console.ReadLine();
                                Console.ForegroundColor = Color.White;
                                if (password == "")
                                {
                                    Console.WriteLine("\nPassword is required...", Color.DarkRed);
                                    goto l7;
                                }
                                Console.Write("\nConfirm New Password (Required): ");
                                Console.ForegroundColor = Color.Black;
                                if (Console.ReadLine() == password)
                                {
                                    Console.ForegroundColor = Color.White;
                                    var status = userDao.ForgotPassword(email, dob, password);
                                    if (status == "Password reset successfully...")
                                    {
                                        Console.WriteLine("\n" + status, Color.LightGreen);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n" + status, Color.DarkRed);
                                    }
                                    System.Threading.Thread.Sleep(1500);
                                }
                                else
                                {
                                    Console.ForegroundColor = Color.White;
                                    password = "";
                                    Console.WriteLine("\nPasswords do not match...", Color.DarkRed);
                                    goto l7;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\n" + e.Message, Color.DarkRed);
                                System.Threading.Thread.Sleep(1500);
                            }
                            goto l1;
                        }
                    case "4":
                        {
                            Console.WriteLine("\nGoodbye...", appColor);
                            System.Threading.Thread.Sleep(1500);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\nEnter a valid option...", Color.Yellow);
                            System.Threading.Thread.Sleep(1500);
                            goto l1;
                        }
                }
            }
            else
            {
                Console.WriteLine("\nLogged in as " + user.FirstName + " " + user.LastName + "(" + user.Email + ")");
                Console.Write("\nDashboard\n\n1. Post a tweet\n2. View my tweets\n3. View all tweets\n4. View all users\n5. Reset Password\n6. Logout\n\nEnter your choice: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            try
                            {
                                Tweet newTweet = new Tweet();
                                Console.WriteLine("\nPost A Tweet\n", appColor);
                                Console.Write("Type your tweet: ");
                                var tweet = Console.ReadLine();
                                if (tweet != "")
                                {
                                    newTweet.UserId = user.UserId;
                                    newTweet.Text = tweet;
                                    newTweet.CreatedAt = DateTime.Now;
                                    var status = tweetDao.PostTweet(newTweet);
                                    if (status == "Posted Successfully...")
                                    {
                                        Console.WriteLine("\n" + status, Color.LightGreen);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n" + status, Color.DarkRed);
                                    }
                                    System.Threading.Thread.Sleep(1500);
                                }
                                else
                                {
                                    Console.WriteLine("\nNothing to post...", Color.Gray);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\n" + e.Message, Color.DarkRed);
                                System.Threading.Thread.Sleep(1500);
                            }
                            goto l1;
                        }
                    case "2":
                        {
                            try
                            {
                                List<Tweet> myTweets = tweetDao.ViewMyTweets(user.UserId);
                                CultureInfo provider = new CultureInfo("en-US");
                                Console.WriteLine("\nMy Tweets - (" + myTweets.Count +")\n", appColor);
                                foreach (Tweet tweet in myTweets)
                                {
                                    Console.Write(tweet.User.FirstName + " " + tweet.User.LastName, appColor);
                                    Console.Write(" - " + tweet.CreatedAt.ToString("F", provider), Color.Gray);
                                    Console.WriteLine("\n" + tweet.Text + "\n");
                                }
                                Console.Write("Press enter to go to Dashboard...");
                                Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\n" + e.Message, Color.DarkRed);
                                System.Threading.Thread.Sleep(1500);
                            }
                            goto l1;
                        }
                    case "3":
                        {
                            try
                            {
                                List<Tweet> allTweets = tweetDao.ViewAllTweets();
                                CultureInfo provider = new CultureInfo("en-US");
                                Console.WriteLine("\nAll Tweets - (" + allTweets.Count + ")\n", appColor);
                                foreach (Tweet tweet in allTweets)
                                {
                                    Console.Write(tweet.User.FirstName + " " + tweet.User.LastName, appColor);
                                    Console.Write(" - " + tweet.CreatedAt.ToString("F", provider), Color.Gray);
                                    Console.WriteLine("\n" + tweet.Text + "\n");
                                }
                                Console.Write("Press enter to go to Dashboard...");
                                Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\n" + e.Message, Color.DarkRed);
                                System.Threading.Thread.Sleep(1500);
                            }
                            goto l1;
                        }
                    case "4":
                        {
                            try
                            {
                                List<AppUser> allUsers = userDao.GetAppUsers();
                                Console.WriteLine("\nAll Users - (" + allUsers.Count + ")\n", appColor);
                                foreach (AppUser appUser in allUsers)
                                {
                                    Console.WriteLine(appUser.FirstName + " " + appUser.LastName, appColor);
                                    Console.WriteLine(appUser.Email + "\n", Color.Gray);
                                }
                                Console.Write("Press enter to go to Dashboard...");
                                Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\n" + e.Message, Color.DarkRed);
                                System.Threading.Thread.Sleep(1500);
                            }
                            goto l1;
                        }
                    case "5":
                        {
                            try
                            {
                                Console.WriteLine("\nReset Password", appColor);
                            l8: Console.Write("\nCurrent Password (Required): ");
                                Console.ForegroundColor = Color.Black;
                                var oldPassword = Console.ReadLine();
                                Console.ForegroundColor = Color.White;
                                if (oldPassword == "")
                                {
                                    Console.WriteLine("\nPassword is required...", Color.DarkRed);
                                    goto l8;
                                }
                            l9: Console.Write("\nNew Password (Required): ");
                                Console.ForegroundColor = Color.Black;
                                var password = Console.ReadLine();
                                Console.ForegroundColor = Color.White;
                                if (password == "")
                                {
                                    Console.WriteLine("\nPassword is required...", Color.DarkRed);
                                    goto l9;
                                }
                                Console.Write("\nConfirm New Password (Required): ");
                                Console.ForegroundColor = Color.Black;
                                if (Console.ReadLine() == password)
                                {
                                    Console.ForegroundColor = Color.White;
                                    var status = userDao.ForgotPassword(user.Email, oldPassword, password);
                                    if (status == "Password reset successfully...")
                                    {
                                        Console.WriteLine("\n" + status, Color.LightGreen);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\n" + status, Color.DarkRed);
                                    }
                                    System.Threading.Thread.Sleep(1500);
                                }
                                else
                                {
                                    Console.ForegroundColor = Color.White;
                                    password = "";
                                    Console.WriteLine("\nPasswords do not match...", Color.DarkRed);
                                    goto l9;
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("\n" + e.Message, Color.DarkRed);
                                System.Threading.Thread.Sleep(1500);
                            }
                            goto l1;
                        }
                    case "6":
                        {
                            user = new AppUser();
                            Console.WriteLine("\nLogged Out...", Color.LightGreen);
                            System.Threading.Thread.Sleep(1500);
                            goto l1;
                        }
                    default:
                        {
                            Console.WriteLine("\nEnter a valid option...", Color.Yellow);
                            System.Threading.Thread.Sleep(1500);
                            goto l1;
                        }
                }
            }
        }
    }
}
