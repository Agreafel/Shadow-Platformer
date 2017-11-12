using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pick_up_lantern_scr : MonoBehaviour 
{
	private Transform parent;
	//private Transform scene_trans;
	private Light_orb_scr orb;
	private Rigidbody orb_rb;
	public float throw_speed;
	private Vector3 position;

	// Use this for initialization
	void Start ()
	{
		parent = GameObject.Find("PlayerSprite").GetComponent<Transform> ();
		orb = GameObject.Find("LightOrbSprite").GetComponent<Light_orb_scr> ();
		orb_rb = orb.rb_orb;
		position = orb_rb.transform.position;


		//Scene scene = SceneManager.GetActiveScene ();
	}
		
	void OnTriggerStay (Collider other)
	{
		//print (other);

		if (Input.GetKeyDown ("e") && other == GameObject.Find ("LightOrbSprite").GetComponent<CapsuleCollider> ()) {
			orb_rb.useGravity = true;
			other.transform.SetParent (parent);
			other.transform.localPosition = new Vector3 (0, 1.5f, 0);
			other.attachedRigidbody.isKinematic = true;
		}

 		if (Input.GetMouseButtonDown(0) && other == GameObject.Find ("LightOrbSprite").GetComponent<CapsuleCollider> ())
		{
			print ("click");

			Vector3 throw_direction = Camera.main.ScreenToWorldPoint (Input.mousePosition) - other.transform.localPosition;
			position = orb_rb.transform.position;

			orb_rb.useGravity = true;
			other.attachedRigidbody.isKinematic = false;
			orb.is_thrown = true;
			throw_direction.z = 0;
			throw_direction = throw_direction.normalized;
			orb_rb.transform.localPosition = throw_direction;
			//print (orb_rb.transform.localPosition);
			orb_rb.velocity = orb_rb.transform.localPosition * throw_speed;
			other.transform.parent = null;
		}

	}

	/*void OnTriggerExit (Collider other)
	{
		if (other == GameObject.Find ("LightOrbSprite").GetComponent<CapsuleCollider> ()) {
			other.attachedRigidbody.isKinematic = false;
		}
	}*/
			
}
