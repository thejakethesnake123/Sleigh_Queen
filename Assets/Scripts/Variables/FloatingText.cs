using UnityEngine;

public class FloatingText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float DestroyTime = 3f;
    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }

    // Update is called once per frame
   
}

