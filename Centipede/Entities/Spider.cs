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
    class Spider : ModelEntity
    {
        #region Fields
        GameLogic LogicRef;
        ModelEntity EyesRear;
        ModelEntity[] Legs = new ModelEntity[4];
        #endregion
        #region Properties

        #endregion
        #region Constructor
        public Spider(Game game, Camera camera, GameLogic gameLogic) : base(game, camera)
        {
            LogicRef = gameLogic;

            EyesRear = new ModelEntity(game, camera);

            for (int i = 0; i < 4; i++)
            {
                Legs[i] = new ModelEntity(game, camera);
            }
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
            LoadModel("Spider-Body");
            EyesRear.LoadModel("Spider-EyesRear");

            for (int i = 0; i < 4; i++)
            {
                Legs[i].LoadModel("Spider-Leg");
            }

            base.LoadContent();
        }

        public override void BeginRun()
        {
            base.BeginRun();

            EyesRear.AddAsChildOf(this);

            for (int i = 0; i < 4; i++)
            {
                Legs[i].AddAsChildOf(this);
                Legs[i].PO.Position.Z = -4.5f;
            }

            for (int i = 0; i < 2; i++)
            {
                Legs[i].PO.Position.X = -5;
            }

            for (int i = 2; i < 4; i++)
            {
                Legs[i].PO.Position.X = 5;
            }

            for (int i = 0; i < 2; i++)
            {
                Legs[i].PO.Rotation.Z = MathHelper.PiOver2;
            }

            for (int i = 2; i < 4; i++)
            {
                Legs[i].PO.Rotation.Z = -MathHelper.PiOver2;
            }

            Legs[0].PO.Position.Y = 12.5f;
            Legs[1].PO.Position.Y = 4.5f;
            Legs[2].PO.Position.Y = 12.5f;
            Legs[3].PO.Position.Y = 4.5f;
        }
        #endregion
        #region Update
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
        #endregion
        public void SpawnIt(Vector3 position, Vector3 color, Vector3 eyesColor, Vector3 legsColor)
        {
            DefuseColor = color;
            EyesRear.DefuseColor = eyesColor;

            for (int i = 0; i < 4; i++)
            {
                Legs[i].DefuseColor = legsColor;
            }

            base.Spawn(position);
        }
    }
}
