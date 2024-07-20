using UnityEngine;

public class HandleWeapon : MonoBehaviour
{
    public GameObject bullet;
    private Transform firePoint;
    public Camera playerCamera;

    void Start()
    {
        // the firePoint is the current game object's transform because that's where the bullet will be fired from
        firePoint = transform;
    }

    void Update()
    {
        // to shoot a bullet X key is used
        if (Input.GetKey(KeyCode.X))
        {
            // using the playerCamera's forward direction thats how the firePoint's rotation is set so the bullet shot is fired in the direction playerCamera is facing.
            firePoint.rotation = Quaternion.LookRotation(playerCamera.transform.forward);

            // used to create a new instance of bullet each time X key is pressed to fire bullet with the correct positioning and rotation assigned.
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }

}
