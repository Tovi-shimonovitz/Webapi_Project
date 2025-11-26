using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MusicNamespace.Models;
using System.Security.Cryptography.X509Certificates;


namespace lesson4.interfaces;

public interface IMusicService
{
     List<Music> Get();
     Music Get(int id);
     Music Create(Music newMusic);
     int Update(int id, Music my_Music);
     bool Delete(int id);
}


