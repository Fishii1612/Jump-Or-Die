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
        private Texture2D Texture;

        public int PlayerPosY;

        public bool IsJumping = false;
        public bool JumpUp = false;
        public bool JumpDown = false;

        public int JumpCount = 0;
        public Player(Texture2D texture)
        {
            Texture = texture;
            PlayerPosY = 300 - texture.Height;
        }
        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            if (keyboardState.IsKeyDown(Keys.Space) && IsJumping == false)
                IsJumping = true;
            if (IsJumping)
                Jump();

        }
        private void Jump()
        {
            if(JumpCount < 30)
            {
                JumpCount++;
                PlayerPosY--;
            }
            if(JumpCount >= 30 && JumpCount <= 60)
            {
                JumpCount++;
                PlayerPosY++;
            }
            if (JumpCount == 60)    //Reset
            {
                IsJumping = false;
                JumpCount = 0;
            }
        }
    }
}
