using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    Marcador marcador;
    Vector2 direction;
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

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            direction.x *= -1;
            speed += 0.01f;
        }
        else if (coll.collider.CompareTag("LeftGoal"))
        {
            marcador.RightPlayerGoal();
            ResetBall();
        }
        else if (coll.collider.CompareTag("RightGoal"))
        {
            marcador.LeftPlayerGoal();
            ResetBall();
        }
        else if (coll.collider.CompareTag("ScreenBorder"))
        {
            direction.y *= -1;
        }
    }

    private void ResetBall()
    {
        transform.position = new Vector3(0, 0, 0);
        speed = 0.05f;
        direction = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
    }
}
