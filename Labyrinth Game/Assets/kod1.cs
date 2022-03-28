using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kod1 : MonoBehaviour
{
    
    private Rigidbody rg;
    public UnityEngine.UI.Button btn;
    public UnityEngine.UI.Text zaman,can,durum;
    public float hiz= 2f;
    float zamansayaci =30;
    int cansayaci = 3;
    bool oyunDevam = true;
    bool oyunTamam = false;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody> ();

    }

    // Update is called once per frame
    void Update()
    {
        if (oyunDevam && !oyunTamam){
        zamansayaci-= Time.deltaTime;
        zaman.text=(int)zamansayaci + "";
        }

        else if(!oyunTamam)
        { durum.text ="GAME OVER";
            btn.gameObject.SetActive(true);
        }
        if(zamansayaci<0) oyunDevam = false;
        
    }

    void FixedUpdate() {
        if(oyunDevam && !oyunTamam){
        float yatay = Input.GetAxis ("Horizontal");
        float dikey = Input.GetAxis ("Vertical");

        Vector3 kuvvet =  new Vector3 (yatay,0,dikey);
        rg.AddForce (kuvvet*hiz);
        }
        else {
            rg.velocity = Vector3.zero;
            rg.angularVelocity = Vector3.zero;
        }
    }
    
   void OnCollisionEnter(Collision cls) {
       string objIsmi = cls.gameObject.name;
        if(objIsmi.Equals( "bitis")){
           { oyunTamam = true;
            durum.text = "CONGRATS";
            btn.gameObject.SetActive(true);
           }
        }
        else if(!objIsmi.Equals("zemin") && !objIsmi.Equals("labirentzemin"))
        cansayaci-= 1;
        can.text = cansayaci +"";
        if(cansayaci==0) oyunDevam = false;
   
   }
}
