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
    public class Cloud : DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 pos;

        public Cloud(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 pos
           ) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.pos = pos;
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

            float s = 0.2f;

            if (pos.X > -201)
            {
                pos.X += s;
            }
            if (pos.X > 900)
            {
                pos.X = -200;
            }


            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }
    }
}
