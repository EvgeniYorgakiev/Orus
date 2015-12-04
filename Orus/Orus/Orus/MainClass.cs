using System;

namespace Orus
{
#if WINDOWS || XBOX
    static class MainClass
    {
        static void Main(string[] args)
        {
            Orus.Instance.Run();
        }
    }
#endif
}

