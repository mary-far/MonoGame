using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MFarooqiFinalProject
{
    public class Basket : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 pos;

        private float speed;


        public Basket(Game game, SpriteBatch spriteBatch,
            Texture2D tex, Vector2 pos) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.pos = pos;

            speed = 1.35f;

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, pos, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Left))
            {
                pos.X -= speed;
            }

            if (ks.IsKeyDown(Keys.Right))
            {
                pos.X += speed;
            }

            if (pos.X < 0)
            {
                pos.X = 0;
            }

            if (pos.X > 800 - tex.Width)
            {
                pos.X = 800 - tex.Width;
            }


            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public Rectangle getBound()
        {
            return new Rectangle((int)pos.X, (int)pos.Y,
                tex.Width, tex.Height);
        }
    }
}
