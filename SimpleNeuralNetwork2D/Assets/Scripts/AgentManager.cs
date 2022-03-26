using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentManager : MonoBehaviour
{

    private List<Agent> _agents;

    [SerializeField] private Transform _target;
    [SerializeField] private GameObject _agentPrefab;


    [SerializeField] private int _populationSize;

    private void Start()
    {
        SpawnAgents();
        StartCoroutine(LearningRoutine());
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _target.transform.position = mousePosition;
        }
    }


    private IEnumerator LearningRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(15);

            StopAgents();
            SetNextGeneration();
            ResetAgents();
        }
    }

    private void StopAgents()
    {
        foreach (Agent agent in _agents)
        {
            agent.IsActive = false;
        }
    }

    private void SetNextGeneration()
    {
        _agents.Sort();

        for (int i = 0; i < _populationSize / 2; i++)
        {
            _agents[i].Brain = _agents[_populationSize - 1 - i].Brain.Copy();
            _agents[i].Brain.Mutate();
        }

        if (_populationSize % 2 != 0)
        {
            int index = _populationSize / 2;

            _agents[index].Brain = _agents[_populationSize - 1].Brain.Copy();
            _agents[index].Brain.Mutate();

        }

    }

    private void ResetAgents()
    {

        foreach (Agent agent in _agents)
        {
            float x = Random.Range(-10f, 10f);
            float y = Random.Range(-10f, 10f);

            Vector2 spawnPosition = new Vector2(x, y);

            agent.transform.position = spawnPosition;
            agent.Brain.Fitness = 0;
            agent.IsActive = true;
        }

    }



   


    private void SpawnAgents()
    {
        _agents = new List<Agent>();

        for (int i = 0; i < _populationSize; i++)
        {
            float x = Random.Range(-10f, 10f);
            float y = Random.Range(-10f, 10f);

            Vector2 spawnPosition = new Vector2(x, y);

            GameObject instance = Instantiate(_agentPrefab, spawnPosition, _agentPrefab.transform.rotation);

            Agent agent = instance.GetComponent<Agent>();
            agent.Brain = new NeuralNetwork(new int[] { 1, 10, 10, 1 });
            agent.Brain.Mutate();
            agent.Target = _target;

            agent.IsActive = true;

            _agents.Add(agent);
        }

    }


}
