﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcTSD_S1 : MonoBehaviour
{
    /***************************
     * Projectile lance tir en bas salle 1*
     * *************************/

    // declaration variables
    int[,] GrilleMap = new int[20, 5]; // Tableau pour gestion salle1
    int xPiege = 0;
    int yPiege = 0;
    int HautBas = 0;
    int PiegePoseOk = 0;
    [SerializeField]
    GameObject throwSpearsDown;


    // Use this for initialization
    void Start()
    {
        // Gestion emplacement alélatoire des lances
        for (int i = 0; i <= 1; i++)
        {

            // Attribution des coordonnées           
            xPiege = Random.Range(13, 19);
            yPiege = Random.Range(4, 4);


            // Creation du piege sur les coordonnées définis
            // Si la place est déjà occupé, rien n'est placé
            if (PiegePoseOk != 30)
            {
                if (GrilleMap[xPiege, yPiege] == 0)
                {
                    PiegePoseOk++;
                    Vector3 pos0 = new Vector3(xPiege, yPiege, 0);
                    Quaternion rot0 = Quaternion.identity;
                    GameObject Lance0 = (GameObject)Instantiate(throwSpearsDown, pos0, rot0);
                    GrilleMap[xPiege, yPiege] = PiegePoseOk;

                }

            }

        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}

