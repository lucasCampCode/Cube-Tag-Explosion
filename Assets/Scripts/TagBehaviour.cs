using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagBehaviour : MonoBehaviour
{
    public Transform SpawnPoint;
    public bool IsTagger;
    public int SpawnDelay = 3;
    public float ScoreMutliplier = 3;
    public float Score;
    public GameObject TagMarker;
    public GameObject Expolsion;

    private void Update()
    {
        if(!IsTagger)
            Score += ScoreMutliplier * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        //IsTagger = !IsTagger;
        //TagMarker.setActive(!IsTagger);
        if (IsTagger == true)
        {
            IsTagger = false;
            TagMarker.SetActive(false);
        }
        else
        {
            IsTagger = true;
            TagMarker.SetActive(true);
        }

        if (IsTagger == true)
        {
            Instantiate(Expolsion, transform.position, transform.rotation);
            Invoke("Respawn", SpawnDelay);
            gameObject.SetActive(false);
        }

    }
    private void Respawn()
    {
        gameObject.SetActive(true);
        transform.position = SpawnPoint.position;
    }
}
