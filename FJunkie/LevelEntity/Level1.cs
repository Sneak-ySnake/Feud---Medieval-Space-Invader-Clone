using System;
using System.Collections.Generic;
using System.Text;
using FJunkie.GameEntity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FJunkie.LevelEntity
{
    class Level1
    {

        public List<Enemy> enemyListLevel1;
        public Song songLevel1;
        public int currentLevel;

        public Level1(Texture2D enemyShip, Song songLevel1, int currentLevel)
        {
            this.songLevel1 = songLevel1;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(songLevel1);

            enemyListLevel1 = new List<Enemy>();
            if (currentLevel == 1)
            {
                //Groupe1
                for (int i = 200; i != 1200; i += 200)
                    enemyListLevel1.Add(new Enemy(enemyShip, new Vector2(i, 100), 350f, 75, 1700));

                for (int i = 200; i != 1200; i += 200)
                    enemyListLevel1.Add(new Enemy(enemyShip, new Vector2(i, 200), 350f, 75, 1700));
            }

        }

    }
}
