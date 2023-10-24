using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;

using TMPro;

public class mvball : MonoBehaviour
{
    public float speed = 300;
    public TextMeshProUGUI countText;
    private Rigidbody rb;

    private int count;

    public GameObject winTextObject;

    private float xdir;
    private float ydir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    // Get movement directions
    void OnMove(InputValue val)
    {
        Vector2 direction = val.Get<Vector2>();

        xdir = direction.x;
        ydir = direction.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 3)
        {
            winTextObject.SetActive(true);
        }
    }


    // update movement
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(xdir, 0, ydir);

        rb.AddForce(movement * speed * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            Vector3 movement = new Vector3(0, 100, 0);
            rb.AddForce(movement * speed * Time.deltaTime);

            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
}

