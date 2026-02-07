using System.Collections;
using UnityEngine;

public class DestroyObjectAfterSetTime : MonoBehaviour
{
    public float timeUntilDestroy;

    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timeUntilDestroy);
        Destroy(gameObject);
    }
}
