using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Drag : MonoBehaviour
{
    [SerializeField]
    private float _draggingMultiplyer = 500f;

    private bool _isDragging = false;
    private GameObject _draggedExtremity;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            if (_isDragging)
            {
                Debug.Log("mouse button down AND dragging!");

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;

                //_draggedExtremity.GetComponent<Rigidbody2D>().MovePosition(mousePos);
                _draggedExtremity.GetComponent<Rigidbody2D>().AddForce((mousePos - _draggedExtremity.transform.position) * _draggingMultiplyer);
            }
            else
            {
                Debug.Log("mouse button down AND not dragging!");

                Collider2D[] colliders = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));

                if (colliders != null)
                {
                    bool foundExtremity = false;

                    foreach (Collider2D collider in colliders)
                    {
                        if (collider.CompareTag("Extremity"))
                        {
                            Debug.Log("Found Extremity!");

                            _draggedExtremity = collider.gameObject;
                            //_draggedExtremity.GetComponent<Rigidbody2D>().isKinematic = true;
                            _draggedExtremity.GetComponent<HingeJoint2D>().enabled = false;

                            if(_draggedExtremity.GetComponent<HingeJoint2D>().connectedBody != null)
                            {
                                _draggedExtremity.GetComponent<HingeJoint2D>().connectedBody.GetComponent<AnchorScript>().IsInUse = false;
                                _draggedExtremity.GetComponent<HingeJoint2D>().connectedBody = null;
                            }

                            _isDragging = true;

                            foundExtremity = true;

                            break;
                        }
                    }

                    if (!foundExtremity)
                    {
                        Debug.Log("hits but no extremity! num of hits=" + colliders.Length);
                    }
                }
                else
                {
                    Debug.Log("mouse click: no hits!");
                }
            }
        }
        else
        {
            if (_isDragging)
            {
                //Collider2D[] colliders = Physics2D.OverlapPointAll(_draggedExtremity.transform.position);
                Collider2D[] colliders = Physics2D.OverlapBoxAll(_draggedExtremity.transform.position, _draggedExtremity.GetComponent<BoxCollider2D>().size, _draggedExtremity.transform.rotation.z);

                bool foundAnchor = false;

                if (colliders != null)
                {
                    foreach (Collider2D collider in colliders)
                    {
                        if (collider.CompareTag("Anchor") && collider.GetComponent<AnchorScript>().IsInUse == false)
                        {
                            collider.GetComponent<AnchorScript>().IsInUse = true;
                            _draggedExtremity.GetComponent<HingeJoint2D>().connectedBody = collider.GetComponent<Rigidbody2D>();

                            _draggedExtremity.GetComponent<HingeJoint2D>().enabled = true;

                            foundAnchor = true;

                            break;
                        }
                    }
                }

                if (!foundAnchor)
                {
                    _draggedExtremity.GetComponent<HingeJoint2D>().enabled = false;
                }

                //_draggedExtremity.GetComponent<Rigidbody2D>().isKinematic = false;
                _draggedExtremity = null;

                _isDragging = false;
            }
        }
    }
}*/
