using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    Marcador marcador;
    Vector3 direction;
    float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        marcador = GameObject.FindObjectOfType<Marcador>();
        ResetBall();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "ScreenBorder":
                direction.y *= -1;
                break;
            case "LeftGoal":
                marcador.RightPlayerGoal();
                ResetBall();
                break;
            case "RightGoal":
                marcador.LeftPlayerGoal();
                ResetBall();
                break;
            case "Raqueta":
                direction.x *= -1;
                speed += 0.05f;
                break;
        }
    }

    private void ResetBall()
    {
        transform.position = new Vector3(0, 0, 0);
        speed = 0.05f;
        direction = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
    }
}
