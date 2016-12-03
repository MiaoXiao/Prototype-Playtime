using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour
{

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Vector3 heading = transform.parent.transform.position - collider.transform.position;
            transform.parent.transform.GetComponent<Rigidbody2D>().MovePosition(transform.parent.transform.position + heading.normalized * 2f * Time.deltaTime);
        }
    }
}
