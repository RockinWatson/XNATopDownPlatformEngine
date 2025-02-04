﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameEngine.GameObjects
{
    public class GameObject
    {
        protected Texture2D image;
        public Vector2 position;
        public Color drawColor = Color.White;
        public float scale = 1f, rotation = 0f;
        public float layerDepth = .5f;
        public bool active = true;
        protected Vector2 center;

        public bool collidable = true;
        protected int boundingBoxWidth, boundingBoxHeight;
        protected Vector2 boundingBoxOffset;
        Texture2D boundingBoxImage;
        const bool drawBoundingBoxes = true;
        protected Vector2 direction = new Vector2(1, 0);

        public Rectangle BoundingBox {
            get {
                return new Rectangle((int)(position.X + boundingBoxOffset.X), (int)(position.Y + boundingBoxOffset.Y), boundingBoxWidth, boundingBoxHeight);
            }
        }

        public GameObject() {

        }

        public virtual void Initialize() {

        }

        public virtual void Load(ContentManager content) {
            boundingBoxImage = TextureLoader.Load("pixel", content);

            CalculateCenter();

            if (image != null)
            {
                boundingBoxWidth = image.Width;
                boundingBoxHeight = image.Height;
            }
        }

        public virtual void Update(List<GameObject> objects, Map map) {

        }

        public virtual bool CheckCollision(Rectangle input) {
            return BoundingBox.Intersects(input);
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            if (boundingBoxImage != null && drawBoundingBoxes && active)
            {
                spriteBatch.Draw(boundingBoxImage, new Vector2(BoundingBox.X, BoundingBox.Y), BoundingBox, new Color(120,120,120,120), 0f, Vector2.Zero, 1f, SpriteEffects.None, .1f);
            }

            if (image != null && active)
            {
                spriteBatch.Draw(image, position, null, drawColor, rotation, Vector2.Zero, scale, SpriteEffects.None, layerDepth);
            }  
        }

        private void CalculateCenter() {
            if (image == null)
            {
                return;
            }

            center.X = image.Width / 2;
            center.Y = image.Height / 2;
        }
    }
}
