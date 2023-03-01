using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace Project2;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private SpriteFont font;
    private Texture2D _blackSquare;
    private Texture2D _whitePiece;
    private Texture2D _blackPiece;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 640;
       _graphics.PreferredBackBufferHeight = 640;
       _graphics.ApplyChanges();
       this.Window.Title = "checkers Board";

        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _blackPiece = Content.Load<Texture2D>("BlackPiece");
        _blackSquare = Content.Load<Texture2D>("BlackSquare");
        _whitePiece = Content.Load<Texture2D>("WhitePiece");
        font = Content.Load<SpriteFont>("FreeSans");
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);
        _spriteBatch.Begin();
        // draws borad 
        int adjustForEvenRows;
        for (int i = 0; i <=63; i++)
        {
            if ( (i / 8) % 2 == 1) {adjustForEvenRows = 0;}
            else {adjustForEvenRows = 1;}
            if(i % 2 == 1)
            {
                _spriteBatch.Draw(_blackSquare, new Rectangle(((i - ( (i / 8) * 8) - 1 + adjustForEvenRows) * 80), ((i / 8) * 80), 80, 80), Color.White);
                 //adds white pieces to top of board
                if ((i / 8) <= 2)
                {
                    _spriteBatch.Draw(_whitePiece, new Rectangle(((i - ( (i / 8) * 8) - 1 + adjustForEvenRows) * 80), ((i / 8) * 80), 80, 80), Color.White);
                
                }
                //adds black pieces to bottom of board
                if ((i / 8) >= 5)
                {
                    _spriteBatch.Draw(_blackPiece, new Rectangle(((i - ( (i / 8) * 8) - 1 + adjustForEvenRows) * 80), ((i / 8) * 80), 80, 80), Color.White);
                
                }
            }
           
        }
         _spriteBatch.DrawString(font, "Start Game", new Vector2(230, 280), Color.DarkRed);
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
