using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{

    private SpriteRenderer sr;

    public bool moveRight;
    private float speed = 3f;
    private float min_X = -4.5f, max_X = 4.5f;

    private bool isVisible = true;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        PotionBounds();
    }

    void Move()
    {
        if (moveRight)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

        }
    }

    void PotionBounds()
    {
        Vector3 temp = transform.position;

        if (isVisible == true)
        {
            if (temp.x > max_X || temp.x < min_X)
            {
                //temp.x = max_X;
                sr.enabled = false;
            }
            else
            {
                //temp.x = min_X;
                sr.enabled = true;
            }
        }
        else
        {
            sr.enabled = false;
        }

        transform.position = temp;
    }


}
