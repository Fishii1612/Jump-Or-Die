using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Jump_or_die
{
    public class Obstacles
    {
        public List<Obstacle> ExistingObstacles = new List<Obstacle>();
        private Texture2D TObstacle;
        public int RandomObstaclesInterval = 0;
        private Game1 game1;
        public Obstacles(Game1 game, Texture2D texture)
        {
            game1 = game;
        }
        public void ObstacleUpdate()
        {
            if (RandomObstaclesInterval > 0)
                RandomObstaclesInterval--;

            if (RandomObstaclesInterval == 0)
            {
                AddObstacle();
                GenerateRandomObstaclesInterval();
            }
            KillObstacle();
            PositionUpdate();
        }
        private void GenerateRandomObstaclesInterval()
        {
            Random random = new Random();
            RandomObstaclesInterval = random.Next(120, 260);
        }
        private void AddObstacle()
        {
            ExistingObstacles.Add(new Obstacle(game1.screenWidth));
        }
        private void KillObstacle()
        {
            for(int i = 0; i < ExistingObstacles.Count; i++)
            {
                if(ExistingObstacles[i].Position < -100)
                {
                    ExistingObstacles.RemoveAt(i);
                }
            }
        }
        private void PositionUpdate()
        {
            for (int i = 0; i < ExistingObstacles.Count; i++)
                ExistingObstacles[i].Position--;
        }
    }
}
