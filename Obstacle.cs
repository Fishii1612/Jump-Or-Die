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
    public class Obstacle
    {
        public int Position;
        public Rectangle ObstacleHitbox;
        private Texture2D texture1;
        public Obstacle(int pos, Texture2D texture)
        {
            Position = pos;
            texture1 = texture; 
        }
        public void Update()
        {
            Position--;
            ObstacleHitbox = new Rectangle(Position, 300 - texture1.Height, texture1.Width, texture1.Height);
        }
    }
}
