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
    public class Score : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont font;
        Vector2 pos;
        public int count;

        public Score(Game game,
            SpriteBatch spriteBatch,
            SpriteFont font,
            Vector2 pos) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.pos = pos;
            count = 0;
        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Score: " + count.ToString(), pos, Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
    }
}
