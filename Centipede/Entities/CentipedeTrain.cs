using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Centipede.Entities
{
    class CentipedeTrain : PositionedObject
    {
        #region Fields
        GameLogic LogicRef;
        Camera CameraRef;
        CentipedeSegment[] TheCentipede = new CentipedeSegment[12];
        float GoDownX;
        bool HitBottom;
        bool DirectionChange;
        #endregion
        #region Properties
        public CentipedeSegment[] Segments { get => TheCentipede; }
        #endregion
        #region Constructor
        public CentipedeTrain(Game game, Camera camera, GameLogic gameLogic) : base(game)
        {
            LogicRef = gameLogic;
            CameraRef = camera;

        }
        #endregion
        #region Initialize-Load-BeginRun
        public override void Initialize()
        {

            base.Initialize();
        }

        public override void BeginRun()
        {
            for (int i = 0; i < 12; i++)
            {
                TheCentipede[i] = new CentipedeSegment(Game, CameraRef, LogicRef);
                TheCentipede[i].PO.AddAsChildOf(this);
            }

            LogicRef.CentipedeRef.NewWave();
        }
        #endregion
        #region Update
        public override void Update(GameTime gameTime)
        {
            if (LogicRef.CentipedeRef.LevelStart)
            {
                SpawnNextSegment();
            }

            if (DirectionChange)
            {
                SwitchDirection();
            }

            CheckMoveDown();

            base.Update(gameTime);
        }
        #endregion
        public void NewWave()
        {
            Enabled = true;
            Position = new Vector3(0, (Helper.ScreenHeight / 2) - 45, 0);
            SpawnSegment(0, true, Vector3.Zero, Vector3.Zero);
            Velocity = new Vector3(100, 0, 0);
        }

        public void Deactivate()
        {
            for (int i = 0; i < 12; i++)
            {
                TheCentipede[i].Enabled = false;
            }

            Enabled = false;
        }

        public void GoDown()
        {
            for (int i = 1; i < 12; i++)
            {
                TheCentipede[i].PO.Velocity.X = Velocity.X;
                TheCentipede[i].ChildLink(false);
            }

            Y -= 30;
            GoDownX = X;

            if (Y < -420)
                HitBottom = true;

            if (Rotation.Z > 0)
            {
                Rotation.Z = 0;
                Velocity.X = 100;
            }
            else
            {
                Rotation.Z = MathHelper.Pi;
                Velocity.X = -100;
            }

            DirectionChange = true;
        }

        void GoUp()
        {
            Y += 30;

            if (Y > -200)
                HitBottom = false;
        }

        void SwitchDirection()
        {
            bool done = true;
            bool connect = false;
            int segment = 0;

            for (int i = 1; i < 12; i++)
            {
                if (Rotation.Z > 0)
                {
                    if (TheCentipede[i].X > GoDownX)
                    {
                        connect = true;
                        segment = i;
                        done = false;
                        break;
                    }
                }
                else
                {
                    if (TheCentipede[i].X < GoDownX)
                    {
                        connect = true;
                        segment = i;
                        done = false;
                        break;
                    }
                }
            }

            if (connect)
            {
                TheCentipede[segment].PO.Velocity.X = 0;
                TheCentipede[segment].X = TheCentipede[0].X - (30 * segment);
                TheCentipede[segment].Y = TheCentipede[0].Y;
                TheCentipede[segment].PO.Rotation.Z = 0;
                TheCentipede[segment].ChildLink(true);
                return;
            }

            if (done)
            {
                DirectionChange = false;
            }
        }

        void CheckMoveDown()
        {
            bool down = false;

            if (Rotation.Z > 0)
            {
                if (X < -(Helper.SreenWidth / 2) + 45)
                {
                    down = true;
                }
            }
            else
            {
                if (X > (Helper.SreenWidth / 2) - 45)
                {
                    down = true;
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
                    return;
                }
            }
        }

        void MoveDown()
        {

        }

        void SpawnNextSegment()
        {
            bool NoMore = true;
            int nextSegment = 0;

            for (int i = 1; i < 12; i++)
            {
                if (!TheCentipede[i].Enabled)
                {
                    nextSegment = i;
                    NoMore = false;
                    break;
                }
            }

            if (NoMore)
            {
                LogicRef.CentipedeRef.LevelStart = false;
                return;
            }

            if (X > 30 * nextSegment)
            {
                SpawnSegment(nextSegment, false, Vector3.Zero,
                    new Vector3(nextSegment * -30, 0, 0));
            }
        }

        void SpawnSegment(int segment, bool head, Vector3 rotation, Vector3 position)
        {
            TheCentipede[segment].SpawnIt(position, rotation, head, false,
                new Vector3(0, 1, 0), new Vector3(1, 0, 0),
                new Vector3(0.753f, 0.753f, 0.569f));
        }
    }
}
