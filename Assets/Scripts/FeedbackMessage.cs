using UnityEngine;

public class FeedbackMessage : MonoBehaviour {
    public int timeToLive;

    float showUntil;

	// Use this for initialization
	void Start () {
        showUntil = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        var now = Time.time;
        if (gameObject.activeSelf && now > showUntil) {
            gameObject.SetActive(false);
        }
    }

    public void ShowMessage() {
        var now = Time.time;
        gameObject.SetActive(true);
        showUntil = now + timeToLive;
    }
}
