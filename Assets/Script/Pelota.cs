using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{
    Marcador marcador;
    Vector2 direction;
    float speed = 1;

    // Audio
    AudioSource soundEffects;
    public AudioClip goal;
    public AudioClip hit;

    // Start is called before the first frame update
    void Start()
    {
        soundEffects = GameObject.FindObjectOfType<AudioSource>();
        marcador = GameObject.FindObjectOfType<Marcador>();
        Invoke("ResetBall", 2);
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
            soundEffects.PlayOneShot(hit);
        }
        else if (coll.collider.CompareTag("LeftGoal"))
        {
            marcador.RightPlayerGoal();
            // Hide ball so we dont see it bouncing endlessly with the back wall
            gameObject.GetComponent<Renderer>().enabled = false;
            Invoke("ResetBall", 1);
            soundEffects.PlayOneShot(goal);
        }
        else if (coll.collider.CompareTag("RightGoal"))
        {
            marcador.LeftPlayerGoal();
            // Hide ball so we dont see it bouncing endlessly with the back wall
            gameObject.GetComponent<Renderer>().enabled = false;
            Invoke("ResetBall", 1);
            soundEffects.PlayOneShot(goal);
        }
        else if (coll.collider.CompareTag("ScreenBorder"))
        {
            direction.y *= -1;
        }
    }

    private void ResetBall()
    {
        gameObject.GetComponent<Renderer>().enabled = true;
        transform.position = new Vector3(0, 0, 0);
        speed = 0.05f;
        direction = new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
    }
}
