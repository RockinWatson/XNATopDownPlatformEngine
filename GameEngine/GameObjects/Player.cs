using System;
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
    public class Player : Character
    {
        public Player() {

        }

        public Player(Vector2 inputPosition) {
            position = inputPosition;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Load(ContentManager content)
        {
            image = TextureLoader.Load("sprite", content);
            base.Load(content);
        }

        public override void Update(List<GameObject> objects, Map map)
        {
            CheckInput(objects, map);
            base.Update(objects, map);
        }

        private void CheckInput(List<GameObject> objects, Map map) {

            if (!Character.applyGravity)
            {
                if (Input.IsKeyDown(Keys.D) == true)
                {
                    MoveRight();
                }
                else if (Input.IsKeyDown(Keys.A) == true)
                {
                    MoveLeft();
                }

                if (Input.IsKeyDown(Keys.S) == true)
                {
                    MoveDown();
                }
                else if (Input.IsKeyDown(Keys.W) == true)
                {
                    MoveUp();
                }
            }
            else
            {
                if (Input.IsKeyDown(Keys.D) == true)
                {
                    MoveRight();
                }
                else if (Input.IsKeyDown(Keys.A) == true)
                {
                    MoveLeft();
                }

                if (Input.KeyPressed(Keys.Space) == true)
                {
                    Jump(map);
                }
            }
        }
    }
}
