using System;
using System.Collections.Generic;
using UnityEngine;

public class FusionManager : Singleton<FusionManager>
{
    [SerializeField] private int maxCont = 3;
    [SerializeField] private int contador;
    protected override bool persistent => true;
    [Header("Recetas de fusión")]
    public List<FusionRecipe> recipes = new List<FusionRecipe>();

    [Header("Efectos opcionales")]
    public GameObject fusionEffectPrefab;

    // Objetos activos registrados
    public List<FusionItem> activeItems = new List<FusionItem>();

    // Diccionario optimizado
    private Dictionary<string, FusionRecipe> fusionDictionary = new Dictionary<string, FusionRecipe>();




    void Start()
    {
        BuildDictionary();
        contador = 0;
    }
    public void Register(FusionItem item)
    {
        if (!activeItems.Contains(item))
        {
            activeItems.Add(item);
        }
    }

    public void Unregister(FusionItem item)
    {
        if (activeItems.Contains(item))
        {
            activeItems.Remove(item);
        }
    }
    private void BuildDictionary()
    {
    fusionDictionary.Clear();

    foreach (FusionRecipe recipe in recipes)
    {
        string key1 = recipe.itemA + "_" + recipe.itemB;
        string key2 = recipe.itemB + "_" + recipe.itemA;

        fusionDictionary[key1] = recipe;
        fusionDictionary[key2] = recipe;

        Debug.Log($"Agregada receta: {key1} y {key2}");
    }

    Debug.Log($"Todas las claves: {string.Join(", ", fusionDictionary.Keys)}");
}

    private string GenerateKey(ItemType a, ItemType b)
    {
        return a.ToString() + "_" + b.ToString();
    }

  

    public bool TryFusion(FusionItem item1, FusionItem item2, out GameObject resultPrefab)
{
    resultPrefab = null;

    if (item1 == null || item2 == null) return false;

    string key = item1.itemType + "_" + item2.itemType;
    // Debug.Log($"Buscando receta: {key}");

    if(fusionDictionary.TryGetValue(key, out FusionRecipe recipe))
    {
        resultPrefab = recipe.resultPrefab;
        Debug.Log($"Receta encontrada: {recipe.resultPrefab.name}");
        return true;
    }
    else
    {
        // Debug.LogWarning($"No existe receta para {key}");
    }

    return false;
}

   
    public void ExecuteFusion(FusionItem item1, FusionItem item2)
    {
        Debug.Log("Ejecuto");
        if (!TryFusion(item1, item2, out GameObject resultPrefab))
            return;

        // Posición promedio
        Vector3 spawnPosition = (item1.transform.position + item2.transform.position) / 2f;

        // Rotación opcional
        Quaternion spawnRotation = Quaternion.identity;

        // Efecto visual
        if (fusionEffectPrefab != null)
        {
            Instantiate(fusionEffectPrefab,spawnPosition,Quaternion.identity);
        }

        // Remover de lista
        Unregister(item1);
        Unregister(item2);

        // Destruir originales
        Destroy(item1.gameObject);
        Destroy(item2.gameObject);

        // Crear resultado
        GameObject newObject = Instantiate(resultPrefab,spawnPosition,spawnRotation);

        // Registrar automáticamente si tiene FusionItem
        FusionItem fusionItem = newObject.GetComponent<FusionItem>();

        if (fusionItem != null)
        {
            Register(fusionItem);
        }
    }

   

    public void PrintAllRecipes()
    {
        Debug.Log("=== RECETAS DE FUSIÓN ===");

        foreach (FusionRecipe recipe in recipes)
        {
            Debug.Log(recipe.itemA +" + " +recipe.itemB +" => " +recipe.resultPrefab.name);
        }
    }

    public void ResetCount()
    {
        contador = 0;
    }
    public void AddCount()
    {
        contador++;
        if(contador >= maxCont)
        {
            GameManager.SwitchState(GameState.GameOver);
        }
    } 
}