using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class animal_behaviour : MonoBehaviour
{
    private Rigidbody rb;
    public bool forward, rotate;
    public float speed, actuaFreq, rayDist;
    private float time;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(0, Random.value * 360, 0); // Randomize rotation at start
    }

    void FixedUpdate()
    {
        time += Time.deltaTime;

        if(time > actuaFreq)
        {
            Vector3 originPos = transform.position + Vector3.up * 0.5f;

            //Raycast
            RaycastHit hit;
            bool ray = Physics.Raycast(originPos, transform.forward, out hit, rayDist);

            //RANDOM ROTATE
            if(Random.value > 0.9f)
                ray = true;

            //Obstacle == rotate
            if(ray)
            {
                float randAngle = Random.Range(45, 180);

                Quaternion finalAngle = transform.rotation * Quaternion.Euler(0, randAngle, 0);
                transform.DORotateQuaternion(finalAngle, 0.29f);
                //Debug.DrawRay(originPos, transform.forward * hit.distance, Color.yellow);
                time = -0.3f;
            }
            else//Else forward
            {
                rb.velocity = transform.forward * speed;
                //Debug.DrawRay(originPos, transform.forward * rayDist, Color.white);
                time = 0;
            }
        }
    }
}
