﻿using System;
using System.Collections.Generic;
using System.Linq;
using GameEngine.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameEngine
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public List<GameObject> objects = new List<GameObject>();
        public Map map = new Map();

        public Game1() //This is the constructor, this function is called whenever the game class is created.
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// This function is automatically called when the game launches to initialize any non-graphic variables.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Automatically called when your game launches to load any game assets (graphics, audio etc.)
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            map.Load(Content);
            LoadLevel();
        }

        /// <summary>
        /// Called each frame to update the game. Games usually runs 60 frames per second.
        /// Each frame the Update function will run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            Input.Update();
            UpdateObjects();
            //Update the things FNA handles for us underneath the hood:
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game is ready to draw to the screen, it's also called each frame.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            //This will clear what's on the screen each frame, if we don't clear the screen will look like a mess:
            GraphicsDevice.Clear(Color.Khaki);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            DrawObjects();
            map.DrawWalls(spriteBatch);
            spriteBatch.End();

            //Draw the things FNA handles for us underneath the hood:
            base.Draw(gameTime);
        }

        public void LoadLevel() {
            objects.Add(new Player(new Vector2(640, 360)));

            //Add Walls
            map.walls.Add(new Wall(new Rectangle(256,256,256,256)));
            map.walls.Add(new Wall(new Rectangle(0, 650, 1280, 128)));

            LoadObjects();
        }

        public void LoadObjects() {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Initialize();
                objects[i].Load(Content);
            }
        }

        public void UpdateObjects() {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Update(objects, map);
            }
        }

        public void DrawObjects() {
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].Draw(spriteBatch);
            }
        }
    }
}
