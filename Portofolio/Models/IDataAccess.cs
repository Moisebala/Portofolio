using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portofolio.Models
{
    public interface IDataAccess:IDisposable
    {
        List<User> ObtientTousLesUtilisateurs();
    }
}
