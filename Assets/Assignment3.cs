using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment3 : ProcessingLite.GP21
{

   
	
	
	Circle circle;
	Line line;
	Line line2;


	// Start is called before the first frame update
	void Start()
    {
		circle = new Circle(new Vector2(3, 5), 2);
		line = new Line(1, 8, 1, 14);
		line2 = new Line(Width - 1, 8, Width - 1, 14);
		

		
    }

    // Update is called once per frame
    

    void Update()
    {
		Background(255,255,255);

		circle.Draw(line, line2);

		if (Input.GetMouseButton(0))
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Line(circle.vectorPos.x, circle.vectorPos.y, mousePos.x, mousePos.y);
			Vector2 direction = new Vector2(circle.vectorPos.x - mousePos.x, circle.vectorPos.y - mousePos.y);
			circle.Move(0.8f, direction);
		}

		

		
		line.DrawLine();
		line2.DrawLine();
		MoveLine();

	}

	void MoveLine()
    {
		if(Input.GetKey(KeyCode.W))
        {
			line.MoveLineUp();
        }

		if (Input.GetKey(KeyCode.S))
        {
			line.MoveLineDown();
        }

		if(Input.GetKey(KeyCode.UpArrow))
        {
			line2.MoveLineUp();
        }

		if (Input.GetKey(KeyCode.DownArrow))
		{
			line2.MoveLineDown();
		}
	}
	
}



public class Circle : ProcessingLite.GP21
{
	public Vector2 vectorPos;
	public float diameter;
	public Vector2 velocity = new Vector2(0, 0);
	
	public Circle(Vector2 vectorPos, float diameter)
    {
		this.vectorPos = vectorPos;
		this.diameter = diameter;
    }

    public void Draw(Line line, Line line2)
    {
		vectorPos.x += velocity.x * Time.deltaTime;
		vectorPos.y += velocity.y * Time.deltaTime;

		Circle(vectorPos.x, vectorPos.y, diameter);

        

        if (vectorPos.y > Height - diameter / 2 || vectorPos.y < 0 || vectorPos.y < diameter/2)
        {
			velocity.y *= -1;
			Fill(Random.Range(1, 255), Random.Range(1, 255), Random.Range(1, 255));
		}

		if(line.y1 < vectorPos.y && line.y2 > vectorPos.y && vectorPos.x - diameter/2  <= line.x1)
		{
			velocity.x *= -1;
		}

		if(line2.y1 < vectorPos.y && line2.y2 > vectorPos.y && vectorPos.x + diameter / 2 >= line2.x1)
        {
			velocity.x *= -1;
		}
		
    }

    public void Move(float speed, Vector2 direction)
    {
		velocity.x = (speed * direction.x) * -1;
		velocity.y = (speed * direction.y) * -1;


		
	}
}

public class Line : ProcessingLite.GP21
{
	public float x1;
	public float x2;
	public float y1;
	public float y2;

	public Line(float x1, float y1, float x2, float y2)
    {
		this.x1 = x1;
		this.x2 = x2;
		this.y1 = y1;
		this.y2 = y2;
		
	}

	public void DrawLine()
    {
		StrokeWeight(2);
		Stroke(0);
		Line(x1, y1, x2, y2);
    }

	public void MoveLineUp()
    {
		y1 += 0.085f;
		y2 += 0.085f;
	}

	public void MoveLineDown()
    {
		y1 -= 0.085f;
		y2 -= 0.085f;
	}
}


