using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject poopyBird;

	void CreatePoopyBird(){
		GameObject pBInst;
		float rSide = Random.Range (0f, 1f);
		//Debug.Log (rSide);
		float x, y;
		if (rSide > 0.5f) {
			x = Random.Range(3f, 4f);
		}else{
			x = Random.Range(-3f, -4f);
		}
		y = Random.Range(0f, 4f);
		//Debug.Log (x);
		//Debug.Log (y);
		pBInst = Instantiate (poopyBird, new Vector2 (x, y), Quaternion.identity) as GameObject;
		pBInst.GetComponent<PoopyBirdController> ().pooped = false;
		if (rSide > 0.5f) {
			pBInst.GetComponent<PoopyBirdController> ().facingRight = false;
			pBInst.GetComponent<PoopyBirdController> ().Flip ();
		}else{
			pBInst.GetComponent<PoopyBirdController> ().facingRight = true;
		}
		Destroy (pBInst, 20f);
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("CreatePoopyBird", 1f, 5f);
	}
	
	// Update is called once per frame
	void Update () {

	}
}
