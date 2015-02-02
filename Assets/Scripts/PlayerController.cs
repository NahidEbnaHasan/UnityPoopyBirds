using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public KeyCode moveRight;
	public KeyCode moveLeft;
	public KeyCode shoot;

	public GameObject bullet, fire;
	public Transform bulletSpawn;
	public float bulletSpeed;
	public float rate;

	private float nextFire;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey( shoot) && Time.time > nextFire){
			nextFire = Time.time + rate;
			GameObject bulletInst, fireInst;
			bulletInst = Instantiate(bullet, bulletSpawn.position, Quaternion.identity) as GameObject;
			bulletInst.rigidbody2D.AddForce(new Vector2(0f, bulletSpeed));
			//bulletInst.rigidbody2D.AddRelativeForce(this.transform.up, bulletSpeed);
			Destroy(bulletInst, 2f);

			fireInst = Instantiate(fire, bulletSpawn.position, Quaternion.identity) as GameObject;
			Destroy(fireInst, 0.03f);
		}
	}

	void FixedUpdate(){

		if (Input.GetKey (moveRight)) {
			rigidbody2D.AddForce(new Vector2(5f, 0f));
		}else if (Input.GetKey (moveLeft)) {
			rigidbody2D.AddForce(new Vector2(-5f, 0f));
		}
		rigidbody2D.position = new Vector2 (
			Mathf.Clamp(transform.position.x, -2.65f, 2.65f),
			-3.637841f
		);
	}
}
