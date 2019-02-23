using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisManager : MonoBehaviour {

    public GameObject[] debris;
    public GameObject[] rareDebris;

    public float debrisRate;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Random.value < debrisRate)
            MakeRandomDebris();

        debrisRate = Mathf.Lerp(0.03f, 0.08f, GameObject.Find("guiRocket").GetComponent<guiRocket>().progress);
    }

    void MakeRandomDebris()
    {
        GameObject newDebris;

        if (Random.value > 0.001)
        {
            newDebris = GameObject.Instantiate(debris[Random.Range(0, debris.Length - 1)], this.transform);
        }
        else
        {
            newDebris = GameObject.Instantiate(rareDebris[Random.Range(0, rareDebris.Length - 1)], this.transform);
        }

        Vector2 pos = new Vector2(Random.Range(-10f, 10f), 6.1f);

        newDebris.transform.SetPositionAndRotation(pos, Quaternion.identity);
        newDebris.transform.Rotate(0, 0, Random.Range(0f, 360f));

        float size = Random.Range(1.8f, 4f);
        newDebris.transform.localScale = new Vector3(size, size, 3f);

        newDebris.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -4f);
    }
}
