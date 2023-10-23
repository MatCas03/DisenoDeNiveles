using UnityEngine;

public class ScriptGrabbed : MonoBehaviour
{
    public bool ShouldDropObject = false;

    // Reference to the WeaponGrab script
    private WeaponGrab weaponGrab;
    private GrabTrigger grabTrigger;

    private void Start()
    {
        // Get the WeaponGrab component attached to this object
        weaponGrab = GetComponent<WeaponGrab>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GrabTrigger")
        {
            ShouldDropObject = true;
            Debug.Log("Should drop object on the floor");

            // Attach the GrabTrigger script to this object
            grabTrigger = gameObject.AddComponent<GrabTrigger>();

            // Destroy the GrabTrigger script after 0.5 seconds
            Destroy(grabTrigger, 0.5f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Floor")
        {
            ShouldDropObject = false;
            Destroy(grabTrigger, 0.5f);
            Debug.Log("Should stop dropping object on the floor");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldDropObject)
        {
            // Call the DropObject method from the WeaponGrab script
            Debug.Log("Chamusco");
            weaponGrab.DropObject();
            ShouldDropObject = false;
        }
    }
}
