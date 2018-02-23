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

        GameState GameMode = GameState.InPlay;
        KeyboardState OldKeyState;

        public GameState CurrentMode { get => GameMode; }

        public GameLogic(Game game, Camera camera) : base(game)
        {
            CameraRef = camera;
            ScoreDisplay = new Numbers(game);
            WordDisplay = new Letters(game);

            ThePlayer = new Player(game, camera, this);

            // Screen resolution is 675 X 900.
            // Y positive is Up.
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
