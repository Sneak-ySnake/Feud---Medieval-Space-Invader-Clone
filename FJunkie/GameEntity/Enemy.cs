using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FJunkie.GameEntity
{
    class Enemy
    {
        public Texture2D enemyShip;
        public Vector2 enemyPosition;
        public Rectangle enemyCollision = new Rectangle();
        public float enemySpeed;

        public int enemyLimitLeft;
        public int enemyLimitRight;

        public List<Bullet> bulletList;

        public Enemy(Texture2D enemyShip, Vector2 enemyPosition, float enemySpeed, int enemyLimitLeft, int enemyLimitRight)
        {
            this.enemyShip = enemyShip;
            this.enemyPosition = enemyPosition;
            enemyCollision = new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, enemyShip.Width, enemyShip.Height);
            this.enemySpeed = enemySpeed;
            this.enemyLimitLeft = enemyLimitLeft;
            this.enemyLimitRight = enemyLimitRight;

            bulletList = new List<Bullet>();
        }

        public void EnemyMovement(GameTime gameTime)
        {
            enemyPosition.X += enemySpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (enemyPosition.X < enemyLimitLeft || enemyPosition.X > enemyLimitRight)
                enemySpeed = -enemySpeed;

            enemyCollision.X = (int)enemyPosition.X;
        }

        public void EnemyFire(GameTime gameTime, Texture2D enemyShoot)
        {
            Random r = new Random();
            int nextValue = r.Next(0, 100);

            if(nextValue==1)
            {
                bulletList.Add(new Bullet(enemyShoot, new Vector2(enemyPosition.X+enemyShip.Width/2, enemyPosition.Y), 400f));
            }
        }

        public void EnnemyCollision(Bullet bullet)
        {
            if (bullet.shootCollision.Intersects(enemyCollision))
                enemyPosition = new Vector2(10000, 0);
        }

    }
}
