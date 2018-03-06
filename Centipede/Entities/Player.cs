#region Using
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.Linq;
using System;
#endregion
namespace Centipede.Entities
{
    class Player : ModelEntity
    {
        #region Fields
        GameLogic LogicRef;
        Shot TheShot;
        ModelEntity Eyes;
        KeyboardState OldKeyState;
        #endregion
        #region Properties

        #endregion
        #region Constructor
        public Player(Game game, Camera camera, GameLogic gameLogic) : base(game, camera)
        {
            LogicRef = gameLogic;
            TheShot = new Shot(game, camera, gameLogic);
            Eyes = new ModelEntity(game, camera);
        }
        #endregion
        #region Initialize-Load-BeginRun
        public override void Initialize()
        {
            Enabled = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            LoadModel("Player-Head");
            Eyes.LoadModel("Player-Eyes");

            base.LoadContent();
        }

        public override void BeginRun()
        {
            base.BeginRun();

            TheShot.AddAsChildOf(this);

            Eyes.AddAsChildOf(this);
            Eyes.Y = 27;
            Eyes.Z = 1.5f;

        }
        #endregion
        #region Update
        public override void Update(GameTime gameTime)
        {
            Input();
            base.Update(gameTime);
        }
        #endregion
        public void SpawnIt(Vector3 position, Vector3 color, Vector3 eyesColor)
        {
            DefuseColor = color;
            Eyes.DefuseColor = eyesColor;

            base.Spawn(position);
        }

        void Input()
        {
            KeyboardState KBS = Keyboard.GetState();

            if (KBS != OldKeyState)
            {
                if (KBS.IsKeyDown(Keys.LeftControl))
                {
                    TheShot.FireShot();
                }
            }

            OldKeyState = Keyboard.GetState();
        }
    }
}
