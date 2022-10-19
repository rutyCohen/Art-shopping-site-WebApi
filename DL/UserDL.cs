
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace DL
{
    public class UserDL : IUserDL

    {
        ArtAndCruftsContext __ArtAndCruftsContext;
        public UserDL(ArtAndCruftsContext __ArtAndCruftsContext)
        {
            this.__ArtAndCruftsContext = __ArtAndCruftsContext;
        }

        public async Task<User> Get(string email, string password)
        {
            //using (StreamReader reader = System.IO.File.OpenText("M:/WEB-API/Lesson1/Lesson1/FilePath.txt"))
            //{
            //    string currentUser;
            //    while ((currentUser = await reader.ReadLineAsync()) != null)
            //    {

            //        User user = JsonSerializer.Deserialize<User>(currentUser);
            //        if (user.Email == email && user.Password == password)
            //            return user;
            //    }
            //}
            //return null;
            var userToGet = await __ArtAndCruftsContext.Users.Where(u =>
             u.Email == email && u.Password == password).FirstOrDefaultAsync();
            if (userToGet == null)
                return null;
            return userToGet;
        }

        public async Task<User> Post(User user)
        {
            //int numberOfUsers = System.IO.File.ReadLines("M:/WEB-API/Lesson1/Lesson1/FilePath.txt").Count();
            //user.UserId = numberOfUsers + 1;
            //string userJson = JsonSerializer.Serialize(user);
            //await System.IO.File.AppendAllTextAsync("M:/WEB-API/Lesson1/Lesson1/FilePath.txt", userJson + Environment.NewLine);
            //return user.UserId;
            await __ArtAndCruftsContext.Users.AddAsync(user);
            await __ArtAndCruftsContext.SaveChangesAsync();
            return user;

        }

        public async Task Put(int id, User user)
        {
            //string textToReplace = "";
            //string filePath = "M:/WEB-API/Lesson1/Lesson1/FilePath.txt";
            //using (StreamReader reader = System.IO.File.OpenText(filePath))
            //{
            //    string currentUser;
            //    while ((currentUser = reader.ReadLine()) != null)
            //    {

            //        User u = JsonSerializer.Deserialize<User>(currentUser);
            //        if (u.UserId == id)
            //            textToReplace = currentUser;
            //    }
            //}

            //if (textToReplace != string.Empty)
            //{
            //    string text = await System.IO.File.ReadAllTextAsync(filePath);
            //    text = text.Replace(textToReplace, JsonSerializer.Serialize(user));
            //    await System.IO.File.WriteAllTextAsync(filePath, text);
            //}
            __ArtAndCruftsContext.Users.Update(user);
            await __ArtAndCruftsContext.SaveChangesAsync();


        }
    }
}
