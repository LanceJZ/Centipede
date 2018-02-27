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
    class CentipedePart : ModelEntity
    {
        #region Fields
        GameLogic LogicRef;
        ModelEntity Eyes;
        ModelEntity[] Legs = new ModelEntity[2];
        #endregion
        #region Properties

        #endregion
        #region Constructor
        public CentipedePart(Game game, Camera camera, GameLogic gameLogic) : base(game, camera)
        {
            LogicRef = gameLogic;
            Eyes = new ModelEntity(game, camera);

            for (int i = 0; i < 2; i++)
            {
                Legs[i] = new ModelEntity(game, camera);
            }
        }
        #endregion
        #region Initialize-Load-BeginRun
        public override void Initialize()
        {
            Enabled = false;
            //PO.Rotation.Y = MathHelper.PiOver2;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            LoadModel("Centipede-Body");
            Eyes.LoadModel("Centipede-Eyes");

            for (int i = 0; i < 2; i++)
            {
                Legs[i].LoadModel("Centipede-Leg");
            }

            base.LoadContent();
        }

        public override void BeginRun()
        {
            base.BeginRun();

            Eyes.AddAsChildOf(this);
            Eyes.PO.Position.Z = 4.5f;
            Eyes.PO.Position.X = 6.5f;

            for (int i = 0; i < 2; i++)
            {
                Legs[i].AddAsChildOf(this);
                Legs[i].PO.Position.X = 3;
                Legs[i].PO.Position.Z = -4;
            }

            Legs[0].PO.Position.Y = 7;
            Legs[1].PO.Position.Y = -7;
            Legs[1].PO.Rotation.Z = MathHelper.Pi;
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
            Eyes.DefuseColor = eyesColor;

            for (int i = 0; i < 2; i++)
            {
                Legs[i].DefuseColor = legsColor;
            }

            base.Spawn(position);
        }
    }
}
