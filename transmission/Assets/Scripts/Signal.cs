using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signal : MonoBehaviour {

    public float propagationSpeed;
    public float top, bottom; // 0 to 1

    public SignalManager.TransmissionType type;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // this.transform.Translate(0, propagationSpeed * Time.deltaTime, 0);

        top += propagationSpeed * Time.deltaTime;
        bottom += propagationSpeed * Time.deltaTime;

        RectTransform rect = this.GetComponent<RectTransform>();
        rect.anchoredPosition = Vector2.Lerp(
            new Vector2(rect.anchoredPosition.x, 0),
            new Vector2(rect.anchoredPosition.x, GameObject.Find("SignalManager").GetComponent<RectTransform>().rect.height),
            top);

        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, (top - bottom) * GameObject.Find("SignalManager").GetComponent<RectTransform>().rect.height);



        if (top <= bottom)
            Destroy(gameObject);

        if (top >= GameObject.Find("guiRocket").GetComponent<guiRocket>().progress)
        {
            top = GameObject.Find("guiRocket").GetComponent<guiRocket>().progress;
            GameObject.Find("Rocket").GetComponent<Rocket>().signals[(int)type] = true;
        }
    }
}
