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

        Vector3 Reverse;
        #endregion
        #region Properties

        #endregion
        #region Constructor
        public Player(Game game, Camera camera, GameLogic gameLogic) : base(game, camera)
        {
            LogicRef = gameLogic;
            Enabled = false;
            TheShot = new Shot(game, camera, gameLogic);
            Eyes = new ModelEntity(game, camera);
        }
        #endregion
        #region Initialize-Load-BeginRun
        public override void Initialize()
        {
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
            int i = 0;

            if (LogicRef.BackgroundRef.HitMushroom(ref i, Sphere))
            {
                if (Velocity.Length() > 0)
                    Reverse = -Velocity * 0.5f;

                Position += Reverse * PO.ElapsedGameTime;
                Velocity = Vector3.Zero;
            }
            else
            {
                Input();
            }

            base.Update(gameTime);
        }
        #endregion
        public void SpawnIt(Vector3 position, Vector3 color, Vector3 eyesColor)
        {
            DefuseColor = color;
            Eyes.DefuseColor = eyesColor;
            TheShot.DefuseColor = eyesColor;

            base.Spawn(position);
        }

        void Input()
        {
            KeyboardState KBS = Keyboard.GetState();

            if (KBS != OldKeyState)
            {
            }

            if (KBS.IsKeyDown(Keys.LeftControl))
            {
                TheShot.FireShot();
            }

            Velocity = Vector3.Zero;

            if (KBS.IsKeyDown(Keys.Left) && Position.X > -(Helper.SreenWidth / 2) + 10) //420 * 2 is the screen width.
            {
                PO.Velocity.X = -200;
            }
            else if (KBS.IsKeyDown(Keys.Right) && Position.X < (Helper.SreenWidth / 2) - 10)
            {
                PO.Velocity.X = 200;
            }

            if (KBS.IsKeyDown(Keys.Up) && Position.Y < -200)
            {
                PO.Velocity.Y = 200;
            }
            else if (KBS.IsKeyDown(Keys.Down) && Position.Y > -(Helper.ScreenHeight / 2)) //450 * 2 is the screen hight.
            {
                PO.Velocity.Y = -200;
            }

            OldKeyState = Keyboard.GetState();
        }
    }
}
