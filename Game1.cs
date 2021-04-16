using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace Jump_or_die
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D TBottom;
        private Texture2D TObstacle;
        private Texture2D TCharacter;

        private SpriteFont arial;
        private SpriteFont kvf;
        private SpriteFont digi;
        private SpriteFont monospace;
        private SpriteFont monoid;

        public int screenWidth;
        public int screenHeight;

        public int ObstacleHeight;

        private Obstacles obstacles;
        private AnimatedSprite animatedSprite;
        private Player player;

        private bool UserPlaying;
        public int Score = 0;       //Scoreeee
        private bool ShowInfo;
        public bool ObstacleHit;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //obstacles = new Obstacles(this, TObstacle);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            Window.Title = "Jump Or Die!";
            screenWidth = graphics.PreferredBackBufferWidth;
            screenHeight = graphics.PreferredBackBufferHeight;

            spriteBatch = new SpriteBatch(GraphicsDevice);

            TBottom = Content.Load<Texture2D>("Bottom");

            TObstacle = Content.Load<Texture2D>("obstacle");

            arial = Content.Load<SpriteFont>("font");

            kvf = Content.Load<SpriteFont>("kvf");

            digi = Content.Load<SpriteFont>("digital");

            monospace = Content.Load<SpriteFont>("monospace");

            monoid = Content.Load<SpriteFont>("monoid");

            TCharacter = Content.Load<Texture2D>("simple-running-guy-run-tag");

            animatedSprite = new AnimatedSprite(TCharacter, 1, 8);

            player = new Player(TCharacter);

            obstacles = new Obstacles(this, TObstacle);

            ObstacleHeight = TObstacle.Height;
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            MouseState mouseState = Mouse.GetState();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                UserPlaying = false;

            if (keyboardState.IsKeyDown(Keys.Space))
                UserPlaying = true;

            if (keyboardState.IsKeyDown(Keys.F1))
                ShowInfo = true;
            else 
            { 
                ShowInfo = false; 
            }

            if (UserPlaying)
            {
                player.Update();
                animatedSprite.Update();
                obstacles.ObstacleUpdate();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            if(UserPlaying)
            {
                DrawObstacles();
                DrawPlayer();
                DrawBottom();
                DrawText();
                CollisionDetection();
            }
            if (ShowInfo)
            {
                DrawInfo();
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void DrawBottom()
        {
            for (int i = 0; i <= screenWidth; i++)
                spriteBatch.Draw(TBottom, new Vector2(i, 300), Color.White);
        }
        private void DrawObstacles()
        {
            for (int i = 0; i < obstacles.ExistingObstacles.Count; i++)
                spriteBatch.Draw(TObstacle, new Vector2(obstacles.ExistingObstacles[i].Position, 300 - ObstacleHeight), Color.White);
        }
        private void DrawText()
        {
            spriteBatch.DrawString(kvf, "SCORE: " + Score, new Vector2(630, 5), Color.Black);
        }
        private void DrawPlayer()
        {
            if(UserPlaying)
                animatedSprite.Draw(spriteBatch, new Vector2(20, player.PlayerPosY));
        }
        private void DrawInfo()
        {
            spriteBatch.DrawString(monospace, "Here are some infos:", new Vector2(10, 5), Color.Black);
            spriteBatch.DrawString(monospace, "UserPlaying: " + UserPlaying, new Vector2(10, 20), Color.Black);
            spriteBatch.DrawString(monospace, "ExistingObstacles: " + obstacles.ExistingObstacles.Count, new Vector2(10, 35), Color.Black);
            spriteBatch.DrawString(monospace, "IsJumping: " + player.IsJumping, new Vector2(10, 50), Color.Black);
            spriteBatch.DrawString(monospace, "JumpCount: " + player.JumpCount, new Vector2(10, 65), Color.Black);
            spriteBatch.DrawString(monospace, "ObstacleHit: " + ObstacleHit, new Vector2(10, 80), Color.Black);
        }
        private void CollisionDetection()
        {

        }
    }
}
