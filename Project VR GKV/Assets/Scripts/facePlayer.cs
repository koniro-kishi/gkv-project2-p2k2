using UnityEngine;

public class facePlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = Camera.main.transform.position - transform.position;
        if (lookDirection.sqrMagnitude > 0.01f)
            transform.rotation = Quaternion.LookRotation(-lookDirection);
    }
}
