using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class ConstructLocalizationDatabase : MonoBehaviour {

    public string localFile;//имя файла локализации
    public bool localizationSet;//установлена ли локализация (переменная нужна для самого старта игры, после выбора языка делаем базу с локализацией и все)
    public List<Localization> locDatabase = new List<Localization>();//лист всех вещей
    public JsonData locData;//файл json с праметрами вещей

    public List<Dialog> dialogDatabase = new List<Dialog>();
    public JsonData dialogData;

    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(this);
        localizationSet = false;
        /* отладка */
        //localFile = "//StreamingAssets/EN_Localization.cell";
        //locData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + localFile));
        //ConstructDatabse();//фукнция построения базы локализации
        //localizationSet = false;//говорим, что локализация была, чтобы больше сюда не заходить
        /*                   */
    }

    // Update is called once per frame
    void Update ()
    {
        if (localizationSet)//если не было локализации, инициализируем базу текстов
        {
            //открываем и читаем файл с локализацией /StreamingAssests/XX_Localization.cell
            locData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + localFile + "Localization.blood"));
            ConstructDatabse();//фукнция построения базы локализации

            dialogData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + localFile + "Dialogs.blood"));
            ConstructDialogDatabase();

            localizationSet = false;//говорим, что локализация была, чтобы больше сюда не заходить
        }
    }

    void ConstructDatabse()//функция построения базы
    {
        for (int i = 0; i < locData.Count; i++)//цикл по количеству всех объектов
        {
            //добавляем в лист объектов новый объект с параметрами, которые прочитали в json файле
            locDatabase.Add(new Localization(locData[i]["key"].ToString(), locData[i]["label"].ToString()));
        }
    }

    public string FetchLocByKey(string key)//получаем локализированный текст по его ключу
    {
        for (int i = 0; i < locData.Count; i++)//идем по всем объектам
        {
            if (locDatabase[i].key == key)//если в списке веще есть обдъект с нужным ключом
            {
                return locDatabase[i].label;//возвращаем эту текст
            }
        }
        return null;//если нет сопадения, то ничего не взвращаем
    }

    void ConstructDialogDatabase()
    {
        for (int i = 0; i < dialogData.Count; i++)//цикл по количеству всех объектов
        {
            //добавляем в лист объектов новый объект с параметрами, которые прочитали в json файле
            dialogDatabase.Add(new Dialog(dialogData[i]["key"].ToString(), dialogData[i]["dialog"].ToString()));
        }
    }

    public string FetchDialogByKey(string key)//получаем локализированный текст по его ключу
    {
        for (int i = 0; i < dialogData.Count; i++)//идем по всем объектам
        {
            if (dialogDatabase[i].key == key)//если в списке веще есть обдъект с нужным ключом
            {
                return dialogDatabase[i].dialog;//возвращаем эту текст
            }
        }
        return null;//если нет сопадения, то ничего не взвращаем
    }

}

public class Localization //собственно, класс локализированных текстов
{
    /*====все атрибуты======*/
    public string key { get; set; }
    public string label { get; set; }
    /*=============================*/

    //Конструктор
    public Localization(string key, string label)
    {
        //выставляем параметры
        this.key = key;
        this.label = label;
    }

    //если создаем без параметров, то она как бы есть, но пустая 
    public Localization()
    {
        this.key = null;
    }
}

public class Dialog
{
    public string key { set; get; }
    public string dialog { set; get; }

    public Dialog(string key, string dialog)
    {
        this.key = key;
        this.dialog = dialog;
    }

    public Dialog()
    {
        this.key = null;
        this.dialog = null;
    }
}
