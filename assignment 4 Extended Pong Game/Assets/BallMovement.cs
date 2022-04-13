using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 4;
    public static Dictionary<string, List<Transform>> repositoryDict = new Dictionary<string, List<Transform>>();

    // Start is called before the first frame update
    void Start()
    {
        // add the ball to the dictionary
        List<Transform> temp = new List<Transform>();
        temp.Add(transform);
        repositoryDict.Add(transform.tag, temp);

        StartOfBall();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetComponent<Rigidbody>().velocity);
    }

    public void StartOfBall()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-10f, -5f);
        
        Vector3 force = new Vector3(x, y, 0);

        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.AddForce(force.normalized * speed);
    }

    public void ResetBallPosition()
    {
        transform.position = new Vector3(-4.4f, 0, 0);
        // call StartOfBall() here will make speed of ball increases heavily
        //StartOfBall();
    }

    private void OnCollisionEnter(Collision collision)
    {
        List<Transform> list;
        // comment the following line to avoid ball stop detecting collisions
        //GetComponent<Rigidbody>().detectCollisions = false;
        BallMovement.repositoryDict.TryGetValue(collision.transform.tag, out list);

        int elementsInAllListsCount = 0;

        foreach (List<Transform> li in BallMovement.repositoryDict.Values)
        {
            elementsInAllListsCount += li.Count;
        }

        if (list == null)
        {
            list = new List<Transform>();
        }

        //list.Add(collision.transform);

        if (!ExistInDict(repositoryDict, collision.transform.tag, collision.transform))
        {
            list.Add(collision.transform);
        }

        BallMovement.repositoryDict.Remove(collision.transform.tag);
        BallMovement.repositoryDict.Add(collision.transform.tag, list);

        //Debug.Log(list.Count);
        Debug.Log(elementsInAllListsCount);
    }

    // detect whether a key-value pair already exists in the dictionary
    private bool ExistInDict(Dictionary<string, List<Transform>> dict, string key, Transform value)
    {
        if (!dict.ContainsKey(key))
        {
            return false;
        }
        else
        {
            if(!dict[key].Contains(value))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
