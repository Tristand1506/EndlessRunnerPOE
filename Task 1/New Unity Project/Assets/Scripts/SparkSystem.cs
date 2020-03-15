using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkSystem : MonoBehaviour
{
    private ParticleSystem _particleSystem;
    public float sense = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
            //_particleSystem.enableEmission = Physics.Raycast(transform.position, Vector3.down, sense);
        if (Physics.Raycast(transform.position, Vector3.down,out hit, sense))
        {
            _particleSystem.enableEmission = true;
            Debug.Log(Vector3.Distance(transform.position,hit.point));
        }
        else
        {
            _particleSystem.enableEmission = false;

        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position+Vector3.down*sense);

    }
}
