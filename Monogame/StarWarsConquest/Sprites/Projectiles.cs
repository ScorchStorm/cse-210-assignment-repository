using System;

namespace StarWarsConquest;

class Projectile : Sprite
{
    private Vector2 velocity;
    private float speed;
    private Vector2 startPoint;
    private Vector2 endPoint;

    public Projectile(Vector2 velocity, Vector2 startPoint, Vector2 endPoint, float speed, Texture2D texture, int width) : base(texture, width)
    {
        this.velocity = velocity;
        this.startPoint = startPoint;
        this.endPoint = endPoint;
        this.speed = speed;

        CalculateVelocity();
    }

    public void CalculateVelocity()
    {
        double theta = Math.Atan2((endPoint.Y-startPoint.Y),(endPoint.X-startPoint.X));
        float rotation = (float)theta; //might not be the proper way to implement this, but it (should) work
        velocity.X = (float)(speed*Math.Cos(theta));
        velocity.Y = (float)(speed*Math.Sin(theta));
    }

    
}