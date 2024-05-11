/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class NPCController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] spots;
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private int currentSpot;
    [SerializeField]
    private float distanceThreshold = 0.1f;
    NavMeshAgent Agent;

    private void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.speed = speed;
        SwitchCase();

        currentSpot = -1;
        ChooseRandomSpot();
    }
    
    void SwitchCase()
    {
        string Tag = this.gameObject.tag;
        switch(Tag)
        {
            case "Deer": spots = GameObject.FindGameObjectsWithTag("DeerSpot");
                break;
            case "Rabbit": spots = GameObject.FindGameObjectsWithTag("RabbitSpot");
                break;
            case "Bird": spots = GameObject.FindGameObjectsWithTag("BirdSpot");
                break;
            case "Bear": spots = GameObject.FindGameObjectsWithTag("BearSpot");
                break;
        }
    }

    private void Update()
    {
        if (!Agent.pathPending && Agent.remainingDistance < distanceThreshold)
        {
            ChooseRandomSpot();

        }
    }

    void ChooseRandomSpot()
    {
        int newSpot = currentSpot;
        while (newSpot == currentSpot)
        {
            newSpot = Random.Range(0, spots.Length);

        }
        currentSpot = newSpot;

        Agent.SetDestination(spots[currentSpot].transform.position);
       
    }
}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float distanceThreshold = 0.1f;
    private NavMeshAgent agent;
    private GameObject[] spots;
    private int currentSpotIndex = -1;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        SwitchCase();
        ChooseRandomSpot();
    }

    private void SwitchCase()
    {
        string tag = this.gameObject.tag;

        switch (tag)
        {
            case "Deer":
                spots = GameObject.FindGameObjectsWithTag("DeerSpot");
                break;
            case "Rabbit":
                spots = GameObject.FindGameObjectsWithTag("RabbitSpot");
                break;
            case "Bird":
                spots = GameObject.FindGameObjectsWithTag("BirdSpot");
                break;
            case "Bear":
                spots = GameObject.FindGameObjectsWithTag("BearSpot");
                break;
            default:
                Debug.LogWarning("Unrecognized tag: " + tag);
                break;
        }
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < distanceThreshold)
        {
            ChooseRandomSpot();
        }
    }

    private void ChooseRandomSpot()
    {
        if (spots == null || spots.Length == 0)
        {
            Debug.LogError("No spots found for NPC.");
            return;
        }

        int newSpotIndex = currentSpotIndex;
        while (newSpotIndex == currentSpotIndex)
        {
            newSpotIndex = Random.Range(0, spots.Length);
        }
        currentSpotIndex = newSpotIndex;

        agent.SetDestination(spots[currentSpotIndex].transform.position);
        // Burada hareket animasyonunu oynatmak için gerekli kodu ekleyebilirsiniz.
        // Örneðin, hareket animasyonu bileþeni (Animator) varsa, burada oynatma kodunu ekleyin.
    }
}
