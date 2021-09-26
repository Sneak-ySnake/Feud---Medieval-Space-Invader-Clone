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

        public Level1(Texture2D enemyShip, Song songLevel1)
        {
            this.songLevel1 = songLevel1;
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(songLevel1);

            enemyListLevel1 = new List<Enemy>();
            //Groupe1
            for (int i = 100; i != 600; i += 100)
                enemyListLevel1.Add(new Enemy(enemyShip, new Vector2(i, 100), 350f, 50, 800));

            for (int i = 100; i != 600; i += 100)
                enemyListLevel1.Add(new Enemy(enemyShip, new Vector2(i, 150), 350f, 50, 800));

            for (int i = 100; i != 600; i += 100)
                enemyListLevel1.Add(new Enemy(enemyShip, new Vector2(i, 200), 350f, 50, 800));

            for (int i = 100; i != 600; i += 100)
                enemyListLevel1.Add(new Enemy(enemyShip, new Vector2(i, 250), 350f, 50, 800));
            /*
            //Groupe2
            for (int i = 900; i != 1300; i += 100)
                enemyListLevel1.Add(new Enemy(enemyShip, new Vector2(i, 100), 350f, 850, 1700));

            for (int i = 900; i != 1300; i += 100)
                enemyListLevel1.Add(new Enemy(enemyShip, new Vector2(i, 150), 350f, 850, 1700));

            for (int i = 900; i != 1300; i += 100)
                enemyListLevel1.Add(new Enemy(enemyShip, new Vector2(i, 200), 350f, 850, 1700));

            for (int i = 900; i != 1300; i += 100)
                enemyListLevel1.Add(new Enemy(enemyShip, new Vector2(i, 250), 350f, 850, 1700));*/

        }

    }
}
