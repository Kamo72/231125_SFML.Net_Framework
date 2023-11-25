using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _231109_SFML_Test
{
    internal class GamemodeLogo : Gamemode
    {
        public GamemodeLogo(TotalManager tm) : base(tm, 60) { }

        const int logoTime = 6000;

        protected override void LogicProcess()
        {
            Time time = clock.ElapsedTime;
            int miliSec = time.AsMilliseconds();

            if (miliSec > logoTime) 
            {
                totalManager.SetGamemodeType(GamemodeType.MAIN_MENU);
            }
            Console.WriteLine(miliSec.ToString()  + "/"+ logoTime.ToString());
        }

        protected override void DrawProcess() 
        {
            Time time = clock.ElapsedTime;
            float logoTimeNow = time.AsMilliseconds();
           
            //밝기가 0 > 1 > 0으로 이동~
            float gammaRatio = 1f - Math.Abs(logoTimeNow - logoTime / 2f) / (logoTime / 2f) * 2f;
            byte rgbValue = (byte)(255 * gammaRatio);

            Vector2f res = VideoManager.resolutionNow;
            RectangleShape shape = new RectangleShape(res);
            shape.FillColor = new Color(rgbValue, rgbValue, rgbValue);
            DrawManager.uiTex[0].Draw(shape);

        }

    }
}
