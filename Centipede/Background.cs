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
        public List<Mushroom> Mushrooms { get => TheMushrooms; }
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
            for (int i = 0; i < 54; i++)
            {
                TheMushrooms.Add(new Mushroom(Game, CameraRef, LogicRef));
            }

            Setup(new Vector3(0, 1, 0), new Vector3(1, 0, 0));
        }
        #endregion
        #region Update
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
        #endregion
        public bool HitMushroom(ref int mushroom, BoundingSphere other)
        {
            for(int i = 0; i < TheMushrooms.Count; i++)
            {
                if (TheMushrooms[i].Enabled)
                {
                    if (TheMushrooms[i].Sphere.Intersects(other))
                    {
                        mushroom = i;
                        return true;
                    }
                }
            }

            return false;
        }

        void Setup(Vector3 color, Vector3 outlineColor)
        {
            int count = 0;

            for (int row = 0; row < 25; row++)
            {
                int[] colom = new int[2];
                colom[0] = Helper.RandomMinMax(0, 27);

                do
                {
                    colom[1] = Helper.RandomMinMax(0, 27);
                }
                while (colom[0] == colom[1]);

                for (int i = 0; i < 2; i++)
                {
                    if (Helper.RandomMinMax(0, 100) < 80)
                    {
                        TheMushrooms[count].SpawnIt(new Vector3(-405 + (30 * colom[i]),
                            332 - (30 * row), 0), color, outlineColor);
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
