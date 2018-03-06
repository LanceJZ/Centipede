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
    class Scorpion : ModelEntity
    {
        #region Fields
        GameLogic LogicRef;
        ModelEntity Eyes;
        ModelEntity[] Legs = new ModelEntity[6];
        #endregion
        #region Properties

        #endregion
        #region Constructor
        public Scorpion(Game game, Camera camera, GameLogic gameLogic) : base(game, camera)
        {
            LogicRef = gameLogic;

            Eyes = new ModelEntity(game, camera);

            for (int i = 0; i < 6; i++)
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
            LoadModel("Scorpion-Body");
            Eyes.LoadModel("Scorpion-Eyes");

            foreach (ModelEntity leg in Legs)
            {
                leg.LoadModel("Scorpion-Leg");
            }

            base.LoadContent();
        }

        public override void BeginRun()
        {
            base.BeginRun();

            Eyes.AddAsChildOf(this);
            Eyes.X = 7;
            Eyes.Y = 7.5f;

            foreach(ModelEntity leg in Legs)
            {
                leg.AddAsChildOf(this);
                leg.Y = -5.5f;
            }

            for (int i = 0; i < 3; i++)
            {
                Legs[i].Z = -5;
                Legs[i + 3].Z = 5;
            }

            for (int i = 0; i < 6; i+=3)
            {
                Legs[i].X = 1;
                Legs[i + 1].X = -3;
                Legs[i + 2].X = -7;
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
            Eyes.DefuseColor = eyesColor;

            for (int i = 0; i < 4; i++)
            {
                Legs[i].DefuseColor = legsColor;
            }

            base.Spawn(position);
        }
    }
}
