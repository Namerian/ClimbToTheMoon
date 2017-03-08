using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtremityScript : MonoBehaviour
{
    //==========================================================================================
    // variables
    //==========================================================================================

    private HingeJoint2D _hingeJoint; //the hingejoint component of the extremity

    private bool _isMoving; //wether the extremity is being dragged, used to show the ui circle
    private GameObject _helpCircle; //the ui circle that is shown when the extremity is being dragged
    private GameObject _helpCircle2;

    private AbstractAnchorScript _anchor; //the anchor this extremity is anchored to

    //==========================================================================================
    // public properties
    //==========================================================================================

    public bool IsMoving
    {
        get { return _isMoving; }
        set
        {
            if (!_isMoving && value)
            {
                _helpCircle = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/FX/P_GrabHelper"));
                _helpCircle.transform.parent = this.transform;
                _helpCircle2 = _helpCircle.transform.Find("P_GrabHelper2").gameObject;

                Vector3 pos = this.transform.position;
                //pos.z = -1;
                _helpCircle.transform.position = pos;
            }
            else if (_isMoving && !value)
            {
                Destroy(_helpCircle);
                _helpCircle = null;
            }

            _isMoving = value;
        }
    }

    public bool IsAnchored { get; private set; }

    //==========================================================================================
    // monobehaviour methods
    //==========================================================================================

    // Use this for initialization
    void Start()
    {
        _hingeJoint = this.GetComponent<HingeJoint2D>();

        if (_hingeJoint.connectedBody != null)
        {
            _hingeJoint.enabled = true;
            IsAnchored = true;
        }
        else
        {
            _hingeJoint.enabled = false;
            IsAnchored = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IsAnchored && this.transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize)
        {
            //Debug.Log("extremity unanchored because out of screen");
            UnanchorExtremity();
        }


        if(_hingeJoint != null && IsAnchored && _hingeJoint.connectedBody == null)
        {
            _hingeJoint.enabled = false;
            IsAnchored = false;
        }
        else if(_hingeJoint == null && IsAnchored)
        {
            IsAnchored = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BonusObject"))
        {
            Debug.Log("Collision with Bonus Object!");

            UIManager.Instance.AddScore(other.GetComponent<BonusObjectScript>().BonusScore);

            GameObject fx = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/FX/P_TakeItem"));
            fx.transform.position = other.transform.position;

            //other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Anchor") && IsMoving)
        {
            _helpCircle2.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Anchor") && IsMoving)
        {
            _helpCircle2.SetActive(false);
        }
    }

    //==========================================================================================
    // public methods
    //==========================================================================================

    public void AnchorExtremity(AbstractAnchorScript anchor, float breakForce)
    {
        _anchor = anchor;

        if (_hingeJoint == null)
        {
            _hingeJoint = this.gameObject.AddComponent<HingeJoint2D>();
        }

        _hingeJoint.connectedBody = anchor.GetComponent<Rigidbody2D>();

        if (anchor.GetComponent<MovingAnchorScript>() || anchor.GetComponent<LianeAnchor>()) _hingeJoint.breakForce = breakForce;  //On change la breakforce uniquement si l'anchor est un moving anchor
        else if (_hingeJoint.breakForce != Mathf.Infinity) _hingeJoint.breakForce = 99999;  //Faire _hingJoint.breakForce = Mathf.Infinity

        _hingeJoint.enabled = true;

        _anchor.IsInUse = true;

        IsAnchored = true;
    }

    public void UnanchorExtremity()
    {
        if (_anchor != null)
        {
            _anchor.IsInUse = false;
        }

        if (_hingeJoint != null)
        {
            _hingeJoint.connectedBody = null;
            _hingeJoint.enabled = false;
        }

        IsAnchored = false;
    }
}
