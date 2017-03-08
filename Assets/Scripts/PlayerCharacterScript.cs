using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacterScript : MonoBehaviour
{
    //========================================================
    //
    //========================================================

    [SerializeField]
    private float _draggingMultiplyer = 500f;

    [SerializeField]
    private float _anchorBreakForce = 100f;

    [SerializeField]
    private int _grabScoreBonus = 1000;

    [SerializeField]
    private GameObject _grabFxPrefab;

    //========================================================
    //
    //========================================================

    private List<ExtremityScript> _extremitiesList;

    private bool _isDragging = false;
    private bool _anchoringAllowed = false;
    private ExtremityScript _draggedExtremity;
    private float _levitationTimer;

    private int _numOfAnchoredExtremities;

    private Transform _body;
    private float _originalYpos;
    private float _altitude;
    private float _highestAltitude;
    private string _currentChunkName;

    private bool _isDead;

    //========================================================
    //
    //========================================================

    public float Altitude { get { return _altitude; } }

    public float HighestAltitude { get { return _highestAltitude; } }

    public string CurrentChunkName { get { return _currentChunkName; } }

    //========================================================
    //
    //========================================================

    // Use this for initialization
    void Start()
    {
        _extremitiesList = new List<ExtremityScript>(this.transform.GetComponentsInChildren<ExtremityScript>());
        //Debug.Log("Player has " + _extremitiesList.Count + " extremities!");
        _body = transform.Find("body");
        _originalYpos = _body.position.y;

        EventManager.Instance.OnRockCollisionEvent += OnRockCollisionEvent;
    }

    //========================================================
    //
    //========================================================

    void Update()
    {
        if (_isDead)
        {
            return;
        }

        // DEATH, updating score and altitude

        bool isDead = true;
        float deathPos = Camera.main.transform.position.y - Camera.main.orthographicSize;
        _numOfAnchoredExtremities = 0;

        foreach (ExtremityScript extremity in _extremitiesList)
        {
            if (extremity.transform.position.y >= deathPos)
            {
                isDead = false;
            }

            if (extremity.IsAnchored)
            {
                _numOfAnchoredExtremities++;
            }
        }

        //******************************************
        if (isDead)
        {
            Debug.Log("Player Died!");
            GetComponent<AudioSource>().Play();
            _isDead = true;

            Invoke("ReloadScene", 0.5f);
            return;
        }

        //******************************************
        if (_numOfAnchoredExtremities == 0)
        {
            _levitationTimer += Time.fixedDeltaTime;
        }

        if (_levitationTimer > 1f)
        {
            if (_isDragging)
            {
                _draggedExtremity.IsMoving = false;
                _draggedExtremity = null;

                _isDragging = false;
            }
            
            _anchoringAllowed = false;

            Invoke("AllowAnchoring", 0.5f);
        }

        //******************************************
        UIManager.Instance.UpdateCombo(_numOfAnchoredExtremities);

        _altitude = _body.position.y - _originalYpos;
        UIManager.Instance.UpdateAltitude(_altitude);

        if (_altitude > _highestAltitude)
        {
            _highestAltitude = _altitude;
        }
    }

    // The code for moving the extremities is in the fixedUpdate method because the unity manual recommends using for moving rigidbodies
    void FixedUpdate()
    {
        if (_isDead)
        {
            return;
        }

        //******************************************************
        // DRAG AND DROP MOVEMENT

        if (Input.GetMouseButton(0))
        {
            //**********************
            // mouse down AND dragging
            if (_isDragging /*&& _anchoringAllowed*/)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;

                Vector3 force = mousePos - _draggedExtremity.transform.position;

                if (force.magnitude > 1)
                {
                    force.Normalize();
                }

                _draggedExtremity.GetComponent<Rigidbody2D>().AddForce(force * _draggingMultiplyer);
            }
            //**********************
            // mouse down AND NOT dragging
            else
            {
                //Collider2D[] colliders = Physics2D.OverlapPointAll(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                Collider2D[] colliders = Physics2D.OverlapCircleAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), 0.2f);

                if (colliders != null)
                {
                    foreach (Collider2D collider in colliders)
                    {
                        if (collider.CompareTag("Extremity"))
                        {
                            ExtremityScript extremityScript = collider.GetComponent<ExtremityScript>();

                            _draggedExtremity = extremityScript;

                            _draggedExtremity.UnanchorExtremity();
                            _draggedExtremity.IsMoving = true;

                            _isDragging = true;
                            _anchoringAllowed = false;

                            Invoke("AllowAnchoring", 0.1f);

                            break;
                        }
                    }
                }
            }
        }
        //**********************
        // mouse NOT down
        else
        {
            if (_isDragging && _anchoringAllowed)
            {
                Collider2D[] colliders = Physics2D.OverlapBoxAll(_draggedExtremity.transform.position, _draggedExtremity.GetComponent<BoxCollider2D>().size, _draggedExtremity.transform.rotation.z);

                if (colliders != null)
                {
                    foreach (Collider2D collider in colliders)
                    {
                        AbstractAnchorScript anchorScript = collider.GetComponent<AbstractAnchorScript>();

                        if (collider.CompareTag("Anchor") && anchorScript.IsInUse == false)
                        {
                            //Debug.Log("end of drag, anchored extremity");

                            _currentChunkName = anchorScript.transform.parent.parent.name;

                            _draggedExtremity.AnchorExtremity(anchorScript, _anchorBreakForce);
                            GameObject fx = Instantiate(_grabFxPrefab);
                            fx.transform.position = anchorScript.transform.position;

                            if (!anchorScript.usedOnce)
                            {
                                anchorScript.usedOnce = true;
                                UIManager.Instance.AddScore(_grabScoreBonus);
                            }

                            _levitationTimer = 0;

                            EventManager.Instance.SendOnAnchorGrabbedEvent();

                            break;
                        }
                    }
                }
            }

            if (_isDragging)
            {
                _draggedExtremity.IsMoving = false;
                _draggedExtremity = null;

                _isDragging = false;
            }
        }
    }

    //========================================================
    //
    //========================================================

    private void OnRockCollisionEvent()
    {
        if (_isDragging)
        {
            _draggedExtremity.IsMoving = false;
            _draggedExtremity = null;

            _isDragging = false;
        }

        foreach (ExtremityScript extremity in _extremitiesList)
        {
            extremity.UnanchorExtremity();
        }
    }

    private void ReloadScene()
    {
        GameManagerScript.Instance.LoadMenu();
    }

    private void AllowAnchoring()
    {
        _anchoringAllowed = true;
    }
}
