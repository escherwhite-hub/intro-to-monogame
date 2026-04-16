using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace intro_to_monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;
        Random random;
        Texture2D backgroundTexture, marioTexture, blockTexture, goombaTexture, coinTexture;
        List<Rectangle> coins;
       

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            random = new Random();
            
            coins = new List<Rectangle>();

            for (int i = 0; i < 10; i++)
            {
                coins.Add(new Rectangle(random.Next(0, 760), random.Next(0, 560), 40, 40));
            }

                

            this.Window.Title = "Adding Content";
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            backgroundTexture = Content.Load<Texture2D>("mario-maker-design-1-1");
            blockTexture = Content.Load<Texture2D>("block");
            marioTexture = Content.Load<Texture2D>("mario");
            goombaTexture = Content.Load<Texture2D>("goomba");
            coinTexture = Content.Load<Texture2D>("coin");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            
            _spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, window.Width , window.Height), Color.White);
            _spriteBatch.Draw(blockTexture, new Rectangle(250, 350, 150, 40), Color.White);
            _spriteBatch.Draw(marioTexture, new Rectangle(125, 450, 80, 80), Color.White);
            _spriteBatch.Draw(goombaTexture, new Rectangle(300, 313, 40, 40), Color.White);
            for (int i = 0; i < 10; i++)
            {
                _spriteBatch.Draw(coinTexture, coins[i], Color.White);
            }
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
