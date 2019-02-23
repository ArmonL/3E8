using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guiLives : MonoBehaviour {

    public int lives = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void removeLife()
    {
        GameObject.Find("guiLife" + lives).GetComponent<Image>().enabled = false;

        lives--;
    }
}
