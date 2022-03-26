using System;

namespace FørsteSemesterEksamen
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Gameworld())
                game.Run();
        }
    }
}
