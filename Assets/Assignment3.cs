using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment3 : ProcessingLite.GP21
{

   
	public Vector2 LinePosition;
	public Vector2 VectorDifference;
	Circle circle;


	// Start is called before the first frame update
	void Start()
    {
		circle = new Circle(new Vector2(3, 5), 5);
    }

    // Update is called once per frame
    

    void Update()
    {
		Background(0);

		circle.Draw();

		if (Input.GetMouseButton(0))
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Line(circle.vectorPos.x, circle.vectorPos.y, mousePos.x, mousePos.y);
			Vector2 direction = new Vector2(circle.vectorPos.x - mousePos.x, circle.vectorPos.y - mousePos.y);
			circle.Move(0.5f, direction);
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

    public void Draw()
    {
		vectorPos.x += velocity.x * Time.deltaTime;
		vectorPos.y += velocity.y * Time.deltaTime;

		Circle(vectorPos.x, vectorPos.y, diameter);

        if (vectorPos.x > Width - diameter / 2 || vectorPos.x < 0 || vectorPos.x < diameter/2)
        {
			velocity.x *= -1;
			Fill(Random.Range(1, 255), Random.Range(1, 255), Random.Range(1,255));
		}

        if (vectorPos.y > Height - diameter / 2 || vectorPos.y < 0 || vectorPos.y < diameter/2)
        {
			velocity.y *= -1;
			Fill(Random.Range(1, 255), Random.Range(1, 255), Random.Range(1, 255));
		}

    }

    public void Move(float speed, Vector2 direction)
    {
		velocity.x = (speed * direction.x) * -1;
		velocity.y = (speed * direction.y) * -1;


		
	}
}
