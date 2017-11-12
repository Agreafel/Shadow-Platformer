using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_orb_scr : MonoBehaviour {

	public Rigidbody rb_orb;
	public bool is_thrown;

	// Use this for initialization
	void Start () 
	{
		rb_orb = GetComponent<Rigidbody> ();
		is_thrown = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (rb_orb.useGravity == false && Input.GetKeyDown ("space"))
        {
			is_thrown = false;
			rb_orb.useGravity = true;
			rb_orb.freezeRotation = false;
		}
	}
	void OnTriggerEnter (Collider other)
	{
		print ("hit");
		if (other.gameObject.name == "Cube" && is_thrown) {
			print (other);
			rb_orb.useGravity = false;
			rb_orb.freezeRotation = true;
			rb_orb.velocity = new Vector3 (0, 0, 0);
		}
	}
}


		
		
