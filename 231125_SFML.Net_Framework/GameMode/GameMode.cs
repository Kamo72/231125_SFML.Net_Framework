using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Timers;

namespace _231109_SFML_Test
{
    internal abstract class Gamemode : IDisposable
    {
        protected TotalManager totalManager;

        //로직 타이머 시작
        public Gamemode(TotalManager tm, double logicFps)
        {
            totalManager = tm;
            this.logicFps = logicFps;

            timer = new Timer(1000d / logicFps);
            timer.Elapsed += (s, e) => {
                logicEvent?.Invoke();   //로직 처리 호출
            };
            timer.Start();

            clock = new Clock();
           
            logicEvent += LogicProcess;
            drawEvent += DrawProcess;
        }

        //로직 타이머 관련 변수
        readonly double logicFps;
        Timer timer;
        protected Clock clock;

        //로직, 드로우, 드로우 UI 등의 이벤트
        public event Action logicEvent;
        public event Action drawEvent;

        //TM에서 접근하는 드로우 이벤트
        public void DoDraw()
        {
            drawEvent?.Invoke();   //월드 드로우 처리 호출
        }

        protected abstract void LogicProcess();
        protected abstract void DrawProcess();

        //소멸자
        ~Gamemode() 
        {
            Dispose();
        }
        public void Dispose()
        {
            if (totalManager.gmNow == this) { totalManager.gmNow = null; }

            timer.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
