using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MusicNamespace.Models;
using System.Security.Cryptography.X509Certificates;
using lesson4.interfaces;
// using System.IO;
using System;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace lesson4.Services;



public class MusicService : IMusicService
{
    private List<Music> list ;
    private string filePath;


    public MusicService(IWebHostEnvironment webHost)
    {
        // this.list = new List<Music>{
        //      new Music { Id = 1, Name = "guittar",IsAccompanying=true},
        //      new Music { Id = 2, Name = "fiddle"},
        //      new Music { Id = 3, Name = "organ"},
        //      new Music { Id = 4, Name = "piano",IsAccompanying=false}
        // };
        
         this.filePath = Path.Combine(webHost.ContentRootPath, "Data", "Music.json");
         
            using (var jsonFile = File.OpenText(filePath))
            {
                var content = jsonFile.ReadToEnd();
                list = JsonSerializer.Deserialize<List<Music>>(content,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
    }
    private Music find(int id)
    {
        return list.FirstOrDefault(p => p.Id == id);
    }
    private void saveToFile()
    {
        var text = JsonSerializer.Serialize(list);
        File.WriteAllText(filePath, text);
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
        saveToFile();
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
         saveToFile();
        return 2;

    }

    public bool Delete(int id)
    {
        var Music = find(id);
        if (Music == null)
            return false;

        list.Remove(Music);
         saveToFile();
        return true;
    }


}
public static class MusicServiceExtension
{
    public static void AddMusicService(this IServiceCollection services)
    {
        services.AddSingleton<IMusicService, MusicService>();

    }
}

