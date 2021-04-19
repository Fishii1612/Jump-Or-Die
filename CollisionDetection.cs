using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Jump_or_die
{
    public class CollisionDetection
    {
        private Rectangle A;
        private Rectangle B;
        public CollisionDetection(Rectangle AA, Rectangle BB)
        {
            A = AA;
            B = BB;
        }
        public bool CollisionCheck()     //Thank you ManBeardGames -> https://manbeardgames.com/docs/tutorials/monogame-3-8/collision-detection/aabb-collision/
        {
            return A.Left < B.Right &&
            A.Right > B.Left &&
            A.Top < B.Bottom &&
            A.Bottom > B.Top;
        }
    }
}

