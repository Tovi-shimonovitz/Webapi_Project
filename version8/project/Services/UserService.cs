using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyUserNamespace.Models;
using System.Security.Cryptography.X509Certificates;
using user.interfaces;

namespace Myuser.Services;



public class UserService : IUserService
{
     private List<User> list;

    public UserService()
    {
        this.list = new List<User>{
             new User { Id = 1, Name = "Elchanan",age=25},
             new User { Id = 2, Name = "Yonatan"},
             new User { Id = 3, Name = "Meit"},
             new User { Id = 4, Name = "Daniel",age=48} 
        };
    }
    private User find(int id)
    {
        return list.FirstOrDefault(p => p.Id == id);
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
        return 2;

    }

    public bool Delete(int id)
    {
        var User = find(id);
        if (User == null)
            return false;

        list.Remove(User);
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

