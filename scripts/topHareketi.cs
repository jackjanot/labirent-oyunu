using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class tophareketi : MonoBehaviour
{
    public Button btn;
    private Rigidbody rb;
    public float hiz = 1.8f;
    public Text zaman, can,durum;
    float zamanSayaci = 100f;
    float canSayaci = 20f;
    bool oyunDevam = true;
    bool oyunTamam = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (oyunDevam && !oyunTamam)
        {
            zamanSayaci -= Time.deltaTime;
            zaman.text = (int)zamanSayaci + "";
        }
        else if(!oyunTamam)
        {
            durum.text = "Oyun tamamlanamadý";
            btn.gameObject.SetActive(true);

        }
        if (zamanSayaci < 0)
        {
            oyunDevam = false;
        }
        if (canSayaci == 0)
        {
            oyunDevam = false;
        }
    }

    private void FixedUpdate()
    {
        if (oyunDevam && !oyunTamam)
        {
            float dikey = Input.GetAxis("Horizontal");
            float yatay = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(yatay, 0, dikey);
            rb.AddForce(kuvvet * hiz);
        }
        else
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

        }
    }
    private void OnCollisionEnter(Collision other)
    {
        string objismi = other.gameObject.name;
        if (objismi.Equals("bitis"))
        {
            oyunTamam = true;
            durum.text = "Oyun tamalandý.Tebrikler";
            btn.gameObject.SetActive(true);
        }
        else if (!objismi.Equals("zemin") && !objismi.Equals("labirent zemin") && !objismi.Equals("baslangic")){
            canSayaci -= 1;
            can.text = canSayaci+ "";

        }
    
    }

}
