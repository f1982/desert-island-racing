using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource sfx;
    public bool fadeOut = false;

    private bool hitable = true;
    private float fadePerSecond = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        // sfx = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector3.forward * Time.deltaTime * 2f);
        transform.Rotate(0, 90 * Time.deltaTime, 0);
        if (fadeOut)
        {
            var material = GetComponent<Renderer>().material;
            var color = material.color;

            material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSecond * Time.deltaTime));
            if (material.color.a <= 0)
            {
                Destroy(gameObject);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Object name:" + other.name);
        if (other.name == "ColliderFront" && hitable == true)
        {
            hitable = false;
            MyCar myCar = other.GetComponentInParent(typeof(MyCar)) as MyCar;
            myCar.points++;
            sfx.Play();

            fadeOut = true;
        }
    }
}
