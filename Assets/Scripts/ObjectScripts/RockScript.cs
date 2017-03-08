using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    [SerializeField]
    private float _fallSpeed = 0.1f;

    private Camera _camera;
    private float _radius;
    private Rigidbody2D _rigidbody;

    // Use this for initialization
    void Start()
    {
        _camera = Camera.main;
        _radius = GetComponent<CircleCollider2D>().radius;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (this.transform.position.y + _radius < _camera.transform.position.y - _camera.orthographicSize - 10)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Vector2 pos = this.transform.position;
            pos.y -= _fallSpeed * Time.fixedDeltaTime;
            _rigidbody.MovePosition(pos);
        }
    }
}
