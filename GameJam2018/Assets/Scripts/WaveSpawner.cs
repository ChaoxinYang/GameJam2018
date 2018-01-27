using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

    public Formation[] availableFormations;
    public int[] FormationSpawnOrder;
    public int currentWave, formationsInWave;
    public float interVal, interValDecrease,interValLimit, waveSpawnInterVal, WaveSpawnInterValDecrease,waveSpawnInterValLimit;
   
    public float InterVals { get {return interVal; }set { if (interVal <= interValLimit) { interVal = interValLimit; } else interVal = value; }}
    public float WaveSpawnInterVal { get { return waveSpawnInterVal; } set
        {
            if (waveSpawnInterVal < waveSpawnInterValLimit) { waveSpawnInterVal = waveSpawnInterValLimit; }
            waveSpawnInterVal = value;
        }
        }

    public IEnumerator loopingThroughFormationList() {

        for (int i = 0; i < formationsInWave; i++)
        {   
            yield return new WaitForSeconds(waveSpawnInterVal);
            InterVals -= interValDecrease;
            GameObject formation = ObjectPool.objectPool.GetPooledObjct(availableFormations[FormationSpawnOrder[currentWave]].waveToSpawn, true);
            formation.transform.position = availableFormations[FormationSpawnOrder[currentWave]].waveSpawnPoint;
            formation.SetActive(true);
            if(currentWave < FormationSpawnOrder.Length-1)
            currentWave++;
        }

        //if (currentWave == FormationSpawnOrder.Length / 3) { 
        //    formationsInWave++;
        //}
        WaveSpawnInterVal -= WaveSpawnInterValDecrease;
        yield return new WaitForSeconds(interVal);
        InterVals -= interValDecrease;
        StartCoroutine(loopingThroughFormationList());
    }

	void Start () {
        StartCoroutine(loopingThroughFormationList());
	}
	
}

[System.Serializable]
public class Formation
{   
    
    //public int waveNr;
    public string waveToSpawn;
    public Vector2 waveSpawnPoint;
}

