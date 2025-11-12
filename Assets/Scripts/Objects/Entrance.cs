using UnityEngine;

public class Entrance : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject.Find("PlayerContainer").transform.position = gameObject.transform.position + new Vector3(1, 2, 0);
    }
}
