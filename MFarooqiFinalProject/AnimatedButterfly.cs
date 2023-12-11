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
    public class AnimatedButterly: DrawableGameComponent
    {
        private SpriteBatch spriteBatch;
        private Texture2D tex;
        private Vector2 dimension;

        private List<Rectangle> frames;

        private int frameIndex = 0;
        private int delay;
        private int delayCounter;

        private const int ROW = 3;

        private const int COL = 4;

        private Vector2 position;
       


        public void start()
        {
            this.Enabled = true;
            this.Visible = true;
        }

     

        public AnimatedButterly(Game game,
            SpriteBatch spriteBatch,
            Texture2D tex,
            int delay,
            Vector2 position) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.tex = tex;
            this.delay = delay;
            this.position = position;

            dimension = new Vector2(tex.Width / COL, tex.Height / ROW);
          

            //create frames
            createFrames();


        }

        private void createFrames()
        {
            frames = new List<Rectangle>();


            for (int i = 0; i < ROW; i++)
            {
                for (int j = 0; j < COL; j++)
                {
                    int x = j * (int)dimension.X;
                    int y = i * (int)dimension.Y;
                    Rectangle r = new Rectangle(x, y,
                        (int)dimension.X, (int)dimension.Y);

                    frames.Add(r);

                }
            }
        }


        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();
            if (frameIndex >= 0)
            {
                //version 4
                spriteBatch.Draw(tex, position, frames[frameIndex], Color.White);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }


        public override void Update(GameTime gameTime)
        {
            delayCounter++;
            if (delayCounter > delay)
            {
                frameIndex++;


                if (frameIndex > ROW*COL - 1)
                {
                    frameIndex = 0;
                    
                }



                delayCounter = 0;
            }



            base.Update(gameTime);
        }
    }
}
