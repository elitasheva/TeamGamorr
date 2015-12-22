using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using TeamGamorr.Interfaces;

namespace TeamGamorr.Buttons
{
    public abstract class Button : IButton
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle rectangle;
        private Vector2 size;
        private Color colour = new Color(255, 255, 255, 255);
        private bool down;
        private bool isClicked;

        protected Button(Texture2D texture, GraphicsDevice graphics)
        {   
            this.Texture = texture;
            this.IsClicked = isClicked;
            size = new Vector2(graphics.Viewport.Width / 1.5f, graphics.Viewport.Height / 3);
        }

        public Texture2D Texture { get; set; }

        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public Rectangle Rectangle
        {
            get { return this.rectangle; }
            set { this.rectangle = value; }
        }

        public Vector2 Size

        {
            get { return this.size; }
            set { this.size = value; }

        }

        public bool IsClicked
        {
            get { return this.isClicked; }
            set { this.isClicked = value; }
        }


        public void Update(MouseState mouse)
        {
            this.Rectangle = new Rectangle((int)this.Position.X, (int)this.Position.Y, (int)this.Size.X, (int)this.Size.Y);
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(this.Rectangle))
            {
                if (this.colour.A == 255)
                {
                    this.down = false;
                }

                if (this.colour.A == 0)
                {
                    this.down = true;
                }

                if (this.down)
                {
                    this.colour.A += 3;
                }
                else
                {
                    this.colour.A -= 3;
                }

                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    this.IsClicked = true;
                }
            }
            else if (this.colour.A < 255)
            {
                this.colour.A += 3;
                this.IsClicked = false;
            }
        }

        public void SetPosition(Vector2 newPosition)
        {
            this.Position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.Texture, this.Rectangle, this.colour);
        }
    }
}
