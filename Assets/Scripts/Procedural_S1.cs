using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Procedural_S1 : MonoBehaviour
{
   
    // declaration variables
    int[,] GrilleMap = new int[20, 5]; // Tableau pour gestion salle1
    int[] EmplacementLanceHaut = new int[] { 13, 15, 17 }; // Gestion emplacement lances
    int[] EmplacementpiegesX = new int[] { 12, 14, 16 ,18 }; // Gestion emplacement autres pièges en X
    int[] EmplacementpiegesY = new int[] {2,3,4}; // Gestion emplacement autres pièges en Y
    int x = 0;
    int xP = 0;
    int yP = 0;
    int xPiege = 0;
    int yPiege = 0;
    int xPiege2 = 0;
    int yPiege2 = 0;
    int HautBas = 0;
    int ChoixPiegeCentre =0;
    int PiegePoseOk = 0;
    [SerializeField]
    GameObject throwSpearsDown;
    [SerializeField]
    GameObject throwSpearsUp;
    [SerializeField]
    GameObject tower;
    [SerializeField]
    GameObject hole;
    [SerializeField]
    GameObject sawDown;
    [SerializeField]
    GameObject sawUp;


    // Use this for initialization
    void Start()
    {
        /**************************************
         * Projectile lance tir salle 1*
         **************************************/

       
        // Gestion emplacement alélatoire des pièges
        for (int i = 0; i <= 1; i++)       
        {
            // Attribution des coordonnées x 
            x = Random.Range(0, 3);
            xPiege = EmplacementLanceHaut[x];

            HautBas = Random.Range(0, 2);

            if (HautBas > 0)
            {
                // Attribution des coordonnées y en fonction si haut ou bas (0 ou 1)
                yPiege = Random.Range(4, 4);

                // Creation du piege sur les coordonnées définis
                // Si la place est déjà occupé, rien n'est placé
                if (PiegePoseOk <= 8)
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
            else
            {
                // Attribution des coordonnées y en fonction si haut ou bas (0 ou 1)
                yPiege = Random.Range(2, 2);

                // Creation du piege sur les coordonnées définis
                // Si la place est déjà occupé, rien n'est placé
                if (PiegePoseOk <= 8)
                {
                    if (GrilleMap[xPiege, yPiege] == 0)
                    {
                        PiegePoseOk++;
                        Vector3 pos0 = new Vector3(xPiege, yPiege, 0);
                        Quaternion rot0 = Quaternion.identity;
                        GameObject Lance0 = (GameObject)Instantiate(throwSpearsUp, pos0, rot0);
                        GrilleMap[xPiege, yPiege] = PiegePoseOk;
                    }
                }
            }
        }      
        /************************
        * Autres pieges  salle 1*
        *************************/

                
        for (int j = 0; j <= 1; j++)
        {
            // Attribution des coordonnées x et y
            xP = Random.Range(0, 5);
            xPiege2 = EmplacementpiegesX [xP];    
                
            yP = Random.Range(0, 4);
            yPiege2 = EmplacementpiegesY[yP];

            // Definition type de piege
            ChoixPiegeCentre = Random.Range(0, 4);

            // Creation du piege sur les coordonnées définis
            // Si la place est déjà occupé, rien n'est placé
            if (PiegePoseOk <= 8)
                {
                    if (GrilleMap[xPiege2, yPiege2] == 0)
                    {
                        PiegePoseOk++;
                        Vector3 pos1 = new Vector3(xPiege2, yPiege2, 0);
                        Quaternion rot1 = Quaternion.identity;
                        //  Spawn du piege en fonction du type
                        if (ChoixPiegeCentre==0)
                        {
                           GameObject tower0 = (GameObject)Instantiate(tower, pos1, rot1);
                        }
                        if (ChoixPiegeCentre == 1)
                        {
                            GameObject hole0 = (GameObject)Instantiate(hole, pos1, rot1);
                        }
                        if (ChoixPiegeCentre == 2)
                        {
                            GameObject sawDown0 = (GameObject)Instantiate(sawDown, pos1, rot1);
                        }
                        if (ChoixPiegeCentre == 3)
                        {
                           GameObject sawUp0 = (GameObject)Instantiate(sawUp, pos1, rot1);
                        }
                    // remplissage du tableau
                    GrilleMap[xPiege2, yPiege2] = PiegePoseOk;

                    // gestion emplacement pour que 2 pieges ne sois pas cote à cote en y
                    if (yPiege2 == 3)
                    {
                        GrilleMap[xPiege2, yPiege2 + 1] = PiegePoseOk;
                        GrilleMap[xPiege2, yPiege2 - 1] = PiegePoseOk;
                    }
                    if (yPiege2 == 2)
                    {
                        GrilleMap[xPiege2, yPiege2 + 1] = PiegePoseOk;                      
                    }
                    if (yPiege2 == 4)
                    {
                        GrilleMap[xPiege2, yPiege2 - 1] = PiegePoseOk;
                    }


                }
                }
            
           
           }
        }

    
    // Update is called once per frame
    void Update()
    {


    }
}

