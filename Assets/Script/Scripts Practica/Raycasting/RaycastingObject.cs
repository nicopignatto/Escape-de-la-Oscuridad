using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingObject : MonoBehaviour
{
    [Header("Distancia del raycast")]
    [Range(0.5f,5f)]
    [SerializeField] private float distRayo;

    [Header("Layer raycast")]
    [SerializeField] private LayerMask layerMaskRaycastPrueba;

    [Header("Linkeos")]
    [SerializeField] private GameObject posRayo;//esta es la posicion del raycast q es la pos. de un objeto vacio.

    //variables privadas
    private RaycastHit2D raycastH2D;

    private void FixedUpdate()
    {
        raycastH2D = Physics2D.Raycast(posRayo.transform.position, Vector2.right, distRayo, layerMaskRaycastPrueba);
        //raycastH2D = Physics2D.Raycast(posRayo.transform.position, Vector2.right, distRayo);
        //Debug.DrawRay(posRayo.transform.position, Vector3.right * distRayo, Color.magenta);
        DebugRaycastInfoCollision();
        //DebugRaycast();
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(posRayo.transform.position, Vector3.right * distRayo);
        
    }

    private void DebugRaycast()
    {
        if (raycastH2D == true)
        {
            Debug.Log("colisiono con algo");
        }
    }

    private void DebugRaycastInfoCollision()
    {
        if (raycastH2D && raycastH2D.collider.tag == "Enemy")
        {
            Debug.Log("el nombre del objeto con el que colisiona es: " + raycastH2D.collider.name);            
        }
    }
    /*
    Consejo Raycast2D:Hay que recordar que los raycast pueden colisionar desde su inicio hasta su final,por lo tanto si los vamos
    a poner en una posicion en la que estaria colisionando con algo en su inicio.Lo mejor es ponerle al objeto con el que colisio
    na desde su inicio una LayerMask distinta(ej. "IgnoreRaycast") o también especificarle al raycast una LayerMask especifica y 
    asignarle esa misma LayerMask al objeto con el que queremos que colisione el raycast.
    */
}