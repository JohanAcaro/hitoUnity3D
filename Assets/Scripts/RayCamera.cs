using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCamera : MonoBehaviour
{
    private Camera cam;
    public AudioSource audioSource;

    public AudioClip shootingSound;
    void Start()
    {
        cam = GetComponent<Camera>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = shootingSound;
        audioSource.playOnAwake = false;
        audioSource.volume = 0.5f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetMouseButtonDown(0))
        {
            Vector3 halfScreen = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(halfScreen);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                StartCoroutine(MarkBullet(hit.point)); 
            }
        }
    }

    private IEnumerator MarkBullet(Vector3 point)
    {
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // Agregar collider
        SphereCollider sphereCollider = bullet.AddComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        //Cambiar nombre de la esfera
        bullet.tag = "Bullet";
    
        bullet.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        bullet.transform.position = point;
        audioSource.Play();

        yield return new WaitForSeconds(0.5f);
        Destroy(bullet);
    }

    //Si colisiona con el enemigo las balas se vuelven rojas
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = Color.red;
            }
        }
    }


}
