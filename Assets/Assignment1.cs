using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{
    float x = 34;
    float x2;
    float x3;
    float y = 12;
    float y2;
    float y3;
    int maxWave = 2;
    // Start is called before the first frame update
    void Start()
    {
        StrokeWeight(1);
       

        
    }

    // Update is called once per frame
    void Update()
    {



        Background(Color.black);
        
        //LetterP();
        LetterO();
        LetterN();
        LetterT();
        LetterU();
        LetterS();
        StickFigure();
        StickFigureArm();
        LetterP02();
        UnderLine();
        //LetterU2();







    }

    //private void LetterP()
    //{
        
    //    Line(1, 6, 1, 1);
    //    Line(1, 6, 4, 6);
    //    Line(4, 6, 4, 3);
    //    Line(4, 3, 1, 3);


    //}
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
        Line(9, 5.85f, 13, 5.85f);
    }

    private void LetterU()
    {
        Circle(15, 4.5f, 3);
        Rect(16.5f, 7, 13.5f, 4.5f);
        Stroke(0, 0, 0);
        Line(13.55f, 7, 16.45f, 7);
        Line(13.55f, 4.5f, 16.45f, 4.5f);
        Stroke(255, 255, 255);
    }
    //private void LetterU2()
    //{
    //    Circle(8, 4.5f, 3);
    //    Rect(9.5f, 7, 6.5f, 4.5f);
    //    Stroke(0, 0, 0);
    //    Line(6.55f, 7, 9.45f, 7);
    //    Line(6.55f, 4.5f, 9.45f, 4.5f);
    //    Stroke(255, 255, 255);
    //}

    private void LetterS()
    {
        Circle(19, 4, 2);
        Rect(19, 3, 17, 5);
        Circle(18, 6, 2);
        Rect(20, 5, 18, 7);
        Stroke(0, 0, 0);
        Line(17, 3.20f, 17, 4.80f);
        Line(19, 3.20f, 19, 4.80f);
        Line(20, 5, 20, 7);
        Line(18, 5, 18, 7);
        Stroke(255, 255, 255);



        //Line(22, 1, 24, 1);
        //Line(24, 1, 24, 3.5f);
        //Line(24, 3.5f, 22, 3.5f);
        //Line(22, 3.5f, 22, 6);
        //Line(22, 6, 24, 6);
    }

    private void StickFigure()
    {
        
        Line(32, 4, 30, 7);
        Line(30, 7, 28, 4);
        Line(30, 7, 30, 10);
        Line(28, 10, 32, 10);
        Circle(30, 13, 3);

       
    }

    private void UnderLine()
    {
        Line(1, 2.75f, 30, 2.75f);
    }

    private void StickFigureArm()
    {
        

        Line(32, 10, 34, 12);
    }
    
}
