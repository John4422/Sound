using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sound
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D bombtexture;
        Rectangle bombRect;

        SpriteFont words;

        float seconds, startTime;
        MouseState mouseState;

        SoundEffect boom;

        Texture2D explode;
        Rectangle explodeRect;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            bombRect = new Rectangle(50, 50, 700, 400);
            explodeRect = new Rectangle(50, 30, 700, 500);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            bombtexture = Content.Load<Texture2D>("bomb");
            words = Content.Load<SpriteFont>("Words");
            boom = Content.Load<SoundEffect>("explosion");
            explode = Content.Load<Texture2D>("explode");
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            seconds = (float) gameTime.TotalGameTime.TotalSeconds - startTime;
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;
            }

            if (seconds >= 15)
            {
                boom.Play();
                startTime = (float)gameTime.TotalGameTime.TotalSeconds;
                Exit();
            }
                
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(bombtexture, bombRect, Color.White);
            _spriteBatch.DrawString(words, (15 - seconds).ToString("0:00"), new Vector2(270, 200), Color.Black);
            
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}