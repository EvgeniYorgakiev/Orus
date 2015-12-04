using System;

namespace Orus
{
#if WINDOWS || XBOX
    static class MainClass
    {
        static void Main(string[] args)
        {
            using (Orus game = new Orus())
            {
                game.Run();     
                
            }
        }
    }
#endif
}

