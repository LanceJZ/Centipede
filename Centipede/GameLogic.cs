using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.Linq;
using System;
using Centipede.Entities;

public enum GameState
{
    Over,
    InPlay,
    HighScore,
    MainMenu
};

namespace Centipede
{
    class GameLogic : GameComponent
    {
        Camera CameraRef;
        Numbers ScoreDisplay;
        Letters WordDisplay;

        Player ThePlayer;
        Background TheBackGround;
        CentipedeMaster TheCentipede;
        Spider TheSpider;
        Scorpion TheScorpion;
        Flea TheFlea;

        uint TheTotalScore;

        GameState GameMode = GameState.InPlay;
        KeyboardState OldKeyState;

        public GameState CurrentMode { get => GameMode; }
        public Background BackgroundRef { get => TheBackGround; }
        public Player PlayerRef { get => ThePlayer; }
        public CentipedeMaster CentipedeRef { get => TheCentipede; }
        public Spider SpiderRef { get => TheSpider; }
        public Scorpion ScorpionRef { get => TheScorpion; }
        public Flea FleaRef { get => TheFlea; }
        public uint Points
        {
            get => TheTotalScore;
            set
            {
                TheTotalScore += value;
                ScoreDisplay.Number = TheTotalScore;
            }
        }

        public GameLogic(Game game, Camera camera) : base(game)
        {
            CameraRef = camera;
            ScoreDisplay = new Numbers(game);
            WordDisplay = new Letters(game);

            TheBackGround = new Background(game, camera, this);
            ThePlayer = new Player(game, camera, this);
            TheCentipede = new CentipedeMaster(game, camera, this);
            TheSpider = new Spider(game, camera, this);
            TheScorpion = new Scorpion(game, camera, this);
            TheFlea = new Flea(game, camera, this);

            // Screen resolution is 844 X 900.
            // Centipede is 240X256 that is 0.9375 X height/width to get new height/width.
            // This window size is 3.5 times the original size.
            // The Camera is set so that one unit equals 3.5 of the original scale.
            // That means the window width is 840 units and the height is 896 units.
            // 4:3 is 0.75 X height/width to get new height/width.
            // 16:9 is 0.5625 X height/width to get new height/width.
            // Y positive is Up when camera is at rotation zero.
            // X positive is right of window when camera is at rotation zero.
            // Z positive is towards the camera when at rotation zero.
            // Positive rotation rotates CCW. Zero has front facing X positive. Pi/2 on Y faces Z negative.
            game.Components.Add(this);
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public void LoadContent()
        {

        }

        public void BeginRun()
        {
            ScoreDisplay.Setup(new Vector2(-250, 420), 2);
            //TheSpider.SpawnIt(new Vector3(-200, -250, 0), new Vector3(0, 1, 0),
            //    new Vector3(1, 0, 0), new Vector3(1, 1, 0.753f));

            //TheFlea.SpawnIt(new Vector3(-200, 250, 0), new Vector3(0, 1, 0),
            //    new Vector3(1, 0, 0), new Vector3(1, 1, 0.753f));

            //TheScorpion.SpawnIt(new Vector3(200, 250, 0), new Vector3(0, 1, 0),
            //    new Vector3(1, 0, 0), new Vector3(1, 1, 0.753f));

            ThePlayer.SpawnIt(new Vector3(0, -450, 0), new Vector3(1, 1, 0.753f),
                new Vector3(1, 0, 0));
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState KBS = Keyboard.GetState();

            if (KBS != OldKeyState)
            {
            }

            OldKeyState = Keyboard.GetState();

            base.Update(gameTime);
        }

    }
}
