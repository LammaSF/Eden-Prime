namespace EmojiHunter
{
    using System;
    using System.Windows.Forms;

#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Startup
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            new EmojiHunterGame("Center", "Sagittarius").Run();
        }
    }
#endif
}
