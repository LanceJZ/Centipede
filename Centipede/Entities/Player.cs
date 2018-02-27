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
        ModelEntity Eyes;
        #endregion
        #region Properties

        #endregion
        #region Constructor
        public Player(Game game, Camera camera, GameLogic gameLogic) : base(game, camera)
        {
            LogicRef = gameLogic;
            Eyes = new ModelEntity(game, camera);
        }
        #endregion
        #region Initialize-Load-BeginRun
        public override void Initialize()
        {
            Enabled = false;
            PO.Position.Y = -250;
            //PO.Position.X = -240;
            //PO.Rotation.Y = MathHelper.PiOver2;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            LoadModel("Player-Head");
            DefuseColor = new Vector3(1, 1, 0.753f);
            Eyes.LoadModel("Player-Eyes");
            Eyes.AddAsChildOf(this);
            Eyes.PO.Position.Y = 27;
            Eyes.PO.Position.Z = 1.5f;
            Eyes.DefuseColor = new Vector3(1, 0, 0);

            base.LoadContent();
        }

        public override void BeginRun()
        {
            base.BeginRun();

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
