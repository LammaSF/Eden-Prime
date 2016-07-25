using System;
using System.Windows.Forms;

namespace EmojiHunter
{
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
        static void Main()
        {
            using (var game = new EmojiHunterGame("Spring", "Sagittarius"))
            {
                Application.Run(new MainMenu());
            }
                //// game.Run();
        }
    }
#endif
}
