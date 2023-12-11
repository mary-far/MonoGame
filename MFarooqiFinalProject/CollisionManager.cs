using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MFarooqiFinalProject
{
    public class CollisionManager : DrawableGameComponent
    {
        private List<Star> stars;
        private Basket basket;
     
            
        public Score score;
        private SoundEffect sound;
        private Apple apple;
    
        public CollisionManager(Game game,
            List<Star> stars,
            Basket butterfly,
            Score score,
            Apple apple
            ) : base(game)
        {
            this.stars = stars;
            this.basket = butterfly;
            this.score = score;
            this.apple = apple;
            sound = game.Content.Load<SoundEffect>("Sounds/ding");
  
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Star star in stars)
            {

                if (star.getBound().Intersects(basket.getBound()))
                {
                   
                    star.pos = new Vector2(600, 600);
                    sound.Play();
                    score.count += 1;

                }

            }

            base.Update(gameTime);
        }
    }
}
