using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Timers;

namespace _231109_SFML_Test
{
    internal static class CameraManager
    {

        static CameraManager()
        {
            VideoManager.ChangedResolution += ChangedResolution;
            ChangedResolution(VideoManager.resolutionNow);
            shakeRand = new Random();
        }

        public static Vector2f position = new Vector2f(0f, 0f);
        public static float rotation = 0f;
        public static Vector2f size;

        static Vector2f positionShake = new Vector2f(0f, 0f);
        static float rotationShake = 0f;
        static float sizeShake = 1f;

        static Random shakeRand;
        static float shakeValue = 0f;
        const float shakeReduction = 0.2f;

        static void ChangedResolution(Vector2f resolution)
        {
            size = resolution;
        }

        public static void TranslateTransform(ref Transformable drawable)
        {
            float resolutionRatio = size.X / VideoManager.resolutionNow.X;

            drawable.Scale *= resolutionRatio * sizeShake;
            drawable.Rotation += rotation + rotationShake;
            drawable.Position += (position + size / 2f + positionShake) * sizeShake;
        }

        public static void ShakeProcess() 
        {
            float reduction = shakeReduction * 1f / VideoManager.fpsNow;
            shakeValue *= (1f - reduction);

            float posDir = (float)shakeRand.NextDouble() * 360f;
            float posLen = (float)shakeRand.NextDouble() * shakeValue;
            float rot = (float)shakeRand.NextDouble() * shakeValue / 10f;
            float size = (float)shakeRand.NextDouble() * shakeValue / 1000f + 1f;

            positionShake = new Vector2f(
                posLen * (float)Math.Cos(posDir / 180f * Math.PI),
                posLen * (float)Math.Sin(posDir / 180f * Math.PI)
                );
            rotationShake = rot;
            sizeShake = size;

        }
        public static void GetShake(float shakeValue)
        {
            CameraManager.shakeValue += shakeValue;
        }
    }
}
