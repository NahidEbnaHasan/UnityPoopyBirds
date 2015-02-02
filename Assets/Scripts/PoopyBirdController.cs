using UnityEngine;
using System.Collections;

public class PoopyBirdController : MonoBehaviour {
	protected Animator animator;
	public bool facingRight;
	public bool pooped;
	public GameObject poopSpawn;
	public GameObject poop;
	public GameObject baldMan;
	//public KeyCode dead;

	float IsApproximately(float a, float b){
		return Mathf.Abs (a - b);
	}

	public void Flip(){
//		facingRight = !facingRight;
//		Debug.Log (facingRight);
		
		// Multiply the player's x local scale by -1
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		//pooped = false;
//		float r = Random.Range (0, 1);
//		if(r < 0.5){
			//facingRight = true;
//		}else{
//			facingRight = false;
//		}
	}

	// Update is called once per frame
	void Update () {
		if (animator) {
			AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
			if(stateInfo.nameHash == Animator.StringToHash("Base Layer.FlyBird")){
				animator.SetBool("isDead", false);
			}
//			if(!facingRight){
//				//animator.SetBool("isDead", true);
//				Flip();
//			}
			if (facingRight) {

				//rigidbody2D.AddForce (transform.right * 1);
				//transform.position.x += 1;
				transform.position = new Vector2(transform.position.x + 0.03f, transform.position.y);
			}else{
				//rigidbody2D.AddForce ((transform.right * (-1)) * 1);
				//transform.position.x -= 1;
				transform.position = new Vector2(transform.position.x - 0.03f, transform.position.y);
			}

			baldMan = GameObject.FindGameObjectWithTag("Baldman");
			float baldManPosX = baldMan.GetComponent<Transform>().position.x;
			//Debug.Log (transform.position.x);
			//Debug.Log(pooped);
			if(IsApproximately(transform.position.x, baldManPosX) < 0.05f && !pooped){
				//Debug.Log (transform.position.x);
				//Debug.Log ("HERE");
				pooped = true;
				GameObject poopInst = Instantiate(poop, poopSpawn.GetComponent<Transform>().position, Quaternion.identity) as GameObject;
				if(!facingRight){
					Vector3 theScale = poopInst.transform.localScale;
					theScale.x *= -1;
					poopInst.transform.localScale = theScale;
				}
				Destroy(poopInst, 5f);
			}
		}
	}

//	void FixedUpdate(){
//		//Debug.Log (facingRight);
//		if (facingRight) {
//			//rigidbody2D.AddForce (transform.right * 1);
//			//transform.position.x += 1;
//			transform.position = new Vector2(transform.position.x + 0.03f, transform.position.y);
//		}else{
//			//rigidbody2D.AddForce ((transform.right * (-1)) * 1);
//			//transform.position.x -= 1;
//			transform.position = new Vector2(transform.position.x - 0.03f, transform.position.y);
//		}
//
//	}
}
