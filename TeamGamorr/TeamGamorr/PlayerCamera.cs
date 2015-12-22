using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using TeamGamorr.Characters;

namespace WindowsGame1
{
    class PlayerCamera
    {
        public Matrix transform;
        private Viewport view;
        private Vector2 center;

        public PlayerCamera(Viewport newView)
        {
            this.view = newView;
        }

        public void update(GameTime gt, GoodCharacter p)
        {
            center = new Vector2(p.Collision.X - view.Width / 2, p.Collision.Y-view.Height /2);
            transform = Matrix.CreateScale(new Vector3(1, 1, 0))*
                        Matrix.CreateTranslation(new Vector3(-center.X, -center.Y, 0));
        }
    }
}
