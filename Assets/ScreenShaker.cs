using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    // Transform of the GameObject you want to shake
    private Transform transform;
 
    // Desired duration of the shake effect
    private float shakeDuration = 0f;
  
    // A measure of how quickly the shake effect should evaporate
    private float dampingSpeed = 1.0f;
 
    // The initial position of the GameObject
    Vector3 initialPosition;

    void Awake()
    {
        if (transform == null)
            transform = GetComponent<Transform>();
    }

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere / 4;
   
            shakeDuration -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake() {
        shakeDuration = 0.2f;
    }

}
