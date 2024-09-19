using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lab10_game2
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D menuTexture;
        Texture2D gameplayTexture;
        ScreenState mCurrentScreen;
        enum ScreenState
        {
            Title,
            Gameplay
        }
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
            spriteBatch = new SpriteBatch(GraphicsDevice);
            menuTexture = Content.Load<Texture2D>("title");
            gameplayTexture = Content.Load<Texture2D>("gameplay");
            mCurrentScreen = ScreenState.Title;
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            switch (mCurrentScreen)
            {
                case ScreenState.Title:
                    {
                        UpdateTitle();
                        break;
                    }
                case ScreenState.Gameplay:
                    {
                        UpdateGameplay();
                        break;
                    }
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            switch (mCurrentScreen)
            {
                case ScreenState.Title:
                    {
                        DrawMenu();
                        break;
                    }
                case ScreenState.Gameplay:
                    {
                        DrawGameplay();
                        break;
                    }
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        private void UpdateGameplay()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A) == true)
            {
                mCurrentScreen = ScreenState.Title;
            }
        }
        private void UpdateTitle()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.B) == true)
            {
                mCurrentScreen = ScreenState.Gameplay;
            }
        }
        private void DrawGameplay()
        {
            spriteBatch.Draw(gameplayTexture, Vector2.Zero, Color.White);
        }
        private void DrawMenu()
        {
            spriteBatch.Draw(menuTexture, Vector2.Zero, Color.White);
        }
    }
}
