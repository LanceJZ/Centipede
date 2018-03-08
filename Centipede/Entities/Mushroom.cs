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
        public bool Active;
        #endregion
        #region Properties
        public new BoundingSphere Sphere {get => OutlineModel.Sphere;}
        #endregion
        #region Constructor
        public Mushroom(Game game, Camera camera, GameLogic gameLogic) : base(game, camera)
        {
            LogicRef = gameLogic;
            Enabled = false;
            Moveable = false;
            OutlineModel = new ModelEntity(game, camera);
            OutlineModel.Enabled = false;
            OutlineModel.Moveable = false;

            for (int i = 0; i < 3; i++)
            {
                MushroomHit[i] = new ModelEntity(game, camera);
                MushroomOutlineHit[i] = new ModelEntity(game, camera);
            }
        }
        #endregion
        #region Initialize-Load-BeginRun
        public override void Initialize()
        {
            for (int i = 0; i < 3; i++)
            {
                MushroomHit[i].Moveable = false;
                MushroomOutlineHit[i].Moveable = false;
                MushroomHit[i].Enabled = false;
                MushroomOutlineHit[i].Enabled = false;
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            LoadModel("Mushroom-New-Main");
            OutlineModel.LoadModel("Mushroom-New-Outline");

            MushroomHit[0].LoadModel("Mushroom-OneHit-Main");
            MushroomOutlineHit[0].LoadModel("Mushroom-OneHit-Outline");
            MushroomHit[1].LoadModel("Mushroom-TwoHit-Main");
            MushroomOutlineHit[1].LoadModel("Mushroom-TwoHit-Outline");
            MushroomHit[2].LoadModel("Mushroom-ThreeHit-Main");
            MushroomOutlineHit[2].LoadModel("Mushroom-ThreeHit-Outline");


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
        public void HitByPlayer()
        {
            Hit = true;

            if (Visible)
            {
                Visible = false;
                OutlineModel.Enabled = false;
                MushroomHit[0].Enabled = true;
                MushroomOutlineHit[0].Enabled = true;
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    if (MushroomHit[i].Enabled)
                    {
                        MushroomHit[i].Enabled = false;
                        MushroomOutlineHit[i].Enabled = false;
                        MushroomHit[i + 1].Enabled = true;
                        MushroomOutlineHit[i + 1].Enabled = true;
                        return;
                    }
                }

                if (MushroomHit[2].Enabled)
                {
                    Active = false;
                    Hit = false;
                    MushroomHit[2].Enabled = false;
                    MushroomOutlineHit[2].Enabled = false;
                    LogicRef.Points = 1;
                }
            }
        }

        public void ColorIt(Vector3 color, Vector3 outlineColor)
        {
            DefuseColor = color;
            OutlineModel.DefuseColor = outlineColor;

            for (int i = 0; i < 3; i++)
            {
                MushroomHit[i].DefuseColor = color;
                MushroomOutlineHit[i].DefuseColor = outlineColor;
            }
        }

        public void Setup(Vector3 position)
        {
            Position = position;
            OutlineModel.Position = Position;

            for (int i = 0; i < 3; i++)
            {
                MushroomHit[i].Position = position;
                MushroomOutlineHit[i].Position = position;
            }

            Enabled = true;
            OutlineModel.Enabled = true;
            Visible = false;
            OutlineModel.Visible = false;
            Active = false;
        }

        public void Spawn()
        {
            Visible = true;
            OutlineModel.Enabled = true;
            Active = true;
        }

        public void Reset()
        {
            Visible = true;
            OutlineModel.Enabled = true;
            OutlineModel.Visible = true;

            for (int i = 0; i < 3; i++)
            {
                MushroomHit[i].Enabled = false;
                MushroomOutlineHit[i].Enabled = false;
            }
        }
    }
}
