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
    public class Apple : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        public Vector2 pos;
        const int APPLE_MAX_HEIGHT = 500;

        public Apple(Game game,SpriteBatch spriteBatch, Texture2D tex, Vector2 pos) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.pos = pos;
           
        }

        float speed = 0.5f;
        public override void Update(GameTime gameTime)
        {
            pos.Y += speed;
            Random random = new Random();

            if (pos.Y > APPLE_MAX_HEIGHT)
            {
                pos = new Vector2(1 * random.Next(10, 700), 1 * random.Next(0, 20));
                
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, pos, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public Rectangle getBound()
        {
            return new Rectangle((int)pos.X, (int)pos.Y,
                tex.Width, tex.Height);
        }
    }
}
