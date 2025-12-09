using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyUserNamespace.Models;
using System.Security.Cryptography.X509Certificates;
using user.interfaces;
using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace Myuser.Services;



public class UserService : IUserService
{
     private List<User> list;
 private string filePath;

    public UserService(IWebHostEnvironment webHost)
    {
        // this.list = new List<User>{
        //      new User { Id = 1, Name = "Elchanan",age=25},
        //      new User { Id = 2, Name = "Yonatan"},
        //      new User { Id = 3, Name = "Meit"},
        //      new User { Id = 4, Name = "Daniel",age=48} 
        // };

          this.filePath = Path.Combine(webHost.ContentRootPath, "Data", "User.json");
         
            using (var jsonFile = File.OpenText(filePath))
            {
                var content = jsonFile.ReadToEnd();
                list = JsonSerializer.Deserialize<List<User>>(content,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
    }
    private User find(int id)
    {
        return list.FirstOrDefault(p => p.Id == id);
    }

  private void saveToFile()
    {
        var text = JsonSerializer.Serialize(list);
        File.WriteAllText(filePath, text);
    }

    public List<User> Get()
    {
        return list;
    }


      public User Get(int id) => find(id);




    public User Create(User newUser)
    {
        var maxId = list.Max(m => m.Id);
        newUser.Id = maxId + 1;
        list.Add(newUser);
        saveToFile();
        return newUser;
    }

    public int Update(int id, User my_user)
    {
        var User = find(id);
        if (User == null)
            return 0;
        if (User.Id != my_user.Id)
        {

            return 1;
        }

        var index = list.IndexOf(User);
        list[index] = my_user;
        saveToFile();
        return 2;

    }

    public bool Delete(int id)
    {
        var User = find(id);
        if (User == null)
            return false;

        list.Remove(User);
        saveToFile();
        return true;
    }
  

}
  public static class UserServiceExtension
    {
        public static void AddUserService(this IServiceCollection services)
        {
            services.AddSingleton<IUserService , UserService>();
                    
        }
    }

