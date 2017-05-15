using System.Collections.Generic;
using System.Linq;

namespace BankingLedgerWeb.Models
{
    public class UserHelper
    {
        public static int IdCounter = 1;
        public static List<User> AllUsers = new List<User>();
        public static bool IsLoggedIn = false;
        public static User CurrentUser = null;

        public static List<User> GetAll()
        {
            return AllUsers;
        }

        public static void AddNew(User newUser)
        {
            newUser.Id = IdCounter;
            IdCounter++;
            AllUsers.Add(newUser);
        }

        public static User FindById(int inputId)
        {
            return AllUsers.FirstOrDefault(u => u.Id == inputId);
        }

        public static User FindByName(string inputName)
        {
            return AllUsers.FirstOrDefault(u => u.Name == inputName);
        }

        public static bool UserNameAvailable(string inputUserName)
        {
            bool nameAvailable = true;

            foreach (User user in AllUsers)
            {
                if (user.Name == inputUserName)
                {
                    nameAvailable = false;
                }
            }

            return nameAvailable;
        }

        // Return true if login is successful
        public static bool Login(string inputUserName, string inputPassword)
        {
            User foundUser = UserHelper.FindByName(inputUserName);

            if (foundUser != null && foundUser.Password == inputPassword)
            {
                CurrentUser = foundUser;
                IsLoggedIn = true;
                return true;
            }
            else
            {
                IsLoggedIn = false;
                return false;
            }
        }

        public static void Logout()
        {
            CurrentUser = null;
            IsLoggedIn = false;
        }
    }
}
