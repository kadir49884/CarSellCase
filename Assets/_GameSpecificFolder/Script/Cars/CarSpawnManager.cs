using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnManager : MonoBehaviour
{
    private GameObject instantiateHelper;

    [SerializeField, ReadOnly] private GameDatas gameDatas;
    [SerializeField, ReadOnly] private List<Transform> carSpawnPointList = new List<Transform>();

    private void Start()
    {
        RandomizeSpawnPoints();
        for (int i = 0; i < gameDatas.CarList.Count; i++)
        {
            instantiateHelper = Instantiate(gameDatas.CarList[i]);
            instantiateHelper.transform.position = carSpawnPointList[i].position;
            instantiateHelper.transform.rotation = carSpawnPointList[i].rotation;
        }
    }


    // For Optimization
    [Button("SetRef")]
    public void SetRef()
    {
        gameDatas = DataOperations.Instance.gameDatas;
        if (carSpawnPointList.Count < 1)
        {
            carSpawnPointList.Clear();
            foreach (Transform item in transform)
            {
                carSpawnPointList.Add(item);
            }
        }
    }

    private void RandomizeSpawnPoints()
    {
        int spawntCount = carSpawnPointList.Count;
        System.Random rng = new System.Random();

        while (spawntCount > 1)
        {
            spawntCount--;
            int index = rng.Next(spawntCount + 1);
            Transform value = carSpawnPointList[index];
            carSpawnPointList[index] = carSpawnPointList[spawntCount];
            carSpawnPointList[spawntCount] = value;
        }
    }
}
