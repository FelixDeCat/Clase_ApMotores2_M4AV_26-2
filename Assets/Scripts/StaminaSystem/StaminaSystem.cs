using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSystem : MonoBehaviour
{

    //  current y mi max
    int stamina = 5;
    int maxStamina = 5;

    // lo que quiero agregar
    [SerializeField] float seconds_to_add = 5f;

    // Para saber cuanto me falta para la proxima recarga
    DateTime next = new DateTime();

    // las llaves para la persistencia (PlayerPrefs)
    const string NEXT = "next";
    const string CURRENT = "current";

    // La Routine, Loop de recarga
    Coroutine routine = null;

    // UIs, para DEBUG
    [Header("Debug")]
    [SerializeField] TextMeshProUGUI txt_time;
    [SerializeField] TextMeshProUGUI txt_stamina;
    [SerializeField] Button btn_add;
    [SerializeField] Button btn_remove;

    void Start()
    {
        Load();
        if (routine == null) routine = StartCoroutine(UpdateStamina());
        RefreshAndSave();
        FrontEndTimer();


        btn_add.onClick.AddListener(() => { AddStamina(1); });
        btn_remove.onClick.AddListener(() => { UseStamina(1); });
    }

    private void OnDisable()
    {
        Save();
    }

    public void AddStamina(int quant)
    {
        stamina += quant; // Operacion de Lectura y Escritura
        var now = DateTime.Now;
        if (stamina >= maxStamina)
        {
            stamina = maxStamina;
            next = now;
            DeleteSave();
        }
        else
        {
            if (now > next)
            {
                next = next.AddSeconds(seconds_to_add);
            }
            else
            {
                next = now.AddSeconds(seconds_to_add);
            }
        }
        RefreshAndSave();
    }

    public void UseStamina(int quant)
    {

        if (stamina - quant >= 0) // Operacion de Lectura Sola
        {
            stamina -= quant;
        }

        if (stamina < maxStamina)
        {
            DateTime now = DateTime.Now;

            if (now > next)
            {
                next = now.AddSeconds(seconds_to_add);
            }

            if (routine == null)
            {
                routine = StartCoroutine(UpdateStamina());
            }
            else
            {
                Debug.Log("Ya hay una Rutina Corriendo");
            }
           
        }

        RefreshAndSave();
    }

    IEnumerator UpdateStamina()
    {
        while (stamina < maxStamina)
        {
            while (DateTime.Now > next)
            {
                AddStamina(1);  /// next +5, next +5, next +5
            }

            FrontEndTimer();
            yield return new WaitForSeconds(1f);
        }

        routine = null;
    }


    #region Front
    void FrontEndTimer()
    {
        if (stamina >= maxStamina)
        {
            txt_time.text = "Stamina FULL";
            return;
        }

        TimeSpan rest = next - DateTime.Now;
        txt_time.text = $"<b>Next:</b> {DateTimePretiffy(next)} " +
            $"\n<b>Rest:</b> <color=green>{DateTimePretiffy(rest)}</color>"; 
    }
    void RefreshAndSave()
    {
        txt_stamina.text = stamina.ToString() + "/" + maxStamina.ToString();
        Save();
    }

    string DateTimePretiffy(DateTime time)
    {
        return time.Minute.ToString("00") + ":" + time.Second.ToString("00");
    }
    string DateTimePretiffy(TimeSpan time)
    {
        return time.Minutes.ToString("00") + ":" + time.Seconds.ToString("00");
    }
    #endregion

    #region Persistencia
    void Save()
    {
        Debug.Log($"Guardando... {next.ToString()} y {stamina}");
        PlayerPrefs.SetString(NEXT, next.ToString());
        PlayerPrefs.SetInt(CURRENT, stamina);
        PlayerPrefs.Save();
    }
    void Load()
    {
        next = StringToDate(PlayerPrefs.GetString(NEXT));
        stamina = PlayerPrefs.GetInt(CURRENT, maxStamina);
        Debug.Log($"Se cargo {next.ToShortTimeString()} y {stamina}");
    }
    DateTime StringToDate(string st)
    {
        if (String.IsNullOrEmpty(st))
        {
            return DateTime.Now;
        }
        else
        {
            return DateTime.Parse(st);
        }
    }
    void DeleteSave()
    {
        Debug.Log("<color=red>Limpiando datos...</color>");
        PlayerPrefs.DeleteKey(NEXT);
        PlayerPrefs.DeleteKey(CURRENT);
    }
    #endregion

}
