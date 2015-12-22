namespace Orus
{
    using Core;

#if WINDOWS || XBOX
    static class MainClass
    {
        static void Main(string[] args)
        {
            OrusTheGame.Instance.Run();
        }
    }
#endif
}

