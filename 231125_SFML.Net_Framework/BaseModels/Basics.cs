using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _231109_SFML_Test
{
    internal abstract class Entity : IDisposable
    {
        Gamemode gamemode;

        public Entity(Gamemode gamemode, Vector2f position, ICollision collision)
        {
            mask = collision;
            Position = position;
            Direction = 0f;
            
            this.gamemode = gamemode;
            gamemode.DisposablesAdd(this);
            gamemode.logicEvent += LogicProcess;
            gamemode.logicEvent += PhysicsProcess;
            gamemode.drawEvent += DrawProcess;
        }

        public float Direction;
        public Vector2f Position { 
            set 
            {
                if (mask is Box box)
                    box.Position = value;
                else if(mask is Circle circle)
                    circle.Position = value;
                else if(mask is Point point)
                    point.position = value;
                else
                    throw new NotImplementedException();
            }
            get
            {
                if (mask is Box box)
                    return box.Position;
                else if (mask is Circle circle)
                    return circle.Position;
                else if (mask is Point point)
                    return point.position;
                else
                    throw new NotImplementedException();
            } 
        }

        ICollision mask;

        protected abstract void LogicProcess();
        protected abstract void PhysicsProcess();
        protected abstract void DrawProcess();

        ~Entity() 
        {
            Dispose();
        }
        public void Dispose()
        {
            gamemode.DisposablesRemove(this);
            gamemode.logicEvent -= LogicProcess;
            gamemode.logicEvent -= PhysicsProcess;
            gamemode.drawEvent -= DrawProcess;
            GC.SuppressFinalize(this);
        }
    }

    internal abstract class Ui : RectangleShape
    {
        Gamemode gamemode;

        public Ui(Gamemode gamemode, Vector2f position, Vector2f size)
        {
            Position = position;
            Size = size;

            this.gamemode = gamemode;
            gamemode.DisposablesAdd(this);
            gamemode.logicEvent += LogicProcess;
            gamemode.logicEvent += ClickProcess;
            gamemode.drawEvent += DrawProcess;
        }

        public bool IsMouseOn()
        {
            Vector2f mousePos = (Vector2f)Mouse.GetPosition();
            FloatRect floatRect = this.GetGlobalBounds();
            bool IsOn = floatRect.Contains(mousePos.X, mousePos.Y);
            return IsOn;
        }

        protected abstract void DrawProcess();
        protected abstract void LogicProcess();

        bool pressedBefore = false;

        void ClickProcess()
        {
            if (pressedBefore == false)
                if (IsMouseOn())
                    if (Mouse.IsButtonPressed(Mouse.Button.Left))
                    {
                        Clicked?.Invoke();
                        pressedBefore = true;
                        return;
                    }
                
            pressedBefore = Mouse.IsButtonPressed(Mouse.Button.Left);
        }
        public event Action Clicked;

        ~Ui()
        {
            Dispose();
        }

        public new void Dispose()
        {
            gamemode.DisposablesRemove(this);
            gamemode.logicEvent -= LogicProcess;
            gamemode.logicEvent -= ClickProcess;
            gamemode.drawEvent -= DrawProcess;

            base.Dispose();
            GC.SuppressFinalize(this);
        }

    }

    internal abstract class Particle : Transformable, Drawable
    {
        public abstract void Draw(RenderTarget target, RenderStates states);

        public void Draw(RenderTarget target)
        {
            Draw(target, RenderStates.Default);
        }

    }

    internal abstract class Projectile : IDisposable
    {
        public ICollision mask;

        ~Projectile() { Dispose(); }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    internal abstract class Structure : IDisposable
    {
        public ICollision mask;

        ~Structure() { Dispose(); }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

}
