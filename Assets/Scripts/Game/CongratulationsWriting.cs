using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratulationsWriting : MonoBehaviour
{
    public List<GameObject> writings;
    void Start()
    {
        GameEvents.ShowCongratulationWritings += ShowCongratulationWriting;
    }

    private void OnDisable()
    {

        GameEvents.ShowCongratulationWritings -= ShowCongratulationWriting;
    }

    private void ShowCongratulationWriting()
    {
        var index = UnityEngine.Random.Range(0, writings.Count);
        writings[index].SetActive(true);
    }
}
