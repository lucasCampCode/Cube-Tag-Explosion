using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagBehaviour : MonoBehaviour
{
    public Transform SpawnPoint;
    public bool IsTagger;
    public int SpawnDelay = 3;
    public float ScoreMutliplier = 3;
    //[HideInInspector]
    public float Score;
    public GameObject TagMarker;
    public GameObject Explosion;

    private void Update()
    {
        if(!IsTagger)
            Score += ScoreMutliplier * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        TagMarker.SetActive(!IsTagger);
        IsTagger = !IsTagger;

        if (IsTagger == true)
        {
            GameObject instantiate = Instantiate(Explosion, transform.position, transform.rotation);
            ParticleSystem system = instantiate.GetComponent<ParticleSystem>();
            Material mat = gameObject.GetComponent<MeshRenderer>().material;
            system.startColor = mat.color;
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
