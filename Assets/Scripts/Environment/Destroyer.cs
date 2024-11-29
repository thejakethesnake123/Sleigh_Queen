using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public string parentName;
    public GameObject Player;

    void Start()
    {
        parentName = transform.name;
        StartCoroutine(DestroyClone());
    }

    void Update()
    {
        if (Player.transform.position.z - transform.position.z > 100)
        {
            Destroy(Clone);
        }
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(70);
        if (parentName == "Section(Clone)")
        {
            Destroy(gameObject);
        }

    }
}
