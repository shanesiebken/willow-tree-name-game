using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WillowTree.NameGame.Core.Models;

namespace WillowTree.NameGame.Core.Interfaces
{
    public interface INameGameService
    {
        Task<IEnumerable<Profile>> GetProfiles();
        Task<IEnumerable<Profile>> GetProfiles(string nameFilter);
    }
}
