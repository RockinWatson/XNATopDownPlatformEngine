using System;
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
    public class Bullet : GameObject
    {
        const float speed = 12f; //how fast bullet will move
        Character owner;

        int destroyTimer;
        const int maxTimer = 180;

        public Bullet() {
            active = false;
        }

        public override void Load(ContentManager content)
        {
            image = TextureLoader.Load("bullet", content);
            base.Load(content);
        }

        public override void Update(List<GameObject> objects, Map map)
        {
            if (!active)
            {
                return;
            }

            //Update movement
            

            base.Update(objects, map);
        }
    }
}
