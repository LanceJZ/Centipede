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
        List<CentipedeSegment> CentipedeSegments = new List<CentipedeSegment>();
        List<CentipedeTrain> TheCentipede = new List<CentipedeTrain>();
        public bool LevelStart;
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
            //for (int i = 0; i < 12; i++)
            //{
            //TheCentipede[i] = new CentipedeSegment(Game, CameraRef, LogicRef);
            //}

            TheCentipede.Add(new CentipedeTrain(Game, CameraRef, LogicRef));

        }
        #endregion
        #region Update
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public bool CheckHit(BoundingSphere other)
        {
            //bool AllDead = true;

            //for (int i = 0; i < 12; i++)
            //{
            //    if (TheCentipede[i].Enabled)
            //    {
            //        if (TheCentipede[i].Sphere.Intersects(other))
            //        {
            //            if (TheCentipede[i].Head)
            //            {
            //                LogicRef.Points = 100;
            //            }
            //            else
            //            {
            //                LogicRef.Points = 10;
            //            }

            //            LogicRef.BackgroundRef.AddMushroom(TheCentipede[i].Sphere);
            //            TheCentipede[i].Enabled = false;
            //            NewHead();
            //            return true;
            //        }

            //        AllDead = false;
            //    }
            //}

            //if (AllDead)
            //{
            //    NewWave();
            //    return true;
            //}

            return false;
        }

        public bool CheckHitSelf(CentipedeSegment other)
        {
            //for (int i = 0; i < 12; i++)
            //{
            //    if (TheCentipede[i].Enabled)
            //    {
            //        if (other != TheCentipede[i])
            //        {
            //            if (TheCentipede[i].Sphere.Intersects(other.Sphere))
            //            {
            //                return true;
            //            }
            //        }
            //    }
            //}

            return false;
        }

        public void NewHead()
        {
            //for (int i = 0; i < 11; i++)
            //{
            //    if (!TheCentipede[i].Enabled)
            //    {
            //        TheCentipede[i + 1].Head = true;
            //    }
            //}

            //if (TheCentipede[11].Enabled && !TheCentipede[10].Enabled)
            //{
            //    TheCentipede[11].Head = true;
            //}
        }

        public void NewWave()
        {
            LevelStart = true;
            LogicRef.BackgroundRef.NewWave();

            foreach (CentipedeTrain train in TheCentipede)
            {
                train.Deactivate();
            }

            TheCentipede[0].NewWave();
        }

        void SpawnSegment(int segment, bool head, Vector3 rotation)
        {
            CentipedeSegments[segment].SpawnIt(new Vector3(0, (Helper.ScreenHeight / 2) - 45, 0),
                rotation, head, true, new Vector3(0, 1, 0), new Vector3(1, 0, 0),
                new Vector3(0.753f, 0.753f, 0.569f));
        }

        void SpawnNextSegment()
        {
            bool NoMore = true;
            int nextSegment = 0;

            //for (int i = 1; i < 12; i++)
            //{
            //    if (!TheCentipede[i].Enabled)
            //    {
            //        nextSegment = i;
            //        NoMore = false;
            //        break;
            //    }
            //}

            //if (NoMore)
            //{
            //    LevelStart = false;
            //    return;
            //}

            //if (TheCentipede[nextSegment - 1].X > 30)
            //{
            //    SpawnSegment(nextSegment, false, Vector3.Zero);
            //}
        }
        #endregion
    }
}
