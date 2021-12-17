using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    private SpriteRenderer gameOver;

    void Awake()
    {
        gameOver = GetComponent<SpriteRenderer>();
        gameOver.enabled = false;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(PlayerMove.isGameOver == true)
        {
            gameOver.enabled = true;
        }
		
	}
}
