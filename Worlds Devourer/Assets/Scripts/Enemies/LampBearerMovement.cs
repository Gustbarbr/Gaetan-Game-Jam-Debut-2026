using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class LampBearerMovement : MonoBehaviour
{
    public GameObject teleportPointA;
    public GameObject teleportPointB;
    public GameObject actualTeleportPoint;

    public EnemyHealth health;

    private void Start()
    {
        actualTeleportPoint = teleportPointA;
        transform.position = actualTeleportPoint.transform.position;
        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        while (true)
        {
            if(actualTeleportPoint == teleportPointA)
            {
                transform.position = teleportPointB.transform.position;
                actualTeleportPoint = teleportPointB;
            }

            else if(actualTeleportPoint == teleportPointB)
            {
                transform.position = teleportPointA.transform.position;
                actualTeleportPoint = teleportPointA;
            }

            yield return new WaitForSeconds(5f);
        }
    }
}
