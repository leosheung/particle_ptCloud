using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pos : MonoBehaviour
{
    [SerializeField] GameObject geo;
    public ParticleSystem particles;//I drag the particle system in question in to here.
    ParticleSystem.Particle[] gos;
    int verCount;

    void Awake()
    {
        verCount = geo.GetComponent<MeshFilter>().mesh.vertexCount;
        gos = new ParticleSystem.Particle[verCount];
    }

    // Use this for initialization
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        int index = 0;
        int total = 0;
        Vector3 pos = Vector3.zero;
        total = particles.GetParticles(gos);

        while (index < total)
        {
            if (Random.Range(0, 2) >= 1.8)
            {
                pos = gos[index].position;
                pos = geo.transform.TransformPoint(geo.GetComponent<MeshFilter>().mesh.vertices[index]);
                // pos.x = Mathf.RoundToInt(pos.x);
                // pos.y = Mathf.RoundToInt(pos.y);

                gos[index].position = pos;
                index++;
            }
        }

        particles.SetParticles(gos, total);
    }
}