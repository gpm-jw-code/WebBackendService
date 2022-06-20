using System;
using Newtonsoft.Json;

namespace WebBackendService.Models.USER
{
    public class UserManager
    {

        internal const string USERS_DATA_SAVE_FOLDER = "Users";
        internal const string USERS_LIST_FILE_NAME = "UsersList.json";
        public static string USERS_LIST_FILE_FULL_NAME => Path.Combine(USERS_DATA_SAVE_FOLDER, USERS_LIST_FILE_NAME);

        public static List<User> UsersList = new List<User>();
        
        public static bool TryCreate(string accountName, string userName, string password, out string message, int level = 0)
        {
            message = "";
            if(UsersList.Any(u=>u.UserName==userName))
            {
                message = $"帳戶已經存在({userName})";
                return false;
            }

            User user = new User
            {
                AccountName = accountName,
                UserName = userName,
                Password = password,
                Level = level
            };
            UsersList.Add(user);
            SaveUsersList();
            return true;
        }

        public static bool TryValidation(User user, out int level, out string? message)
        {
            level = 0;
            message = default;
            var userExist = UsersList.FirstOrDefault(u => u.UserName == user.UserName);
            if (userExist == null)
            {
                message = "用戶不存在";
                return false;
            }

            if (userExist.Password != user.Password)
            {
                message = "密碼錯誤";
                return false;
            }
            level = userExist.Level;
            return true;
        }


        private static void SaveUsersList()
        {
            Directory.CreateDirectory(USERS_DATA_SAVE_FOLDER);
            File.WriteAllText(USERS_LIST_FILE_FULL_NAME, JsonConvert.SerializeObject(UsersList, Formatting.Indented));

        }
        internal static void LoadUsersList()
        {
            if (File.Exists(USERS_LIST_FILE_FULL_NAME))
                UsersList = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(USERS_LIST_FILE_FULL_NAME));
            else
            {
                SaveUsersList();
            }
        }
    }
}

