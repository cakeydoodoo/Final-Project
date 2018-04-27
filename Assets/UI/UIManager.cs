using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour {

    Text score;
    public static int scoreNumber;
	// Use this for initialization
	void Start () {
        score = GetComponent<Text>();
        scoreNumber = 0;
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Score: " + scoreNumber;
        print("score");
        Debug.Log(scoreNumber);
	}

}
