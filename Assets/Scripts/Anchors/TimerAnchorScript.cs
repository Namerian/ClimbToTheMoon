using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerAnchorScript : AbstractAnchorScript
{
    [SerializeField]
    private float _maxUseTime = 2f;

    private float _useTimer = 0f;

    bool startShaking;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (IsInUse && !startShaking)
        {
            startShaking = true;
            GetComponentInChildren<Shake>().shaking = true;
            GetComponentInChildren<AudioSource>().Play();
        }

        if(startShaking)
        {
            if (_useTimer > _maxUseTime)
            {
                GameObject fx = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/FX/P_priseBreak"));

                Vector3 pos = this.transform.position;
                //pos.z = -1;
                fx.transform.position = pos;

                Destroy(this.gameObject);
            }
            _useTimer += Time.deltaTime;
        }
    }

    private void Initialize(TimerAnchorScript script)
    {
        _maxUseTime = script._maxUseTime;
    }

    public override void Respawn()
    {
        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Anchors/TimerAnchor"), this.transform.parent);
        go.transform.position = this.transform.position;

        go.GetComponent<TimerAnchorScript>().Initialize(this);

        Destroy(this.gameObject);
    }
}
