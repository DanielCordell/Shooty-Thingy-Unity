using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMotion : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody2D;

    public float speed;
    public float maxAngleVariation;
    public float timeToLive;
    public LayerMask whatIsCollide;

    private float timeCreated;

    public GameObject smoke;

    // Start is called before the first frame update 
    void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        float angleVariation = Random.Range(maxAngleVariation, -maxAngleVariation);
        gameObject.transform.Rotate(0, 0, angleVariation);
        timeCreated = Time.fixedTime;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(GetComponent<Transform>().position, 0.01f, whatIsCollide);
        if (colliders.Length != 0)
        {
            OnDie();
        }


        if (Time.fixedTime - timeCreated >= timeToLive)
        {
            OnDie();
        }
        Transform t = gameObject.transform;
        float angle = t.rotation.eulerAngles.z;
        
        float velx = speed * Mathf.Cos(angle * Mathf.Deg2Rad);
        float vely = speed * Mathf.Sin(angle * Mathf.Deg2Rad);
        m_Rigidbody2D.velocity = new Vector2(velx, vely);
    }

    void OnDie()
    {
        GameObject.Find("Main Camera").GetComponent<ScreenShaker>().TriggerShake();
        Destroy(gameObject);
        CreateSmoke();
    }
    
    void CreateSmoke()
    {
        Transform transform = gameObject.transform;
        float angle = Random.Range(0, 360);
        Vector3 position = transform.position;
        GameObject smokeObj = Instantiate(smoke, position, Quaternion.AngleAxis(angle, Vector3.forward));

        //Set scale
        float scale = 2 + Random.Range(-0.3f, 1.2f);
        smokeObj.transform.localScale = new Vector3(scale, scale, scale);
    }

}
