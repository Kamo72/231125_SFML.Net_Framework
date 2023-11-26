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



            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                CameraManager.position.Y--;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                CameraManager.position.Y++;
            }


            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                CameraManager.position.X--;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                CameraManager.position.X++;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
            {
                CameraManager.rotation--;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.E))
            {
                CameraManager.rotation++;
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.R))
            {
                CameraManager.zoomValue *= 1.001f;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.F))
            {
                CameraManager.zoomValue /= 1.001f;
            }


        }






    }
}
