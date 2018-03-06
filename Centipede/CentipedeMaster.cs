using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.Linq;
using System;
using Centipede.Entities;

namespace Centipede
{
    class CentipedeMaster : GameComponent
    {
        #region Fields
        GameLogic LogicRef;
        Camera CameraRef;
        List<CentipedePart> TheCentipede = new List<CentipedePart>();
        #endregion
        #region Properties

        #endregion
        #region Constructor
        public CentipedeMaster(Game game, Camera camera, GameLogic gameLogic) : base(game)
        {
            LogicRef = gameLogic;
            CameraRef = camera;

            game.Components.Add(this);
        }
        #endregion
        #region Initialize-Load-BeginRun
        public override void Initialize()
        {

            base.Initialize();
            LoadContent();
            BeginRun();
        }

        public void LoadContent()
        {

        }

        public void BeginRun()
        {
            for (int i = 0; i < 12; i++)
            {
                TheCentipede.Add(new CentipedePart(Game, CameraRef, LogicRef));
            }

            TheCentipede[0].SpawnIt(new Vector3(0, (Helper.ScreenHeight / 2) - 45, 0),
                Vector3.Zero, true, new Vector3(0, 1, 0), new Vector3(1, 0, 0),
                new Vector3(0.753f, 0.753f, 0.569f));
        }
        #endregion
        #region Update
        public override void Update(GameTime gameTime)
        {


            base.Update(gameTime);
        }

        void Build(int pod)
        {
            TheCentipede[pod].SpawnIt(new Vector3(0, (Helper.ScreenHeight / 2) - 60, 0),
                TheCentipede[0].Rotation, false, new Vector3(0, 1, 0), new Vector3(1, 0, 0),
                new Vector3(0.753f, 0.753f, 0.569f));
        }
        #endregion
    }
}
