using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace StarWarsConquest;

public class Sprite
{
    private readonly float SCALE;
    public Texture2D texture;
    public Vector2 position;
    public Rectangle Rect
    {
        get
        {
          return new Rectangle(
            (int)position.X,
            (int)position.Y,
            texture.Width * (int)SCALE,
            texture.Height * (int)SCALE
          );
        }
    }
    public Sprite(string texturename, int positionX, int positionY, float SCALE)
    {
      this.texture = Content.Load<Texture2D>("texturename");
      this.position = Vector2(positionX, positionY);
      // this.position = position;
      this.SCALE = SCALE;
    }

    public virtual void Update(GameTime gameTime){}
    public virtual void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, Rect, Color.White);
    }
};