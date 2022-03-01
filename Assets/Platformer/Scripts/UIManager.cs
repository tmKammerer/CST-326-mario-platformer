using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject water;
    public GameObject goal;
    public GameObject brick;
    public GameObject question;
    public GameObject player;

    public AudioClip breaker;

    public AudioClip bring;
    private float amount = 0f;
    private float points = 0f;

    public TextMeshProUGUI coin;
    public TextMeshProUGUI score;
    // Start is called before the first frame update
    void Start()
    {
        coin.text = $"{amount}";
        score.text = $"{points}";
    }

    // Update is called once per frame
    void Update()
    {
       
            Ray ray = new Ray(transform.position, Vector3.up);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 200.0f))
            {
                AudioSource audio = GetComponent<AudioSource>();
                
                if (hit.collider.gameObject.name == "Brick(Clone)")
                {
                    audio.clip = breaker;
                    points += 100;
                    score.text = $"{points}";
                    GameObject.Destroy(hit.transform.gameObject);
                    audio.Play();
                    
                }
                if(hit.collider.gameObject.name == "Question(Clone)")
                {
                    audio.clip = bring;
                    audio.Play();
                    amount++;
                    coin.text = $"{amount}";
                    points += 100;
                    score.text = $"{points}";
                }
                
                
                
                

            }
     }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "water(Clone")
        {
            Destroy(player);
        }
        if(other.gameObject.name == "goal(Clone")
        {
            Debug.Log("You win!");
        }
    }


}


