using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float minTimeDelay = 2f;
    [SerializeField] private float maxTimeDelay = 7f;
    [SerializeField] private Attacker[] attackerPrefabs;
    [SerializeField] private bool spawn = true;


    private LevelController _levelController;
    private void Awake()
    {
        _levelController = FindObjectOfType<LevelController>();
        if (_levelController == null)
            throw new Exception($"No LevelController Object on {SceneManager.GetActiveScene().name} scene");
    }

    private IEnumerator Start()
    {
        _levelController.LevelTimeFinished.AddListener(StopSpawning);
        yield return new WaitForSeconds(Random.Range(minTimeDelay, maxTimeDelay));
        while (spawn)
        {
            var random = Random.Range(0, attackerPrefabs.Length);
            SpawnAttacker(attackerPrefabs[random]);
            yield return new WaitForSeconds(Random.Range(minTimeDelay, maxTimeDelay));
        }
    }

    private void SpawnAttacker(Attacker attacker)
    {
        var attackerObject = Instantiate(attacker, transform);
        attackerObject.transform.position = transform.position;
    }

    private void StopSpawning()
    {
        spawn = false;
    }
}
