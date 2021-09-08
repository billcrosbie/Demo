using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; // Accesses input system
using TMPro; // Accesses UI text elements

public class PlayerControl : MonoBehaviour
{
    // Custom speed variable
    public float the_speeeeeeeed = 0;
    // Yes, I know it's a bad variable name. I don't care, I think it's funny.
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb; // Makes a rigidbody that can be used as a proxy for GameObject's rigidbody within this script
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Gets the rigidbody from GameObject (the sphere) to use within this script
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); // Translates the movementValue from the input into a vector value usable in this script

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * the_speeeeeeeed);
    }

    /*
     * Unnecessary in this script, but placed in by default.
     * 
    // Update is called once per frame
    void Update()
    {
        
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }
}
