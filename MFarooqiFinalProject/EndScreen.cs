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
    public class EndScreen : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont font;
        Vector2 pos;
        Score score;
        
        public EndScreen(Game game, SpriteBatch spriteBatch, SpriteFont font, Score score) : base(game)
        {
           
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.score = score;
            pos = new Vector2(300, 10);

        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Press ENTER to\nRESTART game\n\n\n\n\n\n" +
                "Final Score: " + score.count.ToString(),pos, Color.Black);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
