using System.Collections;
using UnityEngine;

public class DestroyObjectAfterSetTime : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
