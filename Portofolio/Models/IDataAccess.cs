using System;
using System.Collections.Generic;


namespace Portofolio.Models
{
    public interface IDataAccess:IDisposable
    {
        List<User> ObtientTousLesUtilisateurs();
        User CreerUtilisateur(string nom, string identifiant, string motdepasse, TypeEnum type);

    }
}
