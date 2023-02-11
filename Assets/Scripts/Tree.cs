using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            // Desactiva la física del objeto para que no se mueva al colisionar
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
