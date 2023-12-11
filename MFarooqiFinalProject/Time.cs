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
    public class Time : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        SpriteFont font;
        Vector2 pos;
        public double time;
        public Color color = Color.Black;
       
       

        public Time(Game game,SpriteBatch spriteBatch, SpriteFont font, Vector2 pos) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.font = font;
            this.pos = pos;
          
           
        }

       

        public override void Draw(GameTime gameTime)
        {
            
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Time Left: " + time.ToString() + " seconds", pos, color);
            spriteBatch.End();
            base.Draw(gameTime);
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
