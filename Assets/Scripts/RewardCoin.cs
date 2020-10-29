using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

public class RewardCoin : MonoBehaviour
{
    public AudioSource sfx;
    public bool fadeOut = false;
    public int score = 1;

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
            transform.position = transform.position + new Vector3(0, 0.1f, 0);
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
        //Debug.Log("Object name:" + other.name);
        if (other.name == "ColliderFront" && hitable == true)
        {
            GameEvents.current.rewardCollect(score);

            hitable = false;
            CarAudio myCar = other.GetComponentInParent(typeof(CarAudio)) as CarAudio;
            //myCar.points++;
            sfx.Play();

            fadeOut = true;
        }
    }
}
