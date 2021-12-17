using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHorizontal : MonoBehaviour {

    public GameObject obstacle;
    public GameObject potion;

    private float max_Y = 0f, min__Y = -2.74f;

	// Use this for initialization
	void Start () {
		
        StartCoroutine(StartSpawning());
        StartCoroutine(StartSpawningPotions());

    }

    // Update is called once per frame
    void Update () {
	}

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(Random.Range(5f, 10f));

        GameObject k = Instantiate(obstacle);

        Destroy(k, 3f);
        float y = Random.Range(max_Y, min__Y);

        obstacle.transform.position = new Vector2(transform.position.x, y);
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawningPotions()
    {
        yield return new WaitForSeconds(Random.Range(5f, 10f));

        GameObject t = Instantiate(potion);

        Destroy(t, 3f);
        float y = Random.Range(max_Y, min__Y);

        potion.transform.position = new Vector2(transform.position.x, y);
        StartCoroutine(StartSpawningPotions());
    }

}
