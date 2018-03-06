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
        One,
        Two,
        Three,
        New
    };

    class Mushroom : ModelEntity
    {
        #region Fields
        GameLogic LogicRef;
        ModelEntity OutlineModel;
        ModelEntity[] MushroomHit = new ModelEntity[3];
        ModelEntity[] MushroomOutlineHit = new ModelEntity[3];

        HitDisplay HitMode = HitDisplay.New;
        #endregion
        #region Properties
        public new BoundingSphere Sphere {get => OutlineModel.Sphere;}
        #endregion
        #region Constructor
        public Mushroom(Game game, Camera camera, GameLogic gameLogic) : base(game, camera)
        {
            LogicRef = gameLogic;
            OutlineModel = new ModelEntity(game, camera);

            for (int i = 0; i < 3; i++)
            {
                MushroomHit[i] = new ModelEntity(game, camera);
                MushroomOutlineHit[i] = new ModelEntity(game, camera);
            }

            Enabled = false;
            Moveable = false;
            OutlineModel.Enabled = false;
            OutlineModel.Moveable = false;
        }
        #endregion
        #region Initialize-Load-BeginRun
        public override void Initialize()
        {
            for (int i = 0; i < 3; i++)
            {
                MushroomHit[i].Enabled = false;
                MushroomHit[i].Moveable = false;
                MushroomOutlineHit[i].Enabled = false;
                MushroomOutlineHit[i].Moveable = false;
            }


            base.Initialize();
        }

        protected override void LoadContent()
        {
            LoadModel("Mushroom-New-Main");
            OutlineModel.LoadModel("Mushroom-New-Outline");

            MushroomHit[0].LoadModel("Mushroom-One-Main");
            MushroomOutlineHit[0].LoadModel("Mushroom-One-Outline");
            MushroomHit[1].LoadModel("Mushroom-Two-Main");
            MushroomOutlineHit[1].LoadModel("Mushroom-Two-Outline");
            MushroomHit[2].LoadModel("Mushroom-Three-Main");
            MushroomOutlineHit[2].LoadModel("Mushroom-Three-Outline");


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

        public void SpawnIt(Vector3 position, Vector3 color, Vector3 outlineColor)
        {
            DefuseColor = color;
            OutlineModel.DefuseColor = outlineColor;

            OutlineModel.Spawn(position);
            base.Spawn(position);
        }
    }
}
