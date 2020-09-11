using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Photon.Pun;

public class ScreenSelection : MonoBehaviourPun
{
    #region Singleton 
    //on crée une unique instance accessible de partout
    public static ScreenSelection instance;
    //appelé avant le start
    protected void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("erreur, il y a deja une instance NetworkItemsController");
            return;
        }
        instance = this;
    }
    #endregion

    public Transform warriorPrefabBack;
    public Transform warriorPrefabFace;
    public Transform wizardPrefabBack;
    public Transform wizardPrefabFace;

    public PhotonView PV;
     
    GameObject warriorAlly;
    GameObject wizardAlly;
    public string OwnWarrior;
    public string OwnWizard;
    public void sendList()
    {
        generateAllyCharacter();
        generateEnnemyCharacter();
        loadScene();
    }
    public void InstantiateWarriorAlly(float x, float y, int z)
    {
        warriorAlly = PhotonNetwork.Instantiate(Path.Combine("Prefab", "warriorPrefabBack"), new Vector3(x, y, z), Quaternion.identity);
        PV = warriorAlly.GetComponent<PhotonView>();
        OwnWarrior = warriorAlly.GetComponent<PhotonView>().Owner.ToString();
        warriorAlly.tag = OwnWarrior;
        if (warriorAlly.tag != OwnWarrior)
        {
            warriorAlly.SetActive(false);
            Debug.Log("ça marhe");
        }
    } 
    public void InstantiateWizardAlly(float x, float y, int z)
    {
        wizardAlly = PhotonNetwork.Instantiate(Path.Combine("Prefab", "wizardPrefabBack"), new Vector3(x, y, z), Quaternion.identity);
        PV = wizardAlly.GetComponent<PhotonView>();
        OwnWizard = wizardAlly.GetComponent<PhotonView>().Owner.ToString();
        wizardAlly.tag = OwnWizard;
        if (wizardAlly.tag != OwnWizard)
        {
            wizardAlly.SetActive(false);
        }
}
    public void generateEnnemyCharacter()
    {

        int o = 1;
        foreach (int selected in EnnemySelection)
        {

            if (selected == 0)
            {
                if (o == 1)
                {
                   GameObject warriorEnnemy = PhotonNetwork.Instantiate(Path.Combine("Prefab", "warriorPrefabFace"), new Vector3(-7f, 1.5f, 1), Quaternion.identity);
                    PV = warriorEnnemy.GetComponent<PhotonView>();
                    if (PV.IsMine)
                    {
                        warriorEnnemy.SetActive(false);
                    }
                    o++;
                }
                else if (o == 2)
                {
                    GameObject warriorEnnemy = PhotonNetwork.Instantiate(Path.Combine("Prefab", "warriorPrefabFace"), new Vector3(-6, 2, 1), Quaternion.identity);
                    PV = warriorEnnemy.GetComponent<PhotonView>();
                    if (PV.IsMine)
                    {
                        warriorEnnemy.SetActive(false);
                    }
                    o++;
                }
                else if (o == 3)
                {
                    GameObject warriorEnnemy = PhotonNetwork.Instantiate(Path.Combine("Prefab", "warriorPrefabFace"), new Vector3(-5f, 2.5f, 1), Quaternion.identity);
                    PV = warriorEnnemy.GetComponent<PhotonView>();
                    if (PV.IsMine)
                    {
                        warriorEnnemy.SetActive(false);
                    }
                    o++;
                }

            }
            else if (selected == 1)
            {
                if (o == 1)
                {
                    GameObject wizardEnnemy = PhotonNetwork.Instantiate(Path.Combine("Prefab", "wizardPrefabFace"), new Vector3(-7f, 1.5f, 1), Quaternion.identity);
                    PV = wizardEnnemy.GetComponent<PhotonView>();
                    if (PV.IsMine)
                    {
                        wizardEnnemy.SetActive(false);
                    }
                    o++;
                }
                else if (o == 2)
                {
                    GameObject wizardEnnemy = PhotonNetwork.Instantiate(Path.Combine("Prefab", "wizardPrefabFace"), new Vector3(-6, 2, 1), Quaternion.identity);
                    PV = wizardEnnemy.GetComponent<PhotonView>();
                    if (PV.IsMine)
                    {
                        wizardEnnemy.SetActive(false);
                    }
                    o++;
                }
                else if (o == 3)
                {
                    GameObject wizardEnnemy = PhotonNetwork.Instantiate(Path.Combine("Prefab", "wizardPrefabFace"), new Vector3(-5f, 2.5f, 1), Quaternion.identity);
                    PV = wizardEnnemy.GetComponent<PhotonView>();
                    if (PV.IsMine)
                    {
                        wizardEnnemy.SetActive(false);
                    }
                    o++;
                }
            }
        }
    }
    public void generateAllyCharacter()
    {
        int o = 1;
        foreach (int selected in AllySelection)
        {

            if (selected == 0)
            {
                if (o == 1)
                {
                    InstantiateWarriorAlly(5.5f, 0.25f, 1);
                    o++;
                }
                else if (o == 2)
                {
                    InstantiateWarriorAlly(6.5f, 0.75f, 1);
                    o++;
                }
                else if (o == 3)
                {
                    InstantiateWarriorAlly(7.5f, 1.25f, 1);
                    o++;
                }

            }
            else if (selected == 1)
            {
                if (o == 1)
                {
                    InstantiateWizardAlly(5.5f, 0.25f, 1);
                    o++;
                }
                else if (o == 2)
                {
                    InstantiateWizardAlly(6.5f, 0.75f, 1);
                    o++;
                }
                else if (o == 3)
                {
                    InstantiateWizardAlly(7.5f, 1.25f, 1);
                    o++;
                }
            }
        }
    }

    public List<int> AllySelection = new List<int>();
    public List<int> EnnemySelection = new List<int>();
    public void selectCharacter(int id)
    {
        AllySelection.Add(id);
        EnnemySelection.Add(id);
    }
    public void loadScene()
    {
        SceneManager.LoadScene("Game");
    }
}   

