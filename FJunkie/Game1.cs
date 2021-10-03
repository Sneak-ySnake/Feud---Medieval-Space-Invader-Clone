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

        int currentLevel;

        Level1 level1;

        List<Enemy> killListEnemy = new List<Enemy>();
        List<Bullet> killListBullet = new List<Bullet>();

        Texture2D background;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            _graphics.HardwareModeSwitch = false;
            _graphics.GraphicsProfile = GraphicsProfile.Reach;
            if (GraphicsDevice == null)
                _graphics.ApplyChanges();
            
            _graphics.PreferredBackBufferWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            _graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = false;

            currentLevel = 0;

            playerObject = new Player(Content.Load<SoundEffect>("shootSoundWav"), Content.Load<Texture2D>("Sprite/Player/MedievalPlayer1"));

            level1 = new Level1(Content.Load<Texture2D>("Sprite/Enemy/MedievalEnemy"), Content.Load<Song>("Song/introSong"), currentLevel);
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("Sprite/Background/feudIntro");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (currentLevel == 0)
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    currentLevel = 1;
                    level1 = new Level1(Content.Load<Texture2D>("Sprite/Player/MedievalPlayer1"), Content.Load<Song>("Song/battleSong2"), currentLevel);
                }

            if (currentLevel == 1)
            {
                background = Content.Load<Texture2D>("Sprite/Background/feudPlayZone");
                if (level1.enemyListLevel1.Count == 0)
                {
                    currentLevel = 2;
                    level1 = new Level1(Content.Load<Texture2D>("Sprite/Player/MedievalPlayer1"), Content.Load<Song>("Song/endSong"), currentLevel);
                }

            }
            if (currentLevel == 2)
                background = Content.Load<Texture2D>("Sprite/Background/feudEnd");
            if (currentLevel == 3)
                background = Content.Load<Texture2D>("Sprite/Background/FeudGameOver");



            //mise à jour joueur
            playerObject.PlayerMovement(gameTime);
            playerObject.PlayerMouseMovement(gameTime);
            playerObject.PlayerFire(gameTime, Content.Load<Texture2D>("Sprite/Player/MedievalPlayerShoot"));
            if (playerObject.playerLife == 0)
                currentLevel = 3;

            //mise à jour ennemis
            foreach (Enemy enemy in level1.enemyListLevel1)
            {
                enemy.EnemyMovement(gameTime);
                enemy.EnemyFire(gameTime, Content.Load<Texture2D>("Sprite/Enemy/MedievalEnemyShoot"));
            }  

            //mise à jour tir
            foreach (Bullet a in playerObject.bulletList)
            {
                a.Shoot(gameTime);

                foreach (Enemy enemy1 in level1.enemyListLevel1)
                    if (a.shootCollision.Intersects(enemy1.enemyCollision))
                    {
                        killListEnemy.Add(enemy1);
                        killListBullet.Add(a);
                        playerObject.playerScore += 10;
                    }
            }

            //Suppression des ennemis touchés
            foreach (Enemy enemy in killListEnemy)
                level1.enemyListLevel1.Remove(enemy);

            //Suppression des tir qui ont touché
            foreach (Bullet bullet in killListBullet)
                playerObject.bulletList.Remove(bullet);

            foreach (Enemy enemy1 in level1.enemyListLevel1)
                foreach (Bullet b in enemy1.bulletList)
                {
                    b.Shoot(gameTime);
                    playerObject.PlayerCollision(b);
                }
            
            base.Update(gameTime);
           }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
                _spriteBatch.Draw(background, new Vector2(0,0), Color.White);
                _spriteBatch.Draw(Content.Load<Texture2D>("Sprite/Background/blackBar"), new Vector2(0, 0), Color.White);

            if (currentLevel==1)
            {
                _spriteBatch.Draw(playerObject.playerShip, playerObject.playerPosition, Color.White);
                _spriteBatch.DrawString(Content.Load<SpriteFont>("Font/File"), "Score :", new Vector2(1450, 5), Color.White);
                _spriteBatch.DrawString(Content.Load<SpriteFont>("Font/File"),playerObject.playerScore.ToString(), new Vector2(1600, 5), Color.White);

                foreach (Bullet a in playerObject.bulletList)
                    a.Draw(_spriteBatch);

                foreach (Enemy enemy1 in level1.enemyListLevel1)
                    foreach (Bullet b in enemy1.bulletList)
                        b.Draw(_spriteBatch);

                foreach (Enemy enemy in level1.enemyListLevel1)
                        _spriteBatch.Draw(enemy.enemyShip, enemy.enemyPosition, Color.White);

                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                    playerObject.playerShip = Content.Load<Texture2D>("Sprite/Player/MedievalPlayer1");
                if (Keyboard.GetState().IsKeyUp(Keys.Space))
                    playerObject.playerShip = Content.Load<Texture2D>("Sprite/Player/MedievalPlayer2");
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
