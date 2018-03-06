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
    class Flea : ModelEntity
    {
        #region Fields
        GameLogic LogicRef;
        ModelEntity Eye;
        ModelEntity Legs;
        #endregion
        #region Properties

        #endregion
        #region Constructor
        public Flea(Game game, Camera camera, GameLogic gameLogic) : base(game, camera)
        {
            LogicRef = gameLogic;

            Eye = new ModelEntity(game, camera);
            Legs = new ModelEntity(game, camera);
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
            LoadModel("Flea-Body");
            Eye.LoadModel("Flea-Eye");
            Legs.LoadModel("Flea-Legs");

            base.LoadContent();
        }

        public override void BeginRun()
        {
            base.BeginRun();

            Eye.AddAsChildOf(this);
            Eye.Y = 12;
            Eye.X = -10;

            Legs.AddAsChildOf(this);
            Legs.Y = -4;
            Legs.X = 1;
            Legs.Z = -2.5f;
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
            Eye.DefuseColor = eyesColor;
            Legs.DefuseColor = legsColor;

            base.Spawn(position);
        }
    }
}
