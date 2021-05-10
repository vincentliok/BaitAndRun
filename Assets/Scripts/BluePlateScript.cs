using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePlateScript : MonoBehaviour
{
    // Adjust in editor
    [SerializeField]
    private GameObject door;

    // Helper variables
    private bool isPressed;

    // Start is called before the first frame update
    void Start()
    {
        isPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If player steps on pressure plate, lower own position and open door

        if (other.gameObject.tag == "Player" && !isPressed)
        {
            transform.position += new Vector3(0.0f, -0.4f, 0.0f);
            Destroy(door);
            isPressed = true;
        }
    }
}
