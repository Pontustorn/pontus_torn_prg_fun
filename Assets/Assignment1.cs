using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{
    public Vector2 rectPosition;
    
    float handMovementx;
    float handMovementy;
    float ballMovementx;
    float ballMovementy;
    float realBallMovementx;
    float realBallMovementy;
    bool ifTrue = false;
    bool ifMoving = false;
    bool ballSpawned = false;
    bool isFalling = false;
    bool isJumping = false;
    // Start is called before the first frame update
    void Start()
    {
        StrokeWeight(1);



    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Background(Color.black);

        LetterP02();
        LetterO();
        LetterN();
        LetterT();
        LetterU();
        LetterS();
        StickFigure();
        StickFigureArm();
        BigLine();
        Hat();

        if(ballSpawned == true)
        {
            ball();

        }

        if (Input.GetKey(KeyCode.A))
        {
            if (ballSpawned == true)
                realBallMovementx -= 0.2f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (ballSpawned == true)
                realBallMovementx += 0.2f;
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            if (ballSpawned == true)
            {

                isJumping = true;
                
            }
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            ifMoving = true;
            ballSpawn();
            
           if(handMovementx <= 0)
            {
                ifTrue = true;
            } else if(handMovementx >= 2) {
                ifTrue = false;
            }
           
        } else
        {
            ifMoving = false;
            ballMovementx = 0;
            ballMovementy = 0;
        }

    }


    void LetterP02()
    {
        
        Circle(2.5f, 6, 2);
        Rect(1.5f, 7, 2.5f, 5);
        Line(1.5f, 7, 1.5f, 3);
        Stroke(0, 0, 0);
        Line(2.5f, 6.95f, 2.5f, 5.05f);
        Stroke(255, 255, 255);
        
    }

    private void LetterO()
    {
        
        Circle(5, 4.5f, 3);

    }

    private void LetterN()
    {
        Line(7, 6, 7, 3);
        Line(7, 6, 9, 3);
        Line(9, 3, 9, 6);
    }

    private void LetterT()
    {
        Line(11, 3, 11, 6);
        Line(9, 6, 13, 6);
    }

    private void LetterU()
    {
        Circle(15, 4.5f, 3);
        Rect(16.5f, 6, 13.5f, 4.5f);
        Stroke(0, 0, 0);
        Line(13.55f, 6, 16.45f, 6);
        Line(13.55f, 4.5f, 16.45f, 4.5f);
        Stroke(255, 255, 255);
    }

    private void LetterS()
    {

        Circle(18, 5.25f, 1.54f);
        Rect(18, 6.02f, 19.55f, 4.48f);
        Stroke(0, 0 ,0);
        Line(19.55f, 6.02f, 19.55f, 4.48f);
        Line(18, 6, 18, 4.5f);
        Line(19.60f, 4.48f, 18.01f, 4.48f);
        Line(19.60f, 6.02f, 18.78f, 6.02f);
        Stroke(255, 255, 255);
        Circle(18, 3.71f, 1.54f);
        Rect(18, 4.48f, 16.7f, 2.94f);
        Stroke(0, 0, 0);
        Line(18, 4.48f, 18, 2.94f);
        Line(16.7f, 4.48f, 16.7f, 2.94f);
        Line(17, 2.94f, 16.70f, 2.94f);
        Line(17.80f, 4.48f, 16.70f, 4.48f);
        Stroke(255, 255, 255);

    }

    private void StickFigure()
    {
        Line(32, 4, 30, 7);
        Line(30, 7, 28, 4);
        Line(30, 7, 30, 10);
        Line(27, 10, 32, 10);
        Circle(30, 13, 3);
    }

    private void BigLine()
    {
        Line(1, 2.75f, 30, 2.75f);
    }

    void StickFigureArm()
    {
        if (ifMoving == true)
        {
            
            if (ifTrue == true)
            {
                handMovementx += 0.1f;
                


            }
            else if (ifTrue == false)
            {
                handMovementx -= 0.1f;
                
                
            }
        }
        
        Line(32, 10, 34, 12);
        Line(34, 12, 34 + handMovementx, 14 + handMovementy);
    }

    void ballSpawn()
    {
        if (ifMoving == true && ballMovementx >= -2)
        {
            ballMovementx -= 0.2f;
            ballMovementy += 0.2f;
            
        } else if(ifMoving == true && ballMovementx <= -2)
        {
            ballMovementy -= 0.2f;

            if(ballMovementy <= -5)
            {
                ballSpawned = true;
                ballMovementx = 27;
                ballMovementy = 27;
            }
        }

        Circle(26 + ballMovementx, 9 + ballMovementy, 1);
    }

    void Hat()
    {
        Line(27, 10, 25, 8);
        Line(25.5f, 8.5f, 27, 7);
        Line(26.5f, 9.5f, 28, 8);
        Line(28, 8, 27, 7);
    }

    void ball()
    {
        Circle(24 + realBallMovementx, 4 + realBallMovementy, 1);



        if (isJumping == true && realBallMovementy < 2)
        {

            realBallMovementy += 0.1f;

            if(realBallMovementy >= 2)
            isJumping = false;
            isFalling = true;

        }
        else if (isFalling == true && realBallMovementy > 0)
        {

                realBallMovementy -= 0.1f;

        }
           
        
    }
    
}
