using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateTap : MonoBehaviour
{
    [SerializeField] GameObject prefap;
    [SerializeField] Transform position;
    [SerializeField] string destination;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Edge"&&destination=="Right")
        {
            GameObject newTAp = Instantiate(prefap, position.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag == "Edge" && destination == "Left")
        {
            GameObject newTAp = Instantiate(prefap, position.position, Quaternion.Euler(0,180,0));
            Destroy(this.gameObject);
        }
    }
}
