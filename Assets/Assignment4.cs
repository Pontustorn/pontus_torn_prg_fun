using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21
{
    float posX = 3;
    float posY = 5;
    float posX2 = 3;
    float posY2 = 7;
    float diameter = 2;
    float speed = 5;
    Vector2 acceleration = new Vector2(0, 0);
    float acc = 0.1f;
    float maxSpeed = 20;
    bool gravityOn = false;
    

    void Start()
    {
        float x = Width / 2; //middle of the screen
    }

    void Update()
    {
        Background(0);
        //Background(50, 166, 240);

        Debug.Log(acceleration.x);

        posX = posX + Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        posY = posY + Input.GetAxis("Vertical") * Time.deltaTime * speed;

        


        if (Input.GetKey(KeyCode.W))
        {
            acceleration.y += acc * Time.deltaTime;
            
        }

        else if (Input.GetKey(KeyCode.S))
        {

            acceleration.y -= acc * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            acceleration.x -= acc * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            acceleration.x += acc * Time.deltaTime;
        }

        else
        {
            if (acceleration.x > 0)
            {
                acceleration.x -= 0.2f * Time.deltaTime;
            }
            if (acceleration.x < 0)
            {
                acceleration.x += 0.2f * Time.deltaTime;
            }
            if (acceleration.y > 0)
            {
                acceleration.y -= 0.2f * Time.deltaTime;
            }
            if (acceleration.y > 0)
            {
                acceleration.y -= 0.2f * Time.deltaTime;
            }
        }

        if(Input.GetKey(KeyCode.G))
        {
            

            if(gravityOn == false)
            {
                gravityOn = true;
            }
            
            else
            {
                gravityOn = false;
            }
        }

        posX2 += acceleration.x;
        posY2 += acceleration.y;


        if(posX2 <= -2)
        {
            posX2 = Width;
        }

        if(posX2 >= Width +2)
        {
            posX2 = -2;
        }

        if(posY2 <= -2)
        {
            posY2 = Height;
        }

        if (posY2 >= Height + 2)
        {
            posY2 = -2;
        }

        if(gravityOn == true)
        {
            if (posY2 > 1)
            {
                acceleration.y -= 0.5f * Time.deltaTime;
            }

            else
            {
                acceleration.y = 0;
            }
        }

        Circle(posX, posY, diameter);
        Circle(posX2, posY2, diameter);
    }
}
