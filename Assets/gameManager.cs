using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager _instance;
    public GameObject[] pass0;
    public GameObject[] pass1;
    public GameObject[] pass2;
    public GameObject[] volki;
    public GameObject[] kroliki;
    public GameObject[] passes;
    public GameObject[] animals;
    public GameObject[] targets;
    public GameObject UI;
    public List<bool> targetTag;

    public bool isGameOver = false;
    public bool isStart = false;


    public GameObject[] dialogUI;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        Time.timeScale = 1f;

        if (_instance == null)
        {
            _instance = this;
        }
        for (int i = 0; i < targets.Length; i++)
        {
            targetTag.Add(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTagTarget(string tag)
    {
        int k = 0;
        //Проход по всем целям и поиск нужного индекса
        if (tag != "volki" && tag != "kroliki")
        {



            for (int i = 0; i < targets.Length; i++)
            {
                if (targets[i].tag == tag)
                {
                    //Debug.Log(tag + " kek eto tag!!!-------------------");
                    targetTag[i] = true;
                    k = i;
                }
            }
            //Получение нового пути от улики чтобы найти новые следы
            if (k != passes.Length)
                foreach (vis_sled item in passes[k].GetComponentsInChildren<vis_sled>())
                {
                    item.SetMaxOpacity(1);
                    item.SetPrevStepColor(new Color(255, 255, 255, 1));

                }

            //Получение цвета улики для различия новых следов
            if (k != 0)
                foreach (vis_sled item in passes[k - 1].GetComponentsInChildren<vis_sled>())
                {
                    switch (tag)
                    {
                        case "ulik1":
                            item.SetPrevStepColor(new Color(0, 0, 255, 1));
                            //StartCoroutine(DiologUIProcess(false, "", "Kroliki ito ne norm"));
                            break;
                        case "ulik2":
                            item.SetPrevStepColor(new Color(255, 0, 255, 1));
                            break;
                        case "ulik3":
                            item.SetPrevStepColor(new Color(255, 0, 255, 1));
                            break;
                        default:
                            item.SetPrevStepColor(new Color(255, 0, 255, 1));
                            break;
                    }
                }
        }else
            switch (tag)
            {
                case "volki":
                    foreach (vis_sled item in animals[1].GetComponentsInChildren<vis_sled>())
                    {
                        StartCoroutine(DiologUIProcess(true, "", "Волков лучше не трогать"));

                        item.SetMaxOpacity(1);
                        item.SetPrevStepColor(new Color(255, 0, 0, 1));
                    }
                    break;
                case "kroliki":
                    foreach (vis_sled item in animals[0].GetComponentsInChildren<vis_sled>())
                    {
                        StartCoroutine(DiologUIProcess(true, "", "Кролики это синий"));
                        item.SetMaxOpacity(1);
                        item.SetPrevStepColor(new Color(255, 255, 0, 1));
                    }
                    break;
                case "ulik0":
                    foreach (vis_sled item in animals[1].GetComponentsInChildren<vis_sled>())
                    {
                        StartCoroutine(DiologUIProcess(false, "Этот запах может привести к цели", "Надо искать рядом следы"));

                        item.SetMaxOpacity(1);
                        item.SetPrevStepColor(new Color(255, 0, 0, 1));
                    }
                    break;
                case "ulik1":
                    foreach (vis_sled item in animals[1].GetComponentsInChildren<vis_sled>())
                    {
                        StartCoroutine(DiologUIProcess(false, "Здесь следы могут разойтись", "Стоит поискать у озера"));

                        item.SetMaxOpacity(1);
                        item.SetPrevStepColor(new Color(255, 0, 0, 1));
                    }
                    break;
                case "ulik2":
                    foreach (vis_sled item in animals[1].GetComponentsInChildren<vis_sled>())
                    {
                        StartCoroutine(DiologUIProcess(false, "Опа, труп, это уже серьезно!", "Рядом точно должны быть следы"));

                        item.SetMaxOpacity(1);
                        item.SetPrevStepColor(new Color(255, 0, 0, 1));
                    }
                    break;
                case "ulik3":
                    foreach (vis_sled item in animals[1].GetComponentsInChildren<vis_sled>())
                    {
                        StartCoroutine(DiologUIProcess(false, "А это что за птица?", "Это Петр!"));

                        item.SetMaxOpacity(1);
                        item.SetPrevStepColor(new Color(255, 0, 0, 1));
                    }
                    break;
                default:
                    break;
            }

        switch (tag)
        {
            case "volki":
                    StartCoroutine(DiologUIProcess(true, "", "Волков лучше не трогать"));
                break;
            case "kroliki":
                    StartCoroutine(DiologUIProcess(true, "", "Кролики это синий"));
                
                break;
            case "ulik0":
                    StartCoroutine(DiologUIProcess(false, "Этот запах может привести к цели", "Надо искать рядом следы"));
                
                break;
            case "ulik1":
                    StartCoroutine(DiologUIProcess(false, "Здесь следы могут разойтись", "Стоит поискать у озера"));
                
                break;
            case "ulik2":
                    StartCoroutine(DiologUIProcess(false, "Опа, труп, это уже серьезно!", "Рядом точно должны быть следы"));
                
                break;
            case "ulik3":
                    StartCoroutine(DiologUIProcess(false, "Так вот, кто настоящий убийца!", "Это Петр!"));
                
                break;
            default:
                break;
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        isGameOver = true;
        UI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        isStart = true;
    }

    IEnumerator DiologUIProcess(bool isDogOnly, string policeText, string dogText)
    {
        if (!isDogOnly)
        {
            yield return new WaitForSeconds(0.1f);
            dialogUI[0].SetActive(true);
            dialogUI[0].GetComponent<DiologUIController>().SetDialogUIText(policeText, 4f);
            yield return new WaitForSeconds(4f);
        }
        else
            yield return new WaitForSeconds(0.1f);

        dialogUI[1].SetActive(true);
        dialogUI[1].GetComponent<DiologUIController>().SetDialogUIText(dogText, 4f);
        yield return new WaitForEndOfFrame();
    }

  


}
