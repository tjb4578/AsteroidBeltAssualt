﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    class ShotManager
    {
        public List<Sprite> Rocket = new List<Sprite>();
        private Rectangle screenBounds;

        private static Texture2D Texture;
        private static Rectangle InitialFrame;
        private static int FrameCount;
        private float rocketSpeed;
        private static int CollisionRadius;

        public RocketManager(
            Texture2D texture,
            Rectangle initialFrame,
            int frameCount,
            int collisionRadius,
            float RocketSpeed,
            Rectangle screenBounds)
        {
            Texture = texture;
            InitialFrame = initialFrame;
            FrameCount = frameCount;
            CollisionRadius = collisionRadius;
            this.rocketSpeed = shotSpeed;
            this.screenBounds = screenBounds;
        }

        public void FireRocket(
            Vector2 location,
            Vector2 velocity,
            bool playerFired)
        {
            Sprite thisRocket = new Sprite(
                location,
                Texture,
                InitialFrame,
                velocity);

            thisShot.Velocity *= shotSpeed;

            for (int x = 1; x < FrameCount; x++)
            {
                thisRocket.AddFrame(new Rectangle(
                    InitialFrame.X + (InitialFrame.Width * x),
                    InitialFrame.Y,
                    InitialFrame.Width,
                    InitialFrame.Height));
            }
            thisRocket.CollisionRadius = CollisionRadius;
            Shots.Add(thisRocket);

            if (playerFired)
            {

                SoundManager.PlayPlayerShot();
            }
            else
            {

                SoundManager.PlayEnemyShot();
            }
        }

        public void Update(GameTime gameTime)
        {
            for (int x = Shots.Count - 1; x >= 0; x--)
            {
                Shots[x].Update(gameTime);
                if (!screenBounds.Intersects(Shots[x].Destination))
                {
                    Shots.RemoveAt(x);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite shot in Shots)
            {
                shot.Draw(spriteBatch);
            }
        }


    }
}
