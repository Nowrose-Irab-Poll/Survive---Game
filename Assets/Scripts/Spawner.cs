using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    public GameObject knife;
    public GameObject levelUp;
    private float min_X = -3.4f, max_X = 3.4f;
    private float min_spawnTime = .5f, max_spawnTime = 2f;

    private int spawnCount = 0;
    private bool pushLevel;
    public static int level;

    //public Text spawnText;
    public Text levelText;

    // Use this for initialization
    void Start()
    {
        level = 1;
        pushLevel = false;
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(Random.Range(min_spawnTime, max_spawnTime));

        GameObject spawn = Instantiate(knife);
        spawnCount++;
        float x = Random.Range(max_X, min_X);
        spawn.transform.position = new Vector2(x, transform.position.y);

        Destroy(spawn, 2f);

        //Debug.Log("Spawn Count: "+spawnCount);
        //spawnText.text = "Spawns: " + spawnCount;

        StartCoroutine(StartSpawning());

        if(spawnCount > 10 && level == 1)
        {
            pushLevel = true;
            level++;
            levelText.text = "Level: "+level;
            GameObject sp = Instantiate(levelUp);
            Destroy(sp, 2f);


        }
        else if(spawnCount>30 && level == 2)
        {
            pushLevel = true;
            level++;
            levelText.text = "Level: " + level;
            GameObject sp = Instantiate(levelUp);
            Destroy(sp, 2f);

        }
        else if(spawnCount > 60 && level == 3)
        {
            pushLevel = true;
            level++;
            levelText.text = "Level: " + level;
            GameObject sp = Instantiate(levelUp);
            Destroy(sp, 2f);

        }
        else if(spawnCount > 80 && level == 4)
        {
            min_spawnTime = .2f;
            max_spawnTime = 1f;
            level++;
            levelText.text = "Level: " + level;
            GameObject sp = Instantiate(levelUp);
            Destroy(sp, 2f);

        }
        else if(spawnCount > 100 && level == 5)
        {
            min_spawnTime = .1f;
            max_spawnTime = .5f;
            level++;
            levelText.text = "Level: " + level;
            GameObject sp = Instantiate(levelUp);
            Destroy(sp, 2f);

        }

        if (pushLevel == true)
        {
            pushLevel = false;
            StartCoroutine(StartSpawning());
        }


    }

}
