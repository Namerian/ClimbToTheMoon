using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingAnchorScript : AbstractAnchorScript
{
    //========================================================
    //
    //========================================================

    [SerializeField]
    private float _yOffset = 1f;
    [SerializeField]
    private float _xOffset = 1f;
    [SerializeField]
    private float _speed = 1f;

    [SerializeField]
    private Sprite horizontal;

    //========================================================
    //
    //========================================================

    private Vector3 _basePos;
    private float _timer;

    AudioClip[] audioclips;

    Rigidbody2D rb;

    //========================================================
    //
    //========================================================

    // Use this for initialization
    void Start()
    {
        _basePos = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
        if (_xOffset != 0) GetComponentInChildren<SpriteRenderer>().sprite = horizontal;
    }

    //========================================================
    //
    //========================================================

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime * _speed;

        //this.transform.position = new Vector3(_basePos.x, _basePos.y + Mathf.PingPong(_timer, _yOffset), _basePos.z);

        if(_yOffset != 0 && _xOffset != 0) rb.MovePosition(new Vector3(_basePos.x + Mathf.PingPong(_timer, _xOffset), _basePos.y + Mathf.PingPong(_timer, _yOffset), _basePos.z));
        else if (_yOffset == 0) rb.MovePosition(new Vector3(_basePos.x + Mathf.PingPong(_timer, _xOffset), _basePos.y, _basePos.z));
        else if (_xOffset == 0) rb.MovePosition(new Vector3(_basePos.x, _basePos.y + Mathf.PingPong(_timer, _yOffset), _basePos.z));
    }

    //========================================================
    //
    //========================================================

    private void Initialize(MovingAnchorScript script)
    {
        _yOffset = script._yOffset;
        _xOffset = script._xOffset;
        _speed = script._speed;
    }

    public override void Respawn()
    {
        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Anchors/MovingAnchor"), this.transform.parent);
        go.transform.position = this.transform.position;

        go.GetComponent<MovingAnchorScript>().Initialize(this);

        Destroy(this.gameObject);
    }
}
