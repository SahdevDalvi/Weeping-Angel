using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using System.Collections;
using System.Collections.Generic;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    Vector3 destination;
    public Camera Playercam;
    public float speed, catchDistance;

    // Update is called once per frame
    void Update()
{
    Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Playercam);
    float distance = Vector3.Distance(transform.position, player.position);
    bool inFrustum = GeometryUtility.TestPlanesAABB(planes, this.gameObject.GetComponent<Renderer>().bounds);

    bool visible = false;
    if (inFrustum)
    {
        Vector3 dir = (transform.position - Playercam.transform.position).normalized;
        Ray ray = new Ray(Playercam.transform.position, dir);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == this.transform)
            {
                visible = true;
            }
        }
    }

    if (visible)
    {
        agent.speed = 0;
        agent.SetDestination(transform.position);
    }
    else
    {
        agent.speed = speed;
        agent.SetDestination(player.position);
    }

    if (distance < catchDistance)
    {
        player.gameObject.SetActive(false);
        StartCoroutine(killPlayer());
    }
}
   private IEnumerator killPlayer()
    {
        yield return new WaitForSeconds(1f);
        player.gameObject.SetActive(true);
        player.position = new Vector3(-5.7f , 5.73f, -8.73f);
    }
}
