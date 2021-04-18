using System;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;

namespace Proyek_UTS_Grafkom
{
    class Program
    {
        static void Main(string[] args)
        {
            var ourWindow = new NativeWindowSettings()
            {
                Size = new Vector2i(800,800),
                Title = "Proyek UTS"
            };

            using (var win = new Window(GameWindowSettings.Default, ourWindow) )
            {
                win.Run();
            }
        }
    }
}
