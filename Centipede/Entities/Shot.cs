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
    class Shot : Cube
    {
        #region Fields
        GameLogic LogicRef;
        bool Ready;
        #endregion
        #region Properties

        #endregion
        #region Constructor
        public Shot(Game game, Camera camera, GameLogic gameLogic) : base(game, camera)
        {
            LogicRef = gameLogic;

            Enabled = false;
        }
        #endregion
        #region Initialize-Load-BeginRun
        public override void Initialize()
        {
            ModelScale.Y = 8;
            ModelScale.X = 3;

            base.Initialize();
        }

        protected override void LoadContent()
        {


            base.LoadContent();
        }

        public override void BeginRun()
        {
            base.BeginRun();

            ResetShot();
        }
        #endregion
        #region Update
        public override void Update(GameTime gameTime)
        {
            if (PO.Position.Y > 450)
            {
                ResetShot();
            }

            base.Update(gameTime);
        }
        #endregion
        public void FireShot()
        {
            if (Ready)
            {
                ChildLink(false);
                PO.Velocity.Y = 300;
                Position += PO.ParentPO.Position;
                Ready = false;
            }
        }

        public void ResetShot()
        {
            PO.Position.X = 0;
            PO.Position.Y = 44;
            PO.Velocity.Y = 0;
            ChildLink(true);
            Ready = true;
        }
    }
}
