using UnityEngine; /*Hamie Nouri - 04.11.2024 */
/*
 * ==> Don't worry about this script, I am just playing around <==
 * Its essentially makes the bullet prefab shoot from a position I define in game
 */

public class ShootBullets : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;       // The bullet prefab to instantiate
    [SerializeField] private float bulletSpeed = 20f;       // Speed at which the bullet will travel
    [SerializeField] private Camera playerCamera;           // Reference to the player's camera
    [SerializeField] private Transform bulletSpawnPoint;    // The position from which the bullet will be shot

    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        // Instantiate the bullet at the bulletSpawnPoint position
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Get the direction to shoot the bullet in (the camera's forward direction)
        Vector3 shootDirection = playerCamera.transform.forward;

        // Apply velocity to the bullet in the shoot direction
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = shootDirection * bulletSpeed;
        }
    }
}
