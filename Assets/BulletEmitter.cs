using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEmitter : MonoBehaviour
{
    public GameObject bullet;

    private bool doCreateBullet = false;
    private Vector3 objectSize;

    private PlayerMovement playerMovement;

    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        objectSize = GetComponent<Renderer>().bounds.size;
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        doCreateBullet = Input.GetButton("Fire1");
    }

    void FixedUpdate()
    {
        if (doCreateBullet)
        {
            Transform transform = gameObject.transform;
            float direction = transform.lossyScale.x;
            float angleStart = 0;
            if (direction < 0)
            {
                angleStart = 180;
            }
            Vector3 position = transform.position;
            position.x += direction * objectSize.x / 2;
            if (playerMovement.currentCrouch)
            {
                position.y -= objectSize.y / 4;
            }

            AudioSource.PlayClipAtPoint(clip, position, 1);
            Instantiate(bullet, position, Quaternion.AngleAxis(angleStart, Vector3.forward));
            doCreateBullet = false;
        }
    }
}
