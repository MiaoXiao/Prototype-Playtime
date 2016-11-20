using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Speed = 30f;

    [SerializeField]
    private float SpellIntensity = 8f;

    private Rigidbody2D Rbody;

    private Light PointLight;

    private float AngleOffset;

	// Use this for initialization
	void Awake ()
    {
        PointLight = transform.Find("Light Spell").GetComponent<Light>();
        PointLight.intensity = 0;
        Rbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("mouse down");
            //Vector3 heading = Input.mousePosition - Camera.main.WorldToScreenPoint(PointLight.transform.position);
            //AngleOffset = (Mathf.Atan2(PointLight.transform.right.y, PointLight.transform.right.x) - Mathf.Atan2(heading.y, heading.x)) * Mathf.Rad2Deg;
            MoveLight();
            PointLight.intensity = 8;
        }
        else if (Input.GetMouseButton(0))
        {
            //Debug.Log("mouse");
            MoveLight();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            //Debug.Log("mous up");
            PointLight.intensity = 0;
        }
        
        PlayerMovement();
    }

    /// <summary>
    /// Move the light based on mouse position
    /// </summary>
    private void MoveLight()
    {
        Vector3 heading = Input.mousePosition - Camera.main.WorldToScreenPoint(PointLight.transform.localPosition);
        Vector3 direction = heading / heading.magnitude;
        direction = new Vector3(direction.x / 2, direction.y / 2, direction.z);

        //Debug.Log(heading / heading.magnitude);
        //float angle = Mathf.Atan2(heading.x, heading.y);
        //PointLight.transform.localEulerAngles = new Vector3(0, 0, angle + AngleOffset);
        PointLight.transform.localPosition = new Vector3(direction.x, direction.y, -1);
        //Debug.Log(direction);
    }

    /// <summary>
    /// Move the player
    /// </summary>
    private void PlayerMovement()
    {
        Vector3 final_movement = Vector3.zero;
        if (Input.GetButton("PlayerUp"))
        {
            final_movement += transform.up;
        }
        if (Input.GetButton("PlayerRight"))
        {
            final_movement += transform.right;
        }
        if (Input.GetButton("PlayerDown"))
        {
            final_movement -= transform.up;
        }
        if (Input.GetButton("PlayerLeft"))
        {
            final_movement -= transform.right;
        }
        Rbody.MovePosition(transform.position + final_movement * Time.deltaTime * Speed);
    }
}
