using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    // the health of the game object
    private int health = 100;

    // the opacity of the game object
    private float opacity = 1f;


    // the rigid body 2d component of the game object
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        int randomHorizontalInverse = 1;
        int randomVerticalInverse = 1;

        if (Random.Range(0, 2) == 1)
        {
            randomHorizontalInverse *= -1;
        }

        if (Random.Range(0, 2) == 1)
        {
            randomVerticalInverse *= -1;
        }

        float horizontalForce = Random.Range(1, 5) * randomHorizontalInverse;
        float verticalForce = Random.Range(1, 5) * randomVerticalInverse;

        rb2d.AddForce(
            new Vector2(
                horizontalForce, 
                verticalForce
            ),
            ForceMode2D.Impulse
        );
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        opacity -= 0.1f;
        sprite.color = new Color(1f, 1f, 1f, opacity);

        health -= 10;
    }
}
