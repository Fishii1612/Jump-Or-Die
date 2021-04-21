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
    public class Player
    {
        private Game1 game1;

        private Texture2D texture1;

        public Rectangle PlayerHitbox;

        public int PlayerPosY;

        public bool IsJumping = false;

        public int JumpCount = 0;
        public Player(Game1 game, Texture2D texture)
        {
            PlayerPosY = 300 - texture.Height;
            game1 = game;
            texture1 = texture;
        }
        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            PlayerHitbox = new Rectangle(game1.PlayerPosX, PlayerPosY, texture1.Width / 8, texture1.Height);

            if (keyboardState.IsKeyDown(Keys.Space) && IsJumping == false)
                IsJumping = true;
            if (IsJumping)
                Jump();
        }
        private void Jump()
        {
            if(JumpCount < 60)
            {
                JumpCount++;
                PlayerPosY--;
            }
            if(JumpCount >= 60 && JumpCount <= 120)
            {
                JumpCount++;
                PlayerPosY++;
            }
            if (JumpCount == 120)    //Reset
            {
                IsJumping = false;
                JumpCount = 0;
            }
        }
    }
}
