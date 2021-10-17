using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingScripts : MonoBehaviour
{

    [SerializeField] public Vector3 castingPoint;
    [SerializeField] private GameObject rockProjectile;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(rockProjectile, transform.position + castingPoint, Quaternion.identity);
        }

        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + castingPoint, .25f);
    }
}
