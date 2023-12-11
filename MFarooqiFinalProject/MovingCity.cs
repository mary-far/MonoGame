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
    public class MovingCity : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 pos, pos2, pos3;
        private Rectangle srcRect;
        private Vector2 speed;

        public MovingCity(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Rectangle srcRect,
            Vector2 pos,
            Vector2 speed) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.srcRect = srcRect;
            this.pos = pos;
            pos2 = new Vector2(pos.X + srcRect.Width, pos.Y);
            pos3 = new Vector2(pos2.X + srcRect.Width, pos2.Y);
            this.speed = speed;

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, pos, Color.White);
            spriteBatch.Draw(tex, pos2, Color.White);
            spriteBatch.Draw(tex, pos3, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            pos -= speed;
            pos2 -= speed;


            if (pos.X < -srcRect.Width)
            {
                pos.X = pos2.X + srcRect.Width;
            }
            if (pos2.X < -srcRect.Width)
            {
                pos2.X = pos.X + srcRect.Width;
            }

            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
