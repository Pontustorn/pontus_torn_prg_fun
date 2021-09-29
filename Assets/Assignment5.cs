using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assignment5 : ProcessingLite.GP21
{
    PlayerCircle playercircle;
    public int numberOfBalls = 30;
    int amountOfBalls = 10;
    List<Ball> balls = new List<Ball>();
    bool gameOver = false;
    float timer = 5;
    public GameObject loseText;
    
    
   
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        playercircle = new PlayerCircle(Width / 2, Height / 2, 10, 2);
        
        //A loop that can be used for creating multiple balls.
        for (int i = 0; i < amountOfBalls; i++)
        {
            
                balls.Add(new Ball());
                
            
        }

        


    }

    

    // Update is called once per frame
    void Update()
    {
        Text myText = GameObject.Find("Canvas/BallText").GetComponent<Text>();
        myText.text = "Amount of balls:" + balls.Count.ToString();


        timer -= Time.deltaTime;
        if (gameOver == false)
        {

            Background(0);
            playercircle.Draw();
            playercircle.PlayerMovement();
            playercircle.borderWrap();

            if(timer <= 0)
            {
                balls.Add(new Ball());
                timer = 3;
            }
           


            //Tell each ball to update it's position
            foreach(Ball ball in balls)
            {
                ball.UpdatePos();
                ball.Draw();
                ball.borderWrap();
                

            }


            foreach (Ball ball in balls)
            {

                float distance = Vector2.Distance(ball.position, playercircle.playerPosition);

                if (distance <= (ball.diameter / 2 + playercircle.diameter / 2))
                {
                    gameOver = true;
                }

                ball.UpdatePos();
                ball.Draw();
            }


        }

        if (gameOver == true)
        {

            Background(0);
            loseText.SetActive(true);
            
            
        }

        if(Input.GetKey(KeyCode.R))
        {
            balls.Clear();
            gameOver = false;
            loseText.SetActive(false);
            Start();
        }
    }


}



public class PlayerCircle : ProcessingLite.GP21
{
    public Vector2 playerPosition;
    public Vector2 wrapPos;
    public float speed;
    public float diameter;
    public float radius;
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
        Stroke(255,255,255);
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

            Stroke(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
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

    bool CircleCollision(float x1, float y1, float size1, float x2, float y2, float size2)
    {
        float maxDistance = size1 + size2;

        //first a quick check to see if we are too far away in x or y direction
        //if we are far away we don't collide so just return false and be done.
        if (Mathf.Abs(x1 - x2) > maxDistance || Mathf.Abs(y1 - y2) > maxDistance)
        {
            return false;
        }
        //we then run the slower distance calculation
        //Distance uses Pythagoras to get exact distance, if we still are to far away we are not colliding.
        else if (Vector2.Distance(new Vector2(x1, y1), new Vector2(x2, y2)) > maxDistance)
        {
            return false;
        }
        //We now know the points are closer then the distance so we are colliding!
        else
        {
            return true;
        }
    }

    //A better way to do this is to have a circle object and pass the objects in to the function,
    //then we just have to pass 2 objects instead of 6 different values.
}




