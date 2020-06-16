using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Get player's position and rotation
            Transform playerTransform = GetComponent<Transform>();

            // Create bullet on players position and shoot it where ever the player is facing
            var b = Instantiate(bulletPrefab, playerTransform.position, playerTransform.rotation);
            b.GetComponent<Rigidbody>().AddForce(b.transform.forward * bulletSpeed, ForceMode.Impulse);

            Destroy(b, 2.0f);
        }
    }
}
