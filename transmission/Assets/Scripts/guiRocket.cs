using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class guiRocket : MonoBehaviour {

    public float speed;
    public float progress;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        //this.GetComponent<Transform>().transform.Translate(0, Time.deltaTime * speed, 0);

        progress += speed * Time.deltaTime;

        RectTransform rect = this.GetComponent<RectTransform>();
        rect.anchoredPosition = Vector2.Lerp(
            new Vector2(rect.anchoredPosition.x, 0), 
            new Vector2(rect.anchoredPosition.x, GameObject.Find("SignalManager").GetComponent<RectTransform>().rect.height), 
            progress);

        GameObject.Find("guiText").GetComponent<Text>().text = (int)(600000 * progress) + " km";
    }
}
