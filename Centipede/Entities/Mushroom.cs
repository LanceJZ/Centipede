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
    enum HitDisplay
    {
        New,
        One,
        Two,
        Three
    };

    class Mushroom : ModelEntity
    {
        #region Fields
        GameLogic LogicRef;
        ModelEntity OutlineModel;
        ModelEntity HitOneModel;
        ModelEntity HitOneOutline;
        ModelEntity HitTwoModel;
        ModelEntity HitTwoOutline;
        ModelEntity HitThreeModel;
        ModelEntity HitThreeOutline;

        HitDisplay HitMode = HitDisplay.New;
        #endregion
        #region Properties

        #endregion
        #region Constructor
        public Mushroom(Game game, Camera camera, GameLogic gameLogic) : base(game, camera)
        {
            LogicRef = gameLogic;

            OutlineModel = new ModelEntity(game, camera);
            HitOneModel = new ModelEntity(game, camera);
            HitOneOutline = new ModelEntity(game, camera);
            HitTwoModel = new ModelEntity(game, camera);
            HitTwoOutline = new ModelEntity(game, camera);
            HitThreeModel = new ModelEntity(game, camera);
            HitThreeOutline = new ModelEntity(game, camera);
        }
        #endregion
        #region Initialize-Load-BeginRun
        public override void Initialize()
        {
            Moveable = false;
            OutlineModel.Moveable = false;
            HitOneModel.Visible = false;
            HitOneModel.Moveable = false;
            HitOneOutline.Visible = false;
            HitOneOutline.Moveable = false;
            HitTwoModel.Visible = false;
            HitTwoModel.Moveable = false;
            HitTwoOutline.Visible = false;
            HitTwoOutline.Moveable = false;
            HitThreeModel.Visible = false;
            HitThreeModel.Moveable = false;
            HitThreeOutline.Visible = false;
            HitThreeOutline.Moveable = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            LoadModel("Mushroom-New-Main");
            OutlineModel.LoadModel("Mushroom-New-Outline");
            HitOneModel.LoadModel("Mushroom-One-Main");
            HitOneOutline.LoadModel("Mushroom-One-Outline");
            HitTwoModel.LoadModel("Mushroom-Two-Main");
            HitTwoOutline.LoadModel("Mushroom-Two-Outline");
            HitThreeModel.LoadModel("Mushroom-Three-Main");
            HitThreeOutline.LoadModel("Mushroom-Three-Outline");

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

        public override void Spawn(Vector3 position)
        {
            base.Spawn(position);

            OutlineModel.Spawn(position);
        }
    }
}
