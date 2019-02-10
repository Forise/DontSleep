using UnityEngine;
using System.Collections;

public class Timer : MonoSingleton<Timer>
{
    public float time = 0f;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }
}
