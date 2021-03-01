using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float minTimeDelay = 2f;
    [SerializeField] private float maxTimeDelay = 7f;
    [SerializeField] private Attacker[] attackerPrefabs;
    [SerializeField] private bool spawn = true;

    private IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minTimeDelay, maxTimeDelay));

            var random = Random.Range(0, attackerPrefabs.Length);
            SpawnAttacker(attackerPrefabs[random]);

        }
    }

    private void SpawnAttacker(Attacker attacker)
    {
        var attackerObject = Instantiate(attacker, transform);
        attackerObject.transform.position = transform.position;
    }
}
