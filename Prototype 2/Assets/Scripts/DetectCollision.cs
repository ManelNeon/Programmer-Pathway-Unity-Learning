using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != ("Player") && this.gameObject.tag != ("Dog"))
        {
            Destroy(this.gameObject);
            other.GetComponent<AnimalHealthManager>().ChangeHealth();
        }
        if (other.gameObject.tag == ("Player") && this.gameObject.tag == ("Dog"))
        {
            Destroy(this.gameObject);
            other.GetComponent<PlayerController>().TakeLife();
        }
    }
}
