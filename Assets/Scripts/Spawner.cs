using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float minTimeDelay = 2f;
    [SerializeField] private float maxTimeDelay = 7f;
    [SerializeField] private Attacker attacker;
    [SerializeField] private bool spawn = true;

    private IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minTimeDelay, maxTimeDelay));
            Instantiate(attacker, transform.position, Quaternion.identity);
        }
    }
}
