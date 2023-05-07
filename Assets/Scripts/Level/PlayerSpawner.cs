using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [Header("Dependencies")]
    [SerializeField] private PlayerPathSO playerPath;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private CinemachineVirtualCamera followCamera;
    [SerializeField] private GameObject playerParent;

    public void IntantiatePlayerOnLevel()
    {
        GameObject player = this.GetPlayer();
        Transform entrance = this.GetLevelEntrance(playerPath.LevelEntrance);

        player.transform.position = entrance.transform.position;
        player.transform.parent = playerParent.transform;
        this.followCamera.Follow = player.transform;

        playerPath.LevelEntrance = null;
    }

    private GameObject GetPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject == null)
        {
            playerObject = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        }

        return playerObject;
    }

    private Transform GetLevelEntrance(LevelEntranceSO playerEntrance)
    {
        if (playerEntrance == null)
        {
            return this.transform.GetChild(0).transform;
        }

        LevelEntrance[] levelEntrances = GameObject.FindObjectsOfType<LevelEntrance>();

        foreach (LevelEntrance levelEntrance in levelEntrances)
        {
            if (levelEntrance.Entrance == playerEntrance)
            {
                return levelEntrance.gameObject.transform;
            }
        }

        return this.transform.GetChild(0).transform;
    }
}
