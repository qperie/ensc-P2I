﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirDroit : MonoBehaviour
{

    public Vector3 positions = new Vector3(2, -4, 0);
    private MoveViseur viseur;
    private Joueur monJoueur;

    // Use this for initialization
    void Start()
    {
        this.viseur = GameObject.Find("viseurDroit").GetComponent<MoveViseur>();
        this.monJoueur = GameObject.Find("Joueur").GetComponent<Joueur>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (this.monJoueur.munitions > 0)
            {
                Debug.Log("Tire avec l'arme DROITE");
                this.monJoueur.MAJMunitions(1);
                GameObject ennemisPlusProche = this.viseur.ennemis[this.viseur.indice];
                //float tailleViseur = this.viseur.tailleViseur.x;
                float tailleViseur = (float)2.56;
                float coordX = ennemisPlusProche.transform.position.x;
                if ((coordX < this.viseur.positions.x + tailleViseur) && (coordX > this.viseur.positions.x - tailleViseur))
                {
                    int points = 0;
                    if (ennemisPlusProche.name == "pouleGauche(Clone)" || ennemisPlusProche.name == "pouleDroite(Clone)")
                    {
                        points = 10;
                    }
                    this.monJoueur.MAJPoints(points);
                    Destroy(ennemisPlusProche);
                }
            }
            else
            {
                // Bruit d'echec
            }
        }
    }
}
