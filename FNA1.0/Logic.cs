using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace FNA1._0
{
    public class Logic : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager Screen;
        SpriteBatch PaintScreen;
        Random rnd = new Random();
        Texture2D BackGround, ImageSnow;
        public List<Snow> Snowflakes = new List<Snow>();
        private KeyboardState State = Keyboard.GetState();
        private KeyboardState State2;

        public Logic()
        {
            Screen = new GraphicsDeviceManager(this);
            Screen.IsFullScreen = true;
            IsMouseVisible = false;
            AddCreateSnow();
            Content.RootDirectory= "Content";
        }

        public void AddCreateSnow()
        {
            for (int i = 0; i < 3000; i++)
            {
                Snowflakes.Add(new Snow
                {
                    X = rnd.Next(Screen.PreferredBackBufferWidth),
                    Y = -rnd.Next(Screen.PreferredBackBufferHeight),
                    Razmer = rnd.Next(5, 15),

                });
            }
        }

        protected override void LoadContent()
        {
            PaintScreen = new SpriteBatch(GraphicsDevice);
            BackGround = Content.Load<Texture2D>("..\\1.jpg");
            ImageSnow = Content.Load<Texture2D>("..\\2.png");
        }

        protected override void Update(GameTime gameTime)
        {
            State2 = State;
            State = Keyboard.GetState();

            foreach (var snowflake in Snowflakes)
            {
                if (snowflake.Razmer > 8)
                {
                    snowflake.Y += rnd.Next(2, 4);
                }
                else
                {
                    snowflake.Y += rnd.Next(1, 3);
                }
                if (snowflake.Y > Screen.PreferredBackBufferHeight)
                {
                    snowflake.Y = -rnd.Next(0, 50);
                    snowflake.X = rnd.Next(0, Screen.PreferredBackBufferWidth);
                }
            }

            if (State2.IsKeyDown(Keys.Escape))
            {
                Exit();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            PaintScreen.Begin();
            PaintScreen.Draw(BackGround, new Rectangle(0, 0, Screen.PreferredBackBufferWidth, Screen.PreferredBackBufferHeight), Color.LightYellow);
            foreach (var snowflake in Snowflakes)
            {
                PaintScreen.Draw(ImageSnow, new Rectangle(snowflake.X, snowflake.Y, snowflake.Razmer, snowflake.Razmer), Color.White);
            }
            PaintScreen.End();
        }
    } 

}