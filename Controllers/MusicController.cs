using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MusicNamespace.Models;
using lesson4.Services;
using System.Security.Cryptography.X509Certificates;
using lesson4.interfaces;



namespace lesson4.Controllers ;
[ApiController]
    [Route("[controller]")]

    public class MusicController:ControllerBase
    {

     IMusicService service;

   public MusicController(IMusicService service)
   {
     this.service = service;
     }


[HttpGet()]
public ActionResult<IEnumerable<Music>> Get()
{
     return service.Get();
}


[HttpGet("{id}")]
public ActionResult<Music> Get(int id){

    var music = service.Get(id);
    if(music == null)
        return NotFound();

    return music;
}


[HttpPost]
public ActionResult Create (Music newMusic){
    var postedMusic = service.Create(newMusic);
    return CreatedAtAction(nameof(Create),new {id= postedMusic.Id});

}

 [HttpPut("{id}")]
public ActionResult Update(int id, Music my_Music)
{
    var boolMusic= service.Update(id, my_Music);
    if(boolMusic == 0)
        return NotFound();
    if( boolMusic == 1)
        return BadRequest();
    return NoContent();   

}

 [HttpDelete("{id}")]
public ActionResult Delete(int id)
{
    var boolMusic = service.Delete(id);
    if(boolMusic == false)
         return NotFound();
    return NoContent();
}
    }


