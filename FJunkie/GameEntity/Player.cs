using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FJunkie.KeyboardEntity;
using Microsoft.Xna.Framework.Audio;

namespace FJunkie.GameEntity
{
    public class Player
    {

       public Texture2D playerShip;
       public Vector2 playerPosition = new Vector2(500,950);
       public float playerSpeed = 400f;
       public List<Bullet> bulletList;
       public SoundEffect shootSound;
       public Rectangle collision;

        public int playerLife;
        public int playerScore;
        
        public Player(SoundEffect shootSound, Texture2D playerShip)
        {
            this.shootSound = shootSound;
            bulletList = new List<Bullet>();
            this.playerShip = playerShip;
            collision = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerShip.Width, playerShip.Height);
            playerLife = 1;
            playerScore = 0;
        }

        public void PlayerMovement(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                playerPosition.X += playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                playerPosition.X -= playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void PlayerMouseMovement(GameTime gameTime)
        {  
            playerPosition.X = Mouse.GetState().X;
            collision.X = (int)playerPosition.X;
        }

        public void PlayerFire(GameTime gameTime, Texture2D shoot)
        {
            KeyboardEnt.GetState();
            if (KeyboardEnt.HasBeenPressed(Keys.Space) /*|| !(Mouse.GetState().LeftButton == ButtonState.Released)*/)
            {
                shootSound.Play();
                bulletList.Add(new Bullet(shoot, new Vector2(playerPosition.X+(playerShip.Width/2), playerPosition.Y+(playerShip.Height/2)-5), -600f));
            }
        }

        public void PlayerCollision(Bullet bullet)
        {
            if (bullet.shootCollision.Intersects(collision))
                playerLife -= 1;
        }

    }

    
}
