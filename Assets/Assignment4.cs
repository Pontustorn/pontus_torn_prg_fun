using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    Vector2 circlePos;
    Vector2 wrapPos;
    Vector2 acceleration = new Vector2(0, 0);

    float diameter = 2;
    float accIncrease = 0.2f;
    float accDecrease = 0.025f;
    float devRad;
    float gravity = 9.82f;

    bool gravitySwitch = false;
    
    
    

    void Start()
    {
      
        devRad = diameter / 2;
        circlePos = new Vector2(3, 5);
        
    }

    void Update()
    {
        Background(0);
        helloWorld();
        MovementWithAcc();
        Gravity();

        Circle(circlePos.x, circlePos.y, diameter);

        circlePos.x += acceleration.x;
        circlePos.y += acceleration.y;
        
        
    }

    void helloWorld()
    {
        
        if (circlePos.x - devRad <= 0)
        {
            wrapPos = new Vector2(Width + circlePos.x, circlePos.y);
            Circle(wrapPos.x, wrapPos.y, diameter);
        }

        if (circlePos.x + devRad >= Width)
        {
            wrapPos = new Vector2(circlePos.x - Width, circlePos.y);
            Circle(wrapPos.x, wrapPos.y, diameter);
        }

        if(circlePos.y - devRad <= 0)
        {
            wrapPos = new Vector2(circlePos.x, Height + circlePos.y);
            Circle(wrapPos.x, wrapPos.y, diameter);
        }

        if (circlePos.y + devRad >= Height)
        {
            wrapPos = new Vector2(circlePos.x, circlePos.y - Height);
            Circle(wrapPos.x, wrapPos.y, diameter);
        }

        if (circlePos.x + devRad <= 0 || circlePos.x - devRad >= Width || circlePos.y + devRad <= 0 || circlePos.y - devRad >= Height)
        {
            circlePos.x = wrapPos.x;
            circlePos.y = wrapPos.y;
        }
    }

    void MovementWithAcc()
    {
        if (Input.GetKey(KeyCode.W))
        {
            acceleration.y += accIncrease * Time.deltaTime;

        }

        else if (Input.GetKey(KeyCode.S))
        {

            acceleration.y -= accIncrease * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            acceleration.x -= accIncrease * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            acceleration.x += accIncrease * Time.deltaTime;
        }

        else
        {
            if (acceleration.x > 0)
            {
                acceleration.x -= accDecrease * Time.deltaTime;
            }
            if (acceleration.x < 0)
            {
                acceleration.x += accDecrease * Time.deltaTime;
            }
            if (acceleration.y > 0)
            {
                acceleration.y -= accDecrease * Time.deltaTime;
            }
            if (acceleration.y < 0)
            {
                acceleration.y += accDecrease * Time.deltaTime;
            }

            else
            {
                acceleration.x = 0;
                acceleration.x = 0;
            }
        }
    }

    void Gravity()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            if(gravitySwitch == false)
            {
                gravitySwitch = true;
            }
            else
            {
                gravitySwitch = false;
            }
        }

        if(gravitySwitch == true)
        {
            if (circlePos.y - devRad >= 0.1f)
            {
                circlePos.y -= gravity * Time.deltaTime;
            }
        }
    }
}
