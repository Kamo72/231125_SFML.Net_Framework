using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;

namespace _231109_SFML_Test
{
    internal class TotalManager
    {
        public TotalManager()
        {
            SetGamemodeType(GamemodeType.LOGO);
        }

        public void DrawAll() 
        {
            Font font = ResourceManager.fonts["Jalnan"];
            Text text = new Text(VideoManager.fpsNow.ToString(), font);
            text.Position = new Vector2f(VideoManager.resolutionNow.X - 200f, 0f);
            //text.Origin = new Vector2f(-110f, 0f);
            DrawManager.uiTex[1].Draw(text);

            //DrawManager.uiTex.Draw(new Sprite(ResourceManager.textures["smgIcon"]));


            gmNow?.DoDraw();

            CameraManager.ShakeProcess();
            DrawManager.ResultTexture();
        }

        public Gamemode gmNow;
        public GamemodeType gamemode = GamemodeType.NONE;
        public void SetGamemodeType(GamemodeType gamemode)
        {
            if (this.gamemode == gamemode) return;
            
            gmNow?.Dispose();
            //gmNow = null;
            this.gamemode = gamemode;

            switch (this.gamemode)
            {
                case GamemodeType.LOGO:
                    gmNow = new GamemodeLogo(this);
                    break;
                case GamemodeType.MAIN_MENU:
                    break;
                case GamemodeType.INGAME:
                    break;
                case GamemodeType.RESULT:
                    break;
            }
        }


    }

    public enum GamemodeType
    {
        NONE,
        LOGO,
        MAIN_MENU,
        INGAME,
        RESULT,
    }

}
