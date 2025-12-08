using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyUserNamespace.Models;
using System.Security.Cryptography.X509Certificates;


namespace user.interfaces;

public interface IUserService
{
     List<User> Get();
     User Get(int id);
     User Create(User newMusic);
     int Update(int id, User my_Music);
     bool Delete(int id);
}