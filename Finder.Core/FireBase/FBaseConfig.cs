using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace Finder_Core.FireBase
{
    class FBaseConfig
    {
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "Oq74Wtm31h2KJQv4fqHgwIQTt7jhaODV4tDKc3eS",
            BasePath = "https://findteammateapplication-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;
    }
}
