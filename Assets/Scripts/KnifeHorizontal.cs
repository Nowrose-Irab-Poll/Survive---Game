using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHorizontal : MonoBehaviour {

    private SpriteRenderer sr;

    public bool moveRight;
    private float speed = 3f;
    private float min_X = -4.5f, max_X = 4.5f;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        KnifeBounds();
	}

    void Move()
    {
        if (moveRight)
        {
            Vector3 temp = transform.position;
            temp.x += speed * Time.deltaTime;
            transform.position = temp;
        } else
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;

        }
    }

    void KnifeBounds()
    {
        Vector3 temp = transform.position;
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

        transform.position = temp;
    }

}
