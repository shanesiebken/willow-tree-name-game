using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WillowTree.NameGame.Core.Models;

namespace WillowTree.NameGame.Core.Services
{
    public interface INameGameService
    {
        Task<Person[]> GetPeople();
    }

    public class NameGameService : INameGameService
    {
        private static readonly string DataUrl = "http://api.namegame.willowtreemobile.com";

        public async Task<Person[]> GetPeople()
        {
            return null;
        }
    }
}
