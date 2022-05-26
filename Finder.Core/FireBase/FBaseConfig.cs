using FireSharp.Config;
using FireSharp.Interfaces;

namespace Finder_Core.FireBase
{
    public class FBaseConfig
    {
        internal static IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = ConnectionConstant.AuthSecret,
            BasePath = ConnectionConstant.BasePath,
        };

        internal static IFirebaseClient client = new FireSharp.FirebaseClient(config);


    }

}
