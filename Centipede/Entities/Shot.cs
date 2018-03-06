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
        #endregion
        #region Properties
        bool Ready { get => ThePO.Child; }
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
            if (CheckCollusion())
            {
                ResetShot();
            }

            if (Y > 420)
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
                PO.Velocity.Y = 500;
                ChildLink(false);
            }
        }

        public void ResetShot()
        {
            X = 0;
            Y = 44;
            PO.Velocity.Y = 0;
            ChildLink(true);
        }

        bool CheckCollusion()
        {
            int mushroomHit = 0;

            if (LogicRef.BackgroundRef.HitMushroom(ref mushroomHit, Sphere))
            {
                LogicRef.BackgroundRef.Mushrooms[mushroomHit].HitByPlayer();
                return true;
            }

            return false;
        }
    }
}
