using UnityEngine;

public class MiniMapRobin : MonoBehaviour
{
    [SerializeField]
    GameObject MiniMap;
    Transform Robin;

    private void Start()
    {
        Robin = GetComponent<Transform>();

    }
    private void Update()
    {
        if(Robin.position.y > 10f)
        {
            MiniMap.SetActive(true);
        }
    }
}
