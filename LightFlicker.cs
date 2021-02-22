/*
 * Author: Jack Hunt.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// LightFlicker causes the lights to flicker in an eerie manner.
/// </summary>
public class LightFlicker : MonoBehaviour
{
    //flickerFrequency determines the frequency the light flickers.
    [Range(0f, 10f)]
    public float flickerFrequency = 1.5f;

    //flickerRandomness determines the randomness of the light flicker.
    [Range(0f, 2f)]
    public float flickerRandomness = 1.2f;

    //timeOfFlicker determines the time of the flicker.
    [Range(0f, 1f)]
    public float timeOfFlicker = 0.1f;
    
    //upperLightIntensity limits the level of the lights intensity.
    private float upperLightIntensity;
    
    //lockFlicker allows the light to stop flickering.
    public bool lockFlicker = false;

    //light is the light component.
    private Light light;

    //timeToFlicker is the remaining time to the next flicker.
    private float timeToFlicker;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponentInChildren<Light>();
        upperLightIntensity = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lockFlicker)
            FlickerLight();
    }

    /// <summary>
    /// FlickerLight makes the light flicker. It is timing based where the timings are randomised.
    /// </summary>
    private void FlickerLight()
    {
        timeToFlicker -= Time.deltaTime;
        
        if(timeToFlicker <= 0)
        {
            if (light.intensity == 0)
            {
                timeToFlicker = Random.Range(flickerFrequency - flickerRandomness, flickerFrequency + flickerRandomness);
                light.intensity = upperLightIntensity;
            }
            else
            {
                timeToFlicker = timeOfFlicker;
                light.intensity = 0;
            }
        }
    }
}
