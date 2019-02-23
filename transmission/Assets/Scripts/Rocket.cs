using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour {

    public float forceAmt;

    public bool[] signals = new bool[Enum.GetValues(typeof(SignalManager.TransmissionType)).Length];
    private object targetPosition;

    public float invulnTime;  

    // Use this for initialization
    void Start () {

      
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 force = new Vector2();

        if (InputReceiving(SignalManager.TransmissionType.UP))
            force.y += forceAmt;

        if (InputReceiving(SignalManager.TransmissionType.DOWN))
            force.y -= forceAmt;

        if (InputReceiving(SignalManager.TransmissionType.RIGHT))
            force.x += forceAmt;

        if (InputReceiving(SignalManager.TransmissionType.LEFT))
            force.x -= forceAmt;

        this.GetComponent<Rigidbody2D>().AddForce(force);

        for (int i = 0; i < signals.Length; i++)
            signals[i] = false;

        //to stabalize ship

        if (transform.rotation.eulerAngles.z > 0 && transform.rotation.eulerAngles.z < 180)
        {
            transform.GetComponent<Rigidbody2D>().AddTorque(-transform.rotation.eulerAngles.z / 15);
        }

        if (transform.rotation.eulerAngles.z > 180)
        {
            transform.GetComponent<Rigidbody2D>().AddTorque((transform.rotation.eulerAngles.z - 180) / 15);
        }

        if (invulnTime > 0)
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = ((int)(invulnTime * 10f)) % 2 == 0;
            invulnTime -= Time.deltaTime;

            if (invulnTime <= 0)
            {
                invulnTime = 0;
                GetComponent<SpriteRenderer>().enabled = true;
                GetComponent<Collider2D>().enabled = true;
            }
        }

        if (GameObject.Find("guiRocket").GetComponent<guiRocket>().progress >= 1)
        {
            MainMenu.lastScore = 600000;
            MainMenu.highScore = 600000;
            SceneManager.LoadSceneAsync("Win Screen");
        }
    }

    bool InputReceiving(SignalManager.TransmissionType type)
    {
        
        if (type == SignalManager.TransmissionType.UP)
            return signals[(int)type];

        if (type == SignalManager.TransmissionType.RIGHT)
            return signals[(int)type];

        if (type == SignalManager.TransmissionType.DOWN)
            return signals[(int)type];

        if (type == SignalManager.TransmissionType.LEFT)
            return signals[(int)type];
            

        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.name == "Boundaries")
        {
            this.transform.SetPositionAndRotation(new Vector3(0, 0, 0), Quaternion.identity);
            return;
        }

        if (invulnTime == 0)
        {
            invulnTime = 2.0f;
            Destroy(collision.collider.gameObject);
            GameObject.Find("guiLives").GetComponent<guiLives>().removeLife();

            if (GameObject.Find("guiLives").GetComponent<guiLives>().lives == 0)
            {
                MainMenu.lastScore = (int) (600000 * GameObject.Find("guiRocket").GetComponent<guiRocket>().progress);

                if (MainMenu.lastScore > MainMenu.highScore)
                    MainMenu.highScore = MainMenu.lastScore;

                SceneManager.LoadSceneAsync("PrePicMenu");
            }
        }
    }
}
