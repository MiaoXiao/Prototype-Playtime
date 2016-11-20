using UnityEngine;
using System.Collections;

public class Lux : MonoBehaviour {
	public bool faint;
	public bool source;
	public float time;
	public float lightSeconds;
	float lightTime = 0;
	bool detected = false;
	bool lit = false;


	void Start () {
		if (source) {
			Debug.Log ("Disable");
		}
	}

	// On enter, start the timer.
	void OnTriggerEnter2D (Collider2D lightTrigger) {
		if (lightTrigger.tag == "Light" && source) {
			detected = true;
			StartCoroutine (timer ());
		} else {
			if (!source) {
				StartCoroutine (Luminous ());
			}
		}
	}

	// On exit, reset time.
	void OnTriggerExit2D (Collider2D lightTrigger) {
		if (lightTrigger.tag == "Light") {
			Debug.Log ("EXIT");
			detected = false;
			StopCoroutine (timer ());

			// Faint lights fade.
			if (faint) {
				gameObject.GetComponent <SpriteRenderer> ().color = Color.white;
			}

			lightTime = 0;
		}
	}
		
	// Light timing.
	IEnumerator Luminous () {
		yield return new WaitForSeconds (lightSeconds);
		gameObject.GetComponent <SpriteRenderer> ().color = Color.black;
	}

	// Light timer.
	IEnumerator timer () {
		while (detected) {
			lightTime += Time.deltaTime;
			if(lightTime > time) {
				gameObject.GetComponent <SpriteRenderer> ().color = Color.blue;
				lit = true;
				gameObject.GetComponent <CircleCollider2D> ().radius = 1;
			}
			yield return null;
		}
	}
}
