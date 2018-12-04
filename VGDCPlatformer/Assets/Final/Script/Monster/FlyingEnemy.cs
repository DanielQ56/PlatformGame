using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlyingEnemy : Enemy
{

    public float movSpeed = 2.5f; //movement of the enemy
    private bool moveRight;

    public int towardIndex;
    private int maxIndex;

    //Patrol Positions
    public Transform[] transforms;

    private void Awake()
    {
        GetTransforms();
        maxIndex = transforms.Length - 1;
    }

    void Start()
    {
        moveRight = Random.Range(0, 2) == 1 ? true : false;
        int startIndex = Random.Range(0, transforms.Length);

        transform.position = transforms[startIndex].position;

        // check constraints
        if (startIndex == 0)
        {
            towardIndex = 1;
            moveRight = true;
        }
        else if (startIndex == maxIndex)
        {
            moveRight = false;
            towardIndex = maxIndex - 1;
        }

        // adjust facing
        if (!moveRight)
        {
            Vector3 facingLeft = transform.localScale;
            facingLeft.x *= -1;
            transform.localScale = facingLeft;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float step = movSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, transforms[towardIndex].position, step);

        if (Vector3.Distance(transform.position, transforms[towardIndex].position) <= 0.1)
        {
            if (towardIndex == 0)
            {
                towardIndex = 1;
                Flip();
            }
            else if (towardIndex == maxIndex)
            {
                towardIndex--;
                Flip();
            }
            else if (moveRight)
            {
                towardIndex++;
            }
            else if (!moveRight)
            {
                towardIndex--;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position,
                                                 transforms[towardIndex].position, step);
    }

    //flips the entire gameObject and its components
    void Flip()
    {
        moveRight = !moveRight;
        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void GetTransforms()
    {
        List<Transform> temp = new List<Transform>();
        foreach (Transform t in parent.GetComponentsInChildren<Transform>())
        {
            if (t.tag == "position")
            {
                temp.Add(t);
            }
        }
        transforms = temp.ToArray();
    }
}
