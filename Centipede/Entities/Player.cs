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
        ModelEntity[] Eyes = new ModelEntity[2];
        #endregion
        #region Properties

        #endregion
        #region Constructor
        public Player(Game game, Camera camera, GameLogic gameLogic) : base(game, camera)
        {
            LogicRef = gameLogic;

            for (int i = 0; i < 2; i++)
            {
                Eyes[i] = new ModelEntity(game, camera);
            }
        }
        #endregion
        #region Initialize-Load-BeginRun
        public override void Initialize()
        {
            PO.Position.Y = -250;
            PO.Position.X = -240;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            LoadModel("Player-Head");

            for (int i = 0; i < 2; i++)
            {
                Eyes[i].LoadModel("Player-Eye");
                Eyes[i].AddAsChildOf(this);
                Eyes[i].PO.Position.Z = 1.5f;
                Eyes[i].PO.Position.Y = 27;
                Eyes[i].DefuseColor = new Vector3(1, 0, 0);
            }

            Eyes[0].PO.Position.X = -1.5f;
            Eyes[0].PO.Position.Y += 2.5f;
            Eyes[0].PO.Rotation.Z = MathHelper.PiOver2;
            Eyes[1].PO.Position.X = 4;

            base.LoadContent();
        }

        public override void BeginRun()
        {
            base.BeginRun();

            //Enabled = false;
        }
        #endregion
        #region Update
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
        #endregion
    }
}
