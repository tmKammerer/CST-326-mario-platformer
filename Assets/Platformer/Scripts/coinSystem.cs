using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class coinSystem : MonoBehaviour
{
    //won't take a textmeshpro for some reason, not sure why it won't
    //public TextMeshProUGUI coin;
    public AudioClip bring;
    private float amount=0f;
    // Start is called before the first frame update
    void Start()
    {
        
       // coin.text = $"{amount}";
    }

    // Update is called once per frame
    
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.gameObject != null)
                {
                    
                    AudioSource blink = GetComponent<AudioSource>();
                    blink.clip = bring;
                    blink.Play();

                    //amount++;
                    //coin.text = $"{amount}";
                }
            }
        }
    
}
