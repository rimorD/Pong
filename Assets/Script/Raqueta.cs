using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public float speed = 0.05f;
    public float boundY = 4f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(moveUp))
        {
            transform.Translate(new Vector2(0, 1f) * speed);
        }
        else if (Input.GetKey(moveDown))
        {
            transform.Translate(new Vector2(0, -1f) * speed);
        }

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
    }
}
