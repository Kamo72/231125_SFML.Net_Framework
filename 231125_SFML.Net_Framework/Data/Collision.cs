using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _231109_SFML_Test
{

    public interface ICollision 
    {
    
    }

    public class Box : ICollision
    {
        public Vector2f position;
        public Vector2f size;

    }
    public class Circle : ICollision
    {
        public Vector2f position;
        public float radius;

    }
    public class Line : ICollision
    {
        public Vector2f positionFrom;
        public Vector2f positionTo;

    }
    public class Point : ICollision
    {
        public Vector2f position;

    }
    public class ThickLine : ICollision
    {
        public Vector2f positionFrom;
        public Vector2f positionTo;
        public float thickness;

    }

}
