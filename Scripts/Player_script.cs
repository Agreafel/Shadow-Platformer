using System.Collections;
using UnityEngine;

public class Player_script : MonoBehaviour 
{
	public float speed;
	public float jump_vel;
	private Rigidbody rb2d;
	private SpriteRenderer spriteR;

	// Use this for initialization
	void Start () 
	{
		rb2d = GetComponent<Rigidbody>();
		spriteR = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		
		float move_x = 0;
		float move_y = rb2d.velocity.y;

		if (Input.GetKey ("d") && Input.GetKey ("a") == false && check_right() == false) 
		{
			spriteR.flipX = false;
            move_x = speed;
		} 
		else if (Input.GetKey ("a") && Input.GetKey ("d") == false && check_left() == false) 
		{
			spriteR.flipX = true;
            move_x = -speed;
		}
		if (Input.GetKeyDown("w") && check_floor())
		{
			move_y = jump_vel;
		}
				
		 

		rb2d.velocity = new Vector2(move_x, move_y);
	}

	bool check_floor ()
	{
		if (Physics.Raycast (new Vector3 (transform.localPosition.x + .45f, transform.localPosition.y, 0), new Vector3 (0, -1f, 0), 1.1f) ||
			Physics.Raycast (new Vector3 (transform.localPosition.x -.45f, transform.localPosition.y, 0), new Vector3 (0, -1f, 0), 1.1f) || 
			Physics.Raycast (new Vector3 (transform.localPosition.x, transform.localPosition.y, 0), new Vector3 (0, -1f, 0), 1.1f) ||
			Physics.Raycast (new Vector3 (transform.localPosition.x - .25f, transform.localPosition.y, 0), new Vector3 (0, -1f, 0), 1.1f) || 
			Physics.Raycast (new Vector3 (transform.localPosition.x + .25f, transform.localPosition.y, 0), new Vector3 (0, -1f, 0), 1.1f))
		{
			//print ("true");
			return true;
		} else {
			//print ("false");
			return false;
		}

	}

	bool check_left ()
	{
		if (Physics.Raycast (new Vector3 (transform.localPosition.x, transform.localPosition.y + 1.07f, 0), new Vector3 (-1f, 0, 0), .6f) ||
			Physics.Raycast (new Vector3 (transform.localPosition.x, transform.localPosition.y - 1.07f, 0), new Vector3 (-1f, 0, 0), .6f) || 
			Physics.Raycast (new Vector3 (transform.localPosition.x, transform.localPosition.y + .9f, 0), new Vector3 (-1f, 0, 0), .6f) ||
			Physics.Raycast (new Vector3 (transform.localPosition.x, transform.localPosition.y - .9f, 0), new Vector3 (-1f, 0, 0), .6f))
		{
			//print ("true L");
			return true;
		} else {
			//print ("false L");
			return false;
		}
	}

	bool check_right ()
	{
		if (Physics.Raycast (new Vector3 (transform.localPosition.x, transform.localPosition.y + 1.07f, 0), new Vector3 (1f, 0, 0), .6f) ||
			Physics.Raycast (new Vector3 (transform.localPosition.x, transform.localPosition.y - 1.07f, 0), new Vector3 (1f, 0, 0), .6f) || 
			Physics.Raycast (new Vector3 (transform.localPosition.x, transform.localPosition.y + .9f, 0), new Vector3 (1f, 0, 0), .6f) ||
			Physics.Raycast (new Vector3 (transform.localPosition.x, transform.localPosition.y - .9f, 0), new Vector3 (1f, 0, 0), .6f))
		{
			//print ("true R");
			return true;
		} else {
			//print ("false R");
			return false;
		}
	}

}
