using UnityEngine;

public class pivotFollow : MonoBehaviour
{
    public Transform follow;


    // Update is called once per frame
    void Update()
    {
        transform.position = follow.position;
    }
}
