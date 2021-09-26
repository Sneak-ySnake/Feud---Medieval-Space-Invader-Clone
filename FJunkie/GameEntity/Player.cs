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
       public Vector2 playerPosition = new Vector2(500,800);
       public float playerSpeed = 200f;
       public List<Bullet> bulletList;
       public SoundEffect shootSound;
        
        public Player(SoundEffect shootSound)
        {
            this.shootSound = shootSound;
            bulletList = new List<Bullet>();
        }

        public void PlayerMovement(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                playerPosition.X += playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                playerPosition.X -= playerSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
             
             playerPosition.X = Mouse.GetState().X;
        }

        public void PlayerFire(GameTime gameTime, Texture2D shoot)
        {
            KeyboardEnt.GetState();
            if (KeyboardEnt.HasBeenPressed(Keys.Space) || !(Mouse.GetState().LeftButton == ButtonState.Released))
            {
                shootSound.Play();
                bulletList.Add(new Bullet(shoot, new Vector2(playerPosition.X, playerPosition.Y), -400f));
            }
        }

        public void PlayerFireUpdate()
        {
            
        }

    }

    
}
