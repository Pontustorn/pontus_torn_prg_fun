using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2 : ProcessingLite.GP21
{

    float spaceBetweenLines = 0.2f;
    float x2 = 1;
    float y1 = 100;
    float ChangeValue = 3;
    

    void Start()
    {
        Background(Color.white);
        StrokeWeight(0.5f);

    }

    void Update()
    {


        for (int i = 0; i <= y1; i++)
        {

            float y = i * spaceBetweenLines;
            x2++;
            y1--;

            if (x2 % ChangeValue == 1)
            {
                Stroke(102, 255, 102);
            }
            else
            {
                Stroke(0, 0, 0);
            }
            //Draw a line from left side of screen to the right
            //this time modify the height depending on time passed

            Line(0, y1, x2, 0);
        }



    }
}
