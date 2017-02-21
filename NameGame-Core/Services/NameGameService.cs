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
    public class NameGameService
    {
		private static readonly string DataUrl = "https://www.willowtreeapps.com/api/v1.0/profiles";

        public async Task<Profile[]> GetProfiles()
        {
            return null;
        }
    }
}
