using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework.Media;

namespace GME1003GoblinDanceParty
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //Declare some variables
        private int _numStars;          //how many stars?
        private List<int> _starsX;      //list of star x-coordinates
        private List<int> _starsY;      //list of star y-coordinates

        private List<float> _starRotate; // Task 2 (declare)
        private List<float> _starOpacity; // Task 3 (delcare)

        private Texture2D _starSprite;  //the sprite image for our star

        private Random _rng;            //for all our random number needs
        private Color _starColor;       //let's have fun with colour!!
        private float _starScale;       //star size
        private float _starTransparency;//star transparency
        private float _starRotation;    //star rotation


        //***This is for the goblin. Ignore it.
        Goblin goblin;
        Song music;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _rng = new Random();        //finish setting up our Random TODO: I feel like I'm missing something here..
            _numStars = _rng.Next(50, 100);              //this would be better as a random number between 100 and 300. TODO: Task 1 (Completed). Was it really that easy? Were you expecting more??
            // TODO: Assignment instructions not seen here instruct between 50 and 300. Went with that.
            Console.WriteLine("Number of stars this run: " + _numStars); // this prints to console star count each run, for debugging and has no impact on the game.
            _starsX = new List<int>();  //stars X coordinate
            _starsY = new List<int>();  //stars Y coordinate
            
            //insert assigned list initializations
            _starRotate = new List<float>(); // Task 2 (initialize list)
            _starOpacity = new List<float>(); // Task 3 (initialize list)
            
            _starColor = new Color(128 + _rng.Next(0,129), 128 + _rng.Next(0, 129), 128 + _rng.Next(0, 129));                   //this is a "relatively" easy way to create random colors
            _starScale = _rng.Next(50, 100) / 200f; //this will affect the size of the stars
            _starTransparency = _rng.Next(25, 101)/100f;   //star transparency
            _starRotation = _rng.Next(0, 101) / 100f;       //star rotation
            

            //use a separate for loop for each list - for practice
            //List of X coordinates
            for (int i = 0; i < _numStars; i++) 
            { 
                _starsX.Add(_rng.Next(0, 801)); //all star x-coordinates are between 0 and 800
                
            }

            //List of Y coordinates
            for (int i = 0; i < _numStars; i++)
            {
                _starsY.Add(_rng.Next(0, 481)); //all star y-coordinates are between 0 and 480
            }

            // List of star rotation loop
            for (int i = 0; i < _numStars; i++) // Task 2 (loop count for each star)
            {
                _starRotate.Add(_rng.NextSingle()); // Why does this work now?
            }
            
            // Console Debuggy information
            Console.WriteLine("---------------");
            Console.WriteLine("Star 55 has volunteered as tribute."); // or has it?
            Console.WriteLine("X position: " + _starsX[55] + ", Y position: " + _starsY[55]);
            Console.WriteLine("Number of items in rotation list: " + _starRotate.Count);
            Console.WriteLine("Rotation of star number 55: " + _starRotate[55]); // Debug Star Rotation on star 55
            
            // List of star opacity (Task 3)
            for (int i = 0; i < _numStars; i++)
            {
                _starOpacity.Add(_rng.Next(25,100) /100f); // tested with NextSingle, couldn't set MinValue to .25f
            }
            Console.WriteLine("Opacity of star number 55: " + _starOpacity[55]);
            
            //TODO: 6. Custom Background (800x480), maybe something custom , some other cool stuff to add
            
            //ToDo: 5. List of Colors
            
            //ToDo: 4. List of scale values

            //ToDo: 3. List of transparency values (Complete)

            //ToDo: 2. List of rotation values (Complete, sloppy?)


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //load out star sprite
            _starSprite = Content.Load<Texture2D>("starSprite");


            //***This is for the goblin. Ignore it for now.
            goblin = new Goblin(Content.Load<Texture2D>("goblinIdleSpriteSheet"), 400, 400);
            music = Content.Load<Song>("chiptune");
            
            //if you're tired of the music player, comment this out!
            //  MediaPlayer.Play(music);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

   
            //***This is for the goblin. Ignore it for now.
            goblin.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            
            _spriteBatch.Begin();

            //it would be great to have a background image here! 
            //you could make that happen with a single Draw statement.

            //this is where we draw the stars...
            for (int i = 0; i < _numStars; i++) 
            {
                _spriteBatch.Draw(_starSprite, 
                    new Vector2(_starsX[i], _starsY[i]),    //set the star position
                    null,                                   //ignore this
                    _starColor * _starOpacity[i],         //set colour and transparency (now uses per star list)
                    _starRotate[i],                          //set rotation (now uses rotation list)
                    new Vector2(_starSprite.Width / 2, _starSprite.Height / 2), //ignore this
                    new Vector2(_starScale, _starScale),    //set scale (same number 2x)
                    SpriteEffects.None,                     //ignore this
                    0f);                                    //ignore this
            }
            _spriteBatch.End();
            


            //***This is for the goblin. Ignore it for now.
            goblin.Draw(_spriteBatch);

            base.Draw(gameTime);

        }
    }
}
