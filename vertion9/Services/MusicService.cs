using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MusicNamespace.Models;
using System.Security.Cryptography.X509Certificates;
using lesson4.interfaces;

namespace lesson4.Services;



public class MusicService : IMusicService
{
     private List<Music> list;

    public MusicService()
    {
        this.list = new List<Music>{
             new Music { Id = 1, Name = "guittar",IsAccompanying=true},
             new Music { Id = 2, Name = "fiddle"},
             new Music { Id = 3, Name = "organ"},
             new Music { Id = 4, Name = "piano",IsAccompanying=false} 
        };
    }
    private Music find(int id)
    {
        return list.FirstOrDefault(p => p.Id == id);
    }



    public List<Music> Get()
    {
        return list;
    }


      public Music Get(int id) => find(id);




    public Music Create(Music newMusic)
    {
        var maxId = list.Max(m => m.Id);
        newMusic.Id = maxId + 1;
        list.Add(newMusic);
        return newMusic;
    }

    public int Update(int id, Music my_Music)
    {
        var Music = find(id);
        if (Music == null)
            return 0;
        if (Music.Id != my_Music.Id)
        {

            return 1;
        }

        var index = list.IndexOf(Music);
        list[index] = my_Music;
        return 2;

    }

    public bool Delete(int id)
    {
        var Music = find(id);
        if (Music == null)
            return false;

        list.Remove(Music);
        return true;
    }
  

}
  public static class MusicServiceExtension
    {
        public static void AddMusicService(this IServiceCollection services)
        {
            services.AddSingleton<IMusicService , MusicService>();
                    
        }
    }

