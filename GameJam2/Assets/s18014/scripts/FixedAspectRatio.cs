using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedAspectRatio : MonoBehaviour {
    public float width = 1600f;
    public float height = 900f;
    Camera cam;
    Rect rect = new Rect();
    float targetAspect;
    float curAspect;
    float ratio;

    // Use this for initialization
    void Start () {
        cam = GetComponent<Camera>();
        FixAspectRatio();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void FixAspectRatio () {
        targetAspect = width / height;
        curAspect = Screen.width * 1.0f / Screen.height;
        ratio = curAspect / targetAspect;

        if (1f > ratio)
        {
            rect.x = 0f;
            rect.y = (1f - ratio) / 2f;
            rect.width = 1f;
            rect.height = ratio;
        }
        else
        {
            ratio = 1.0f / ratio;
            rect.x = (1f - ratio) / 2f;
            rect.y = 0f;
            rect.width = ratio;
            rect.height = 1f;
        }

        cam.rect = rect;
    }
}
