using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //Invoke("RandomMovement", 2f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void RandomMovement()
    {
        float rand_x = Random.Range(0f, 1f);
        float rand_y = Random.Range(0f, 1f);

        //GetComponent<RigidBody>
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.tag == "Light")
        {
            gameObject.SetActive(false);
        }
    }
}
