using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MyUserNamespace.Models;
using Myuser.Services;
using System.Security.Cryptography.X509Certificates;
using user.interfaces;



namespace lesson4.Controllers;
[ApiController]
    [Route("[controller]")]

    public class UserController:ControllerBase
    {

     IUserService service;

   public UserController(IUserService service)
   {
     this.service = service;
     }


[HttpGet()]
public ActionResult<IEnumerable<User>> Get()
{
     return service.Get();
}


[HttpGet("{id}")]
public ActionResult<User> Get(int id){

    var user = service.Get(id);
    if(user == null)
        return NotFound();

    return user;
}


[HttpPost]
public ActionResult Create (User newUser){
    var postedUser = service.Create(newUser);
    return CreatedAtAction(nameof(Create),new {id= postedUser.Id});

}

 [HttpPut("{id}")]
public ActionResult Update(int id, User my_user)
{
    var boolUser= service.Update(id, my_user);
    if(boolUser == 0)
        return NotFound();
    if( boolUser == 1)
        return BadRequest();
    return NoContent();   

}

 [HttpDelete("{id}")]
public ActionResult Delete(int id)
{
    var boolUser = service.Delete(id);
    if(boolUser == false)
         return NotFound();
    return NoContent();
}
    }


