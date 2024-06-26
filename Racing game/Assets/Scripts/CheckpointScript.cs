using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public int speedLimit;

    public List<Transform> nextCheckpoints = new List<Transform> ();

    private void Start()
    {
        for (int i = 0; i < nextCheckpoints.Count; i++)
            if (nextCheckpoints[i] == null)
                nextCheckpoints.RemoveAt(i);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<CarAIController>() && other.GetComponent<CarAIController>().nextCheckpoint.gameObject == transform.gameObject)
        {
            CarAIController controller = other.GetComponent<CarAIController>();

            controller.speedLimit = speedLimit;

            if (nextCheckpoints.Count > 0)
            {
                int index = Random.Range(0, nextCheckpoints.Count);
                controller.nextCheckpoint = nextCheckpoints[index];
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        for(int i=0; i < nextCheckpoints.Count; i++)
        {
            if(nextCheckpoints[i] != null && nextCheckpoints[i].gameObject.layer == gameObject.layer)
                Gizmos.DrawLine(transform.position, nextCheckpoints[i].position);
        }
    }
}
