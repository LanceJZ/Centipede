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

            Enabled = false;
        }
        #endregion
        #region Initialize-Load-BeginRun
        public override void Initialize()
        {

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

            foreach (ModelEntity leg in Legs)
            {
                leg.AddAsChildOf(this);
                leg.Z = -4.5f;
            }

            for (int i = 0; i < 2; i++)
            {
                Legs[i].X = -5;
                Legs[i].PO.Rotation.Z = MathHelper.PiOver2;
                Legs[i + 2].X = 5;
                Legs[i + 2].PO.Rotation.Z = -MathHelper.PiOver2;
            }

            for (int i = 0; i < 4; i+=2)
            {
                Legs[i].Y = 12.5f;
                Legs[i + 1].Y = 4.5f;
            }
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
