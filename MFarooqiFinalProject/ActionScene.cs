using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace MFarooqiFinalProject
{
    public class ActionScene : GameScene
    {
        private SpriteBatch spriteBatch;

        Vector2 stage;

        private Texture2D cityTex;
        private Vector2 cityPos;
        private Vector2 citySpeed;
        private Rectangle citySrcRect;

        private Texture2D pinkTex;
        private Vector2 pinkPos;
        private Rectangle pinkSrcRect;

        private Texture2D groundTex;
        private Vector2 groundPos;

        private Texture2D cloudTex;
        private Vector2 cloudPos;

        private MovingCity movingCity;

        private LowerBackground lowerBackground;

        private Ground ground;

        private Cloud cloud;

        private Star star;
        private List<Star> stars;
        private Random random;
        private Texture2D starTex;
        private Vector2 starPos;

        private Basket Butterfly;
        private Texture2D girlTex;
        private Vector2 girlPos;

        private CollisionManager cm;

        private Apple apple;
        private Texture2D appleTex;
        private Vector2 applePos;
      
        private SpriteFont font;
        private Score score;
        private Time time;
    
        private EndScreen ed;

        private float timer;
        private float maxTime = 40.0f;

        public ActionScene(Game game) : base(game)
        {

            Game1 g = (Game1)game;
            this.spriteBatch = g.spriteBatch;


            Vector2 _stage = new Vector2(g.graphics.PreferredBackBufferWidth,
                g.graphics.PreferredBackBufferHeight);

            cityTex = g.Content.Load<Texture2D>("Images/movingcitybackground");
            cityPos = new Vector2(-_stage.X, _stage.Y-250);
            citySpeed = new Vector2(0.9f, 0);
            citySrcRect = new Rectangle((int)cityPos.X, (int)cityPos.Y, cityTex.Width, cityTex.Height);
            movingCity = new MovingCity(game, spriteBatch, cityTex, citySrcRect, cityPos, citySpeed);
            this.Components.Add(movingCity);

            pinkTex = g.Content.Load<Texture2D>("Images/pinkbackground");
            pinkPos = new Vector2(0, 335);
            pinkSrcRect = new Rectangle((int)pinkPos.X, (int)pinkPos.Y, pinkTex.Width, pinkTex.Height);
            lowerBackground = new LowerBackground(game, spriteBatch, pinkTex, pinkPos, pinkSrcRect);
            this.Components.Add(lowerBackground);

            groundTex = g.Content.Load<Texture2D>("Images/ground1");
            groundPos = new Vector2(0, 465);
            ground = new Ground(game, spriteBatch, groundTex, groundPos);
            this.Components.Add(ground);

            cloudTex = g.Content.Load<Texture2D>("Images/cloud");
            cloudPos = new Vector2(0, 10);
            cloud = new Cloud(game, spriteBatch, cloudTex, cloudPos);
            this.Components.Add(cloud);
            cloudPos = new Vector2(250, 75);
            cloud = new Cloud(game, spriteBatch, cloudTex, cloudPos);
            this.Components.Add(cloud);
            cloudPos = new Vector2(500, 5);
            cloud = new Cloud(game, spriteBatch, cloudTex, cloudPos);
            this.Components.Add(cloud);
            cloudPos = new Vector2(-199, 89);
            cloud = new Cloud(game, spriteBatch, cloudTex, cloudPos);
            this.Components.Add(cloud);

            random = new Random();
            starTex = g.Content.Load<Texture2D>("Images/star");
            stars = new List<Star>();
            for (int i = 0; i < random.Next(4, 5); i++)
            {
                starPos = new Vector2(1 * random.Next(5, 700), 1 * random.Next(0, 200));
                star = new Star(game, spriteBatch, starTex, starPos);
                stars.Add(star);
                this.Components.Add(star);

            }

            appleTex = g.Content.Load<Texture2D>("Images/apple");
            applePos = new Vector2(1 * random.Next(5, 700), 1 * random.Next(0, 200));
            apple = new Apple(game, spriteBatch, appleTex, applePos);
            this.Components.Add(apple);

            girlTex = g.Content.Load<Texture2D>("Images/basket");
            girlPos = new Vector2(450, 400);
            Vector2 stage = new Vector2(g.graphics.PreferredBackBufferWidth,
                g.graphics.PreferredBackBufferHeight);
            Butterfly = new Basket(game, spriteBatch, girlTex,girlPos);
            this.Components.Add(Butterfly);

            font = g.Content.Load<SpriteFont>("Fonts/RegularFont");
            score = new Score(game, spriteBatch, font, new Vector2(10, 10));
            this.Components.Add(score);

            Texture2D b = g.Content.Load<Texture2D>("Images/butterfly");
            Vector2 positionB = new Vector2(20, 30);
            AnimatedButterly am = new AnimatedButterly(g, spriteBatch, b, 4, positionB);
            this.Components.Add(am);

            cm = new CollisionManager(game, stars, Butterfly, score, apple);
            this.Components.Add(cm);

            time = new Time(game, spriteBatch, font, new Vector2(550, 10));
            this.Components.Add(time);

            ed = new EndScreen(game, spriteBatch, font, score);
            this.Components.Add(ed);
            ed.Visible = false;

         

            Vector2 positionB3 = new Vector2(580, 30);
            AnimatedButterly am2 = new AnimatedButterly(g, spriteBatch, b, 4, positionB3);
            am2.start();
            this.Components.Add(am2);

        }

        public override void Update(GameTime gameTime)
        {
            
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            time.color = Color.Black;

            if (apple.getBound().Intersects(Butterfly.getBound()))
            {

                timer = timer - 3.0f;
                apple.pos = new Vector2(600, 600);
              
            }

            if (timer > maxTime - 5.0f)
            {

                time.color = Color.Red;

            }

            if (timer >= maxTime)
            {

                ed.Visible = true;
                foreach (Star star in stars)
                {
                    star.Enabled = false;
                    star.Visible = false;
                }

                Butterfly.Enabled = false;
                Butterfly.Visible = false;
                apple.Enabled = false;
                apple.Visible = false;

                KeyboardState KS = Keyboard.GetState();
                if (KS.IsKeyDown(Keys.Enter))
                {
                    ResetGame();
                }

            }

            else if (timer < maxTime)
            {
                time.time = maxTime - (int)timer;

            }

          
            base.Update(gameTime);
        }

        public void ResetGame()
        {
            timer = 0F;
            cm.score.count = 0;
            Butterfly.Enabled = true;
            apple.Enabled = true;
            apple.Visible = true;
            Butterfly.Visible = true;
            ed.Visible = false;

            foreach (Star star in stars)
            {
                star.Enabled = true;
                star.Visible = true;
            }

        }
    }
}
