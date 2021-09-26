using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using FJunkie.GameEntity;
using System.Collections.Generic;
using FJunkie.KeyboardEntity;
using FJunkie.LevelEntity;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace FJunkie
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Player playerObject;

        Level1 level1;
        
        Texture2D background;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            _graphics.HardwareModeSwitch = false;
            _graphics.GraphicsProfile = GraphicsProfile.Reach;
            if (GraphicsDevice == null)
                _graphics.ApplyChanges();
            
            _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width; ;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = false;
            playerObject = new Player(Content.Load<SoundEffect>("shootSoundWav"));
            level1 = new Level1(Content.Load<Texture2D>("enemyship"), Content.Load<Song>("song"));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            playerObject.playerShip = Content.Load<Texture2D>("playership");
            background = Content.Load<Texture2D>("background");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //mise à jour joueur
            playerObject.PlayerMovement(gameTime);
            playerObject.PlayerFire(gameTime, Content.Load<Texture2D>("playershoot"));

            //mise à jour ennemis
            foreach (Enemy enemy in level1.enemyListLevel1)
            {
                enemy.EnemyMovement(gameTime);
                enemy.enemyFire(gameTime, Content.Load<Texture2D>("enemyshoot"));
            }  

            //mise à jour tir
            foreach (Bullet a in playerObject.bulletList)
            {
                a.Shoot(gameTime);
               /* if (a.shootCollision.Intersects(enemyObject1.enemyCollision))
                {
                    enemyObject1.enemyPosition = new Vector2(-500, 0);
                    a.shootPosition = new Vector2(-500, 0);
                }*/
            }

            foreach (Enemy enemy1 in level1.enemyListLevel1)
                foreach (Bullet b in enemy1.bulletList)
                    b.Shoot(gameTime);

            base.Update(gameTime);
           }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
                _spriteBatch.Draw(background, new Vector2(0,0), Color.White);
                _spriteBatch.Draw(playerObject.playerShip, playerObject.playerPosition, Color.White);  

            foreach (Bullet a in playerObject.bulletList)
                        a.Draw(_spriteBatch);

            foreach (Enemy enemy1 in level1.enemyListLevel1)
                foreach (Bullet b in enemy1.bulletList)
                    b.Draw(_spriteBatch);

            foreach (Enemy enemy in level1.enemyListLevel1)
                _spriteBatch.Draw(enemy.enemyShip, enemy.enemyPosition, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
