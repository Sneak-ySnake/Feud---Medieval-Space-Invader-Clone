using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using FJunkie.GameEntity;

namespace FJunkie.GameEntity
{
    public class Bullet
    {

        public Texture2D shoot;
        public Vector2 shootPosition;
        public Rectangle shootCollision;

        public float bulletSpeed;

        public Bullet(Texture2D shoot, Vector2 shootPosition, float bulletSpeed)
        {
            this.shoot = shoot;
            this.shootPosition = shootPosition;
            this.bulletSpeed = bulletSpeed;
            shootCollision = new Rectangle((int)shootPosition.X, (int)shootPosition.Y, shoot.Width, shoot.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(shoot, shootPosition, Color.White);
        }

        public void Shoot(GameTime gameTime)
        {
            shootPosition.Y += bulletSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            shootCollision.Y = (int)shootPosition.Y;
            shootCollision.X = (int)shootPosition.X;
        }

    }
}
