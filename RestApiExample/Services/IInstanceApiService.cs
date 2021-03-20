using RestApiExample.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestApiExample.Services
{
   public interface IInstanceApiService
    {
       Task<Synonim> GetInstanceAsync(string word);
    }
}
