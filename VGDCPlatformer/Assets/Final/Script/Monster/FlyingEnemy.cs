using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlyingEnemy : Enemy
{
    public float movSpeed = 2.5f; //movement of the enemy
    private bool moveRight;

    public int towardIndex;
    private int maxIndex;
    private AudioSource cawSound;
    private float defaultVolume;
    private float SoundfadeTime = 1f;
    private bool isCawing = false;
    private GameObject Player;
    //Patrol Positions
    public Transform[] transforms;

    public int playSoundWithRange;

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        GetTransforms();
        maxIndex = transforms.Length - 1;
        cawSound = parent.GetComponentInChildren<AudioSource>();
        defaultVolume = cawSound.volume;
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

        startCawing();
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


    private void startCawing()
    {
        float deltaDistance = Vector3.Distance(transform.position, Player.transform.position);
        if (deltaDistance < playSoundWithRange)
        {
            if (!isCawing)
            {
                cawSound.volume = defaultVolume;
                isCawing = true;
                cawSound.Play();
            }
        }
        else
        {
            if (isCawing)
            {
                StartCoroutine(_FadeSound());
                StopCoroutine(_FadeSound());
            }
        }
    }
    IEnumerator _FadeSound()
    {
        float t = SoundfadeTime;
        while (t > 0)
        {
            yield return null;
            t -= Time.deltaTime;
            cawSound.volume -= 0.0005f;
        }
        if (t < 0)
        {
            isCawing = false;
            cawSound.Stop();
        }
        yield break;
    }
}
