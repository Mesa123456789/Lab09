using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Formats.Asn1.AsnWriter;

namespace Lab10_game1
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        AnimatedTexture AnimatedTexture;
        SpriteBatch spriteBatch;
        Texture2D menuTexture;
        Texture2D gameplayTexture;
        bool isMenu;
        bool isGameplay;
        bool isGameplay2;

        private const float Rotation = 0;
        private const float Scale = 1.0f;
        private const float Depth = 0.5f;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            AnimatedTexture = new AnimatedTexture(Vector2.Zero, Rotation, Scale,Depth);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            menuTexture = Content.Load<Texture2D>("title");
            gameplayTexture = Content.Load<Texture2D>("gameplay");
            AnimatedTexture.Load(Content, "Char01", 4, 4, 10);
            isMenu = true;
            isGameplay = false;
            isGameplay2 = false;
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            if (isMenu == true)
            {
                UpdateTitle();
            }
            else if (isGameplay == true)
            {
                UpdateGameplay();
            }
            else if (isGameplay2 == true)
            {
                UpdateGameplay2();
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            if (isGameplay2 == true)
            {
                DrawGameplay2();
            }
            else if (isGameplay == true)
            {
                DrawGameplay();
            }
            else if (isMenu == true)
            {
                DrawMenu();
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        private void UpdateGameplay()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A) == true)
            {
                isMenu = true;
                isGameplay = false;
                isGameplay2 = false;
            }
        }
        private void UpdateGameplay2()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.C) == true)
            {
                isGameplay2 = true;
                isMenu = false;
                isGameplay = false;
                
            }
        }
        private void UpdateTitle()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.B) == true)
            {
                isMenu = false;
                isGameplay = true;
                isGameplay2 = false;
            }
        }
        private void DrawGameplay()
        {

            spriteBatch.Draw(gameplayTexture, Vector2.Zero, Color.White);
            
        }
        private void DrawGameplay2()
        {
            spriteBatch.Draw(gameplayTexture, Vector2.Zero, Color.White);
            AnimatedTexture.DrawFrame(spriteBatch, Vector2.Zero);

        }
        private void DrawMenu()
        {
            spriteBatch.Draw(menuTexture, Vector2.Zero, Color.White);
            
        }



    }
}
