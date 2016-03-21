using UnityEngine;
using System.Collections.Generic;

public class AnimationScript : MonoBehaviour 
{
    public List<Texture2D> frames;
    public float frameRate;
    public bool repeat;

    private Renderer spriteRenderer;
    private float nextFrameTime;
    private int currentFrame;

    void Start()
    {
        nextFrameTime = Time.time + frameRate;
        spriteRenderer = GetComponent<Renderer>();
        UpdateToNextFrame();
        Debug.Log("Animation start");
    }

    void Update()
    {
        if (Time.time > nextFrameTime)
        {
            Debug.Log("Animation update");
            UpdateToNextFrame();
            nextFrameTime = Time.time + frameRate;
        }
    }

    private void UpdateToNextFrame()
    {
        if (frames != null && frames.Count > 0)
        {
            Debug.Log("Animation next");
            if (currentFrame >= (frames.Count - 1))
            {
                if (repeat)
                {
                    currentFrame = 0;
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            spriteRenderer.material.mainTexture = frames[currentFrame];
        }
    }
}
