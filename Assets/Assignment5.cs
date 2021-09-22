using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : ProcessingLite.GP21
{
    PlayerCircle playercircle;
    int numberOfBalls = 10;
    Ball[] balls;
    Ball enemyBall;
    // Start is called before the first frame update
    void Start()
    {
        playercircle = new PlayerCircle(Width / 2, Height / 2, 10, 2);
        balls = new Ball[numberOfBalls];
        //A loop that can be used for creating multiple balls.
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i] = new Ball();
        }


    }

    // Update is called once per frame
    void Update()
    {
        
        Background(0);
        playercircle.Draw();
        playercircle.PlayerMovement();
        playercircle.borderWrap();
        
        
    

        //Tell each ball to update it's position
        for (int i = 0; i < balls.Length; i++)
        {
            balls[i].UpdatePos();
            balls[i].Draw();
            balls[i].borderWrap();
        }

    }

    
}

public class PlayerCircle : ProcessingLite.GP21
{
    Vector2 playerPosition;
    Vector2 wrapPos;
    float speed;
    float diameter;
    float radius;
    public PlayerCircle(float x, float y, float speed, float diameter)
    {
        //Set our position when we create the code.
        playerPosition = new Vector2(x, y);
        this.speed = speed;
        this.diameter = diameter;
        radius = diameter / 2;

        //Create the velocity vector and give it a random direction.
        
        
    }

    public void Draw()
    {
        Stroke(255, 0, 0);
        Fill(255, 0, 0);
        Circle(playerPosition.x, playerPosition.y, diameter);
        Fill(255, 255, 255);
        Stroke(255, 255, 255);
    }

    public void PlayerMovement()
    {
        playerPosition.x = playerPosition.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        playerPosition.y = playerPosition.y + Input.GetAxis("Vertical") * Time.deltaTime * speed;
    }

    public void borderWrap()
    {
        if (playerPosition.x - radius <= 0)
        {
            wrapPos = new Vector2(Width + playerPosition.x, playerPosition.y);
            Circle(wrapPos.x, wrapPos.y, diameter);
        }

        if (playerPosition.x + radius >= Width)
        {
            wrapPos = new Vector2(playerPosition.x - Width, playerPosition.y);
            Circle(wrapPos.x, wrapPos.y, diameter);
        }

        if (playerPosition.y - radius <= 0)
        {
            wrapPos = new Vector2(playerPosition.x, Height + playerPosition.y);
            Circle(wrapPos.x, wrapPos.y, diameter);
        }

        if (playerPosition.y + radius >= Height)
        {
            wrapPos = new Vector2(playerPosition.x, playerPosition.y - Height);
            Circle(wrapPos.x, wrapPos.y, diameter);
        }

        if (playerPosition.x + radius <= 0 || playerPosition.x - radius >= Width || playerPosition.y + radius <= 0 || playerPosition.y - radius >= Height)
        {
            playerPosition.x = wrapPos.x;
            playerPosition.y = wrapPos.y;
        }

    }
}

//We still need to inherence from ProcessingLite
public class Ball : ProcessingLite.GP21
{
    //Our class variables
    public Vector2 position;
    public Vector2 velocity = new Vector2(3, 3);
    public float diameter;
    Color color;
    Color strokeColor;
    float radius;

    //Ball Constructor, called when we type new Ball(x, y);
    public Ball()
    {
        diameter = Random.Range(0.5f, 1.5f);
        position.x = Random.Range(0 + diameter, Width - diameter);
        position.y = Random.Range(0 + diameter, Height - diameter);
        velocity.x = Random.Range(-7, 7);
        velocity.y = Random.Range(-7, 7);
        radius = diameter / 2;

    }

    //Draw our ball
    public void Draw()
    {
        Circle(position.x, position.y, diameter);
    }

    //Update our ball
    public void UpdatePos()
    {
        position += velocity * Time.deltaTime;
    }

    public void borderWrap()
    {
        if (position.y > Height - radius || position.y - radius < 0)
        {
            velocity.y *= -1;
        }

        if (position.x > Width - radius || position.x - radius < 0)
        {
            velocity.x *= -1;
        }
    }


}


