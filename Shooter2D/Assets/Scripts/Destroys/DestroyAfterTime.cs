using UnityEngine;
using System.Collections;
public class DestroyAfterTime : MonoBehaviour 
{
    public float timeToLive;

    void Start()
    {
        Destroy(gameObject, timeToLive);
    }
}