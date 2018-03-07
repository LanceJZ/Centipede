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
        const int Rows = 28;
        const int Columns = 27;
        Mushroom[,] TheMushrooms = new Mushroom[Rows, Columns];
        #endregion
        #region Properties
        public Mushroom[,] Mushrooms { get => TheMushrooms; }
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
            for (int column = 0; column < Columns; column++)
            {
                for (int row = 0; row < Rows; row++)
                {
                    TheMushrooms[row, column] = new Mushroom(Game, CameraRef, LogicRef);
                    TheMushrooms[row, column].Setup(new Vector3(-405 + (30 * row),
                        392 - (30 * column), 0));
                    TheMushrooms[row, column].ColorIt(new Vector3(0, 1, 0), new Vector3(1, 0, 0));
                }
            }

            Setup();
        }
        #endregion
        #region Update
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
        #endregion
        public Mushroom HitMushroom(BoundingSphere other)
        {
            for (int column = 0; column < Columns; column++)
            {
                for (int row = 0; row < Rows; row++)
                {
                    //if (TheMushrooms[row, column].Active)
                    //{
                        if (TheMushrooms[row, column].Sphere.Intersects(other))
                        {
                            return TheMushrooms[row, column];
                        }
                    //}
                }
            }

            return null;
        }

        public void AddMushroom(BoundingSphere segment)
        {
            for (int column = 0; column < Columns; column++)
            {
                for (int row = 0; row < Rows; row++)
                {
                    if (!TheMushrooms[row, column].Active)
                    {
                        if (TheMushrooms[row, column].Sphere.Intersects(segment))
                        {
                            TheMushrooms[row, column].Spawn();
                            return;
                        }
                    }
                }
            }
        }

        void Setup()
        {
            for (int column = 2; column < Columns; column++)
            {
                int[] row = new int[2];
                row[0] = Helper.RandomMinMax(0, Rows - 1);

                do
                {
                    row[1] = Helper.RandomMinMax(0, Rows - 1);
                }
                while (row[0] == row[1]);

                for (int i = 0; i < 2; i++)
                {
                    if (Helper.RandomMinMax(0, 100) < 80)
                    {
                        TheMushrooms[row[i], column].Spawn();
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
