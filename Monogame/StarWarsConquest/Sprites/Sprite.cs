// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using System.Runtime.Intrinsics.X86;
// using Microsoft.Xna.Framework;
// using Microsoft.Xna.Framework.Graphics;
// using Microsoft.Xna.Framework.Input;

// namespace StarWarsConquest;

// public class Sprite
// {
//     private readonly float scale;
//     public Texture2D texture;
//     public Vector2 position;
//     public Rectangle Rect
//     {
//         get
//         {
//           return new Rectangle(
//             (int)position.X,
//             (int)position.Y,
//             texture.Width * (int)scale,
//             texture.Height * (int)scale
//           );
//         }
//     }
//     public Sprite(string texturename, int positionX, int positionY, float scale)
//     {
//       texture = new Content.Load<Texture2D>(texturename);
//       position = new Vector2(positionX, positionY);
//       // this.position = position;
//       this.scale = scale;
//     }

//     public virtual void Update(GameTime gameTime){}
//     public virtual void Draw(SpriteBatch spriteBatch)
//     {
//         spriteBatch.Draw(texture, Rect, Color.White);
//     }
// };


using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace StarWarsConquest
{
    class Sprite
    {
        private float scale;
        private int width;
        private Texture2D texture;
        private Vector2 position;
        // public Texture2D texture;
        // public Vector2 position;
        public Rectangle drect
        {
            get
            {
                return new Rectangle(
                    (int)(position.X-texture.Width*scale/2),
                    (int)(position.Y-texture.Height*scale/2),
                    (int)(texture.Width*scale),
                    (int)(texture.Height*scale)
                );
            }
        }

        public Sprite(Texture2D texture, int width = 300)
        {
            this.texture = texture;
            this.width = width;
            this.scale = (float)width/texture.Width;
        }

        public Sprite(Texture2D texture, Vector2 position, int width = 300)
        {
            this.texture = texture;
            this.position = position;
            this.width = width;
            this.scale = (float)width/texture.Width;
        }

        public float GetScale()
        {
            return scale;
        }

        public int GetWidth()
        {
            return width;
        }

        public Texture2D GetTexture()
        {
            return texture;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }

        public virtual void Update(GameTime gameTime) {}

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, drect, Color.White);
        }
    }
}
