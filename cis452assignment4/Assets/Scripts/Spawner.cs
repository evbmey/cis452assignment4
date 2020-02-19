using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject prefabToSpawn;
    [SerializeField]
    private float initialDelay, repeatRate, repeatRateAlterationTime, repeatRateChange, minimumRepeatRate, maximumRepeatRate;

    private float timeElapsed = 0f;

    public void OnValidate()
    {
            repeatRate = Mathf.Clamp(repeatRate, minimumRepeatRate, maximumRepeatRate);
    }

    public void Start()
    {
        InvokeRepeating(nameof(Spawner.Spawn), initialDelay, repeatRate);
    }

    public void Update()
    {
        if (repeatRate.Equals(minimumRepeatRate) && repeatRateChange < 0f) return;
        else if (repeatRate.Equals(maximumRepeatRate) && repeatRateChange > 0f) return;

        timeElapsed += Time.deltaTime;

        if(timeElapsed > repeatRateAlterationTime)
        {
            repeatRate = Mathf.Clamp(repeatRate + repeatRateChange, minimumRepeatRate, maximumRepeatRate);
            timeElapsed = 0f;
        }
    }

    private void Spawn()
    {
        Instantiate(prefabToSpawn, transform.position, transform.rotation);
    }


}
