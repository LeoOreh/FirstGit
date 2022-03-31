using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParameters : MonoBehaviour
{
    GameObject _target;
    public float _Speed = 1f;
    public float _life = 2f;

    public float _DAMAGE = 15;

    bool _collider = false;

    ParticleSystem.MainModule _ps;
    void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(_target.transform);
        _ps = GetComponentInChildren<ParticleSystem>().main;
    }
    private void FixedUpdate()
    {
        if (_collider == false)
            transform.Translate(Vector3.forward.normalized * _Speed * Time.deltaTime);

        if (_collider)
        {
            transform.LookAt(_target.transform);
            transform.Translate(Vector3.forward.normalized * _Speed * Time.deltaTime);


            Color a = _ps.startColor.color;
            Color b = new Color(1, 1, 1, 0);
            _ps.startColor = Color.Lerp(a, b, 0.2f);
            if (_ps.startColor.color.a <= 0.5) Destroy(gameObject);
        }

        Destroy(gameObject, _life);
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == ("Player"))
        {
            _collider = true;
        }
    }

}