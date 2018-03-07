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
    class CentipedePart : ModelEntity
    {
        #region Fields
        GameLogic LogicRef;
        ModelEntity Eyes;
        ModelEntity[] Legs = new ModelEntity[2];
        bool HitBottom;
        #endregion
        #region Properties
        public bool Head { get => Eyes.Enabled; set => Eyes.Enabled = value; }
        #endregion
        #region Constructor
        public CentipedePart(Game game, Camera camera, GameLogic gameLogic) : base(game, camera)
        {
            LogicRef = gameLogic;
            Enabled = false;
            Eyes = new ModelEntity(game, camera);
            Eyes.Enabled = false;

            for (int i = 0; i < 2; i++)
            {
                Legs[i] = new ModelEntity(game, camera);
            }
        }
        #endregion
        #region Initialize-Load-BeginRun
        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            LoadModel("Centipede-Body");
            Eyes.LoadModel("Centipede-Eyes");

            for (int i = 0; i < 2; i++)
            {
                Legs[i].LoadModel("Centipede-Leg");
            }

            base.LoadContent();
        }

        public override void BeginRun()
        {
            base.BeginRun();

            Eyes.AddAsChildOf(this, false);
            Eyes.Z = 4.5f;
            Eyes.X = 6.5f;

            for (int i = 0; i < 2; i++)
            {
                Legs[i].AddAsChildOf(this);
                Legs[i].X = 3;
                Legs[i].Z = -4;
            }

            Legs[0].Y = 7;
            Legs[1].Y = -7;
            Legs[1].PO.Rotation.Z = MathHelper.Pi;
        }
        #endregion
        #region Update
        public override void Update(GameTime gameTime)
        {
            CheckForDown();

            base.Update(gameTime);
        }
        #endregion
        public void SpawnIt(Vector3 position, Vector3 rotation, bool head,
            Vector3 color, Vector3 eyesColor, Vector3 legsColor)
        {
            DefuseColor = color;
            Eyes.DefuseColor = eyesColor;
            Eyes.Enabled = head;

            for (int i = 0; i < 2; i++)
            {
                Legs[i].DefuseColor = legsColor;
            }

            Vector3 velocity = Vector3.Zero;

            if (rotation.Z > 0)
            {
                velocity.X = -100;
            }
            else
            {
                velocity.X = 100;
            }

            base.Spawn(position, rotation, velocity);
        }

        void CheckForDown()
        {
            bool down = false;

            Mushroom mushroomHit = LogicRef.BackgroundRef.HitMushroom(Sphere);

            if (Rotation.Z > 0)
            {
                if (X < -(Helper.SreenWidth / 2) + 45)
                {
                    down = true;
                }


                if (mushroomHit != null)
                {
                    if (mushroomHit.Active)
                    {
                        down = true;
                        X = mushroomHit.X + 30;
                    }
                }

                if (down)
                {
                    PO.Rotation.Z = 0;
                    PO.Velocity.X = 100;
                }
            }
            else
            {
                if (X > (Helper.SreenWidth / 2) - 45)
                {
                    down = true;
                }

                if (mushroomHit != null)
                {
                    if (mushroomHit.Active)
                    {
                        down = true;
                        X = mushroomHit.X - 30;
                    }
                }

                if (down)
                {
                    PO.Rotation.Z = MathHelper.Pi;
                    PO.Velocity.X = -100;
                }
            }

            if (down)
            {
                if (HitBottom)
                {
                    GoUp();
                }
                else
                {
                    GoDown();
                }
            }
        }

        void GoDown()
        {
            Y -= 30;

            if (Y < -420)
                HitBottom = true;
        }

        void GoUp()
        {
            Y += 30;

            if (Y > -200)
                HitBottom = false;
        }
    }
}
