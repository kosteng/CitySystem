using Architecture;
using UnityEngine;

public class ProjectInstaller : MonoBehaviour
{
    private ProjectInfrastructure _projectInfrastructure;
    [SerializeField] private MonoBehaviourConteiner _monoBehaviourConteiner;

    private void Awake()
    {
        _projectInfrastructure = new ProjectInfrastructure(_monoBehaviourConteiner);
        _projectInfrastructure.Awake();
    }

    void Start()
    {
        _projectInfrastructure.Start();
    }

    void Update()
    {
        _projectInfrastructure.Update(Time.deltaTime);
    }
}
