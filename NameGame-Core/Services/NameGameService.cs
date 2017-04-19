using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WillowTree.NameGame.Core.Models;
using WillowTree.NameGame.Core.Interfaces;
using System.Diagnostics;

namespace WillowTree.NameGame.Core.Services
{
    public class NameGameService : INameGameService
    {
		private static readonly string DataUrl = "https://www.willowtreeapps.com/api/v1.0/profiles";
        private IEnumerable<Profile> Profiles;

        public NameGameService()
        {
        }

        public async Task<IEnumerable<Profile>> GetProfiles()
        {
            if (Profiles == null)
            {
                //Set up an anonymous type to be able to deserialize the json using newtonsoft json
                var definition = new { Items = new List<Profile>() };
                string data = await new HttpClient().GetStringAsync(DataUrl);
                //Deserialize using the anonymous type definition
                var items = JsonConvert.DeserializeAnonymousType(data,definition);
                Profiles = items.Items;
            }
            return Profiles;
        }

        public async Task<IEnumerable<Profile>> GetProfiles(string nameFilter)
        {
            var profiles = await GetProfiles();
            return profiles.Where(p => p.FirstName.Contains(nameFilter));
        }
    }
}
