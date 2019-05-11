using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameEngine
{
    public class Map
    {
        public List<Wall> walls = new List<Wall>();
        Texture2D wallImage;

        public int mapWidth = 15;
        public int mapHeight = 9;
        public int tileSize = 128; //in pixels

        public void Load(ContentManager content) {
            wallImage = TextureLoader.Load("pixel", content);
        }

        public Rectangle CheckCollision(Rectangle input) {
            for (int i = 0; i < walls.Count; i++)
            {
                if (walls[i] != null && walls[i].wall.Intersects(input) == true)
                {
                    return walls[i].wall;
                }
            }

            return Rectangle.Empty;
        }

        public void DrawWalls(SpriteBatch spriteBatch) {
            foreach (var wall in walls)
            {
                if (wall != null && wall.active == true)
                {
                    spriteBatch.Draw(wallImage, new Vector2(wall.wall.X, wall.wall.Y), wall.wall, Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, .7f);
                }
            }
        }
    }

    public class Wall
    {
        public Rectangle wall;
        public bool active = true;

        public Wall() { }

        public Wall(Rectangle inputRect) {
            wall = inputRect;
        }
    }
}
