using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corda : MonoBehaviour
{
    public Transform personaggio1;
    public Transform personaggio2;
    public float lunghezzaMassima;
    public float rigidita = 5f;
    public float ritrazioneVelocita = 5f;
    public float allungamentoVelocita = 5f;

    private LineRenderer lineRenderer;
    private Rigidbody2D rbPersonaggio1;
    private Rigidbody2D rbPersonaggio2;
    private Vector2 direzioneIniziale;
    private void Start()
    {
         lineRenderer = GetComponent<LineRenderer>();
        rbPersonaggio1 = personaggio1.GetComponent<Rigidbody2D>();
        rbPersonaggio2 = personaggio2.GetComponent<Rigidbody2D>();

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, personaggio1.position);
        lineRenderer.SetPosition(1, personaggio2.position);

        direzioneIniziale = rbPersonaggio2.position - rbPersonaggio1.position;
    
    }

    private void Update()
    {
         Vector2 posizione1 = rbPersonaggio1.position;
        Vector2 posizione2 = rbPersonaggio2.position;

        Vector2 direzioneAttuale = posizione2 - posizione1;
        float distanzaAttuale = direzioneAttuale.magnitude;

        if (distanzaAttuale > lunghezzaMassima)
        {
            direzioneAttuale = direzioneAttuale.normalized * lunghezzaMassima;
            posizione2 = posizione1 + direzioneAttuale;
            rbPersonaggio2.position = posizione2;
        }
        else if (distanzaAttuale < lunghezzaMassima)
        {
            Vector2 ritrazione = (direzioneIniziale.normalized * lunghezzaMassima) - direzioneAttuale;
            rbPersonaggio1.velocity += ritrazione * ritrazioneVelocita * Time.deltaTime;
            rbPersonaggio2.velocity -= ritrazione * ritrazioneVelocita * Time.deltaTime;
        }

        lineRenderer.SetPosition(0, posizione1);
        lineRenderer.SetPosition(1, posizione2);

        Vector2 forza = rigidita * (direzioneIniziale - direzioneAttuale);
        rbPersonaggio1.AddForce(forza);
        rbPersonaggio2.AddForce(-forza);

       
    }
}







