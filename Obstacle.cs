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
        public Obstacle(int pos)
        {
            Position = pos;
        }
    }
}
