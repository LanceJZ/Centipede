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
    class Background : GameComponent
    {
        #region Fields
        GameLogic LogicRef;
        Camera CameraRef;
        List<Mushroom> TheMushrooms = new List<Mushroom>();
        #endregion
        #region Properties

        #endregion
        #region Constructor
        public Background(Game game, Camera camera, GameLogic gameLogic) : base(game)
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
            TheMushrooms.Add(new Mushroom(Game, CameraRef, LogicRef));
            TheMushrooms.Last().Spawn(new Vector3(-100, 100, 0));
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
