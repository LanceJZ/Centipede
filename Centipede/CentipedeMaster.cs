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
        bool LevelStart;
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
            LevelStart = true;

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

            SpawnSegment(0, true, Vector3.Zero);
        }
        #endregion
        #region Update
        public override void Update(GameTime gameTime)
        {
            if (LevelStart)
            {
                Start();
            }

            base.Update(gameTime);
        }

        public bool CheckHit(BoundingSphere other)
        {
            for (int i = 0; i < TheCentipede.Count; i++)
            {
                if (TheCentipede[i].Enabled)
                {
                    if (TheCentipede[i].Sphere.Intersects(other))
                    {
                        if (TheCentipede[i].Head)
                        {
                            LogicRef.Points = 100;
                        }
                        else
                        {
                            LogicRef.Points = 10;
                        }

                        TheCentipede[i].Enabled = false;
                        LogicRef.BackgroundRef.AddMushroom(TheCentipede[i].Sphere);
                    }
                }
            }

            return false;
        }

        void SpawnSegment(int pod, bool head, Vector3 rotation)
        {
            TheCentipede[pod].SpawnIt(new Vector3(0, (Helper.ScreenHeight / 2) - 45, 0),
                rotation, head, new Vector3(0, 1, 0), new Vector3(1, 0, 0),
                new Vector3(0.753f, 0.753f, 0.569f));
        }

        void Start()
        {
            int nextPod = 0;

            for (int i = 1; i < 12; i++)
            {
                if (!TheCentipede[i].Enabled)
                {
                    nextPod = i;
                    break;
                }
            }

            if (nextPod == 0)
            {
                LevelStart = false;
                return;
            }

            if (TheCentipede[nextPod - 1].X > 30)
            {
                SpawnSegment(nextPod, false, Vector3.Zero);
            }
        }
        #endregion
    }
}
