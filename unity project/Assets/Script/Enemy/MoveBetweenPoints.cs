using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    public List<Transform> PatrolPoints; // list of points for the enemy to move between
    public int point = 0;
    public float speed = 2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, PatrolPoints[point].position, speed * Time.deltaTime); //moves enemy towards point
    }

    void OnTriggerEnter2D(Collider2D other) //detects if enemy has touched point, if so change point
    {
        if (other.tag == "point")
        {

            if (other.name == PatrolPoints[point].name)
            {
                point++;
            }
            if (point == PatrolPoints.Count)
            {
                point = 0;
            }
        }

    }
}
