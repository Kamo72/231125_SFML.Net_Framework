using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _231109_SFML_Test
{
    internal static class InputManager
    {
        static InputManager() 
        {
            
        }

        public static void Init() 
        {
        }
        
        public static void DebugProcess()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                lock (Program.window)
                {
                    Console.WriteLine("bbbbbbbbbbbbbbbbbbbb");
                    Program.window.Close();
                }
            }

            
        }






    }
}
