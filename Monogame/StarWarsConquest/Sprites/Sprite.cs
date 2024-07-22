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
//     private readonly float SCALE;
//     public Texture2D texture;
//     public Vector2 position;
//     public Rectangle Rect
//     {
//         get
//         {
//           return new Rectangle(
//             (int)position.X,
//             (int)position.Y,
//             texture.Width * (int)SCALE,
//             texture.Height * (int)SCALE
//           );
//         }
//     }
//     public Sprite(string texturename, int positionX, int positionY, float SCALE)
//     {
//       texture = new Content.Load<Texture2D>(texturename);
//       position = new Vector2(positionX, positionY);
//       // this.position = position;
//       this.SCALE = SCALE;
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
    public class Sprite
    {
        private readonly float SCALE;
        public Texture2D texture;
        public Vector2 position;
        public Rectangle drect
        {
            get
            {
                return new Rectangle(
                    (int)position.X,
                    (int)position.Y,
                    (int)(texture.Width * SCALE),
                    (int)(texture.Height * SCALE)
                );
            }
        }

        public Sprite(int SCALE = 1)
        {
            this.SCALE = SCALE;
        }
        public Sprite(Texture2D texture, int SCALE = 1)
        {
            this.texture = texture;
            this.SCALE = SCALE;
        }
        public Sprite(Texture2D texture, Vector2 position, int SCALE = 1)
        {   
            this.texture = texture;
            this.position = position;
            this.SCALE = SCALE;
        }

        public virtual void Update(GameTime gameTime) {}

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, drect, Color.White);
        }
    }
}
