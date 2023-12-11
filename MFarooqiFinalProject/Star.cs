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
    public class Star : DrawableGameComponent
    {

        private SpriteBatch spriteBatch;
        private Texture2D tex;
        public Vector2 pos;
        public Color Color;
        private float speed;
        const int STAR_MAX_HEIGHT = 500;

        public float Speed { get => speed; set => speed = value; }

        public Star(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            Vector2 pos
           ) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.pos = pos;
            speed = 1.05f;

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
            pos.Y += speed;
            Random random = new Random();

            if (pos.Y > STAR_MAX_HEIGHT)
            {
                pos = new Vector2(1 * random.Next(10, 700), 1 * random.Next(0, 200));

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
