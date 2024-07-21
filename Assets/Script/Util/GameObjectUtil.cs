using UnityEngine;

public static class GameObjectUtils
{
    public static GameObject FindInactiveObjectByName(string name)
    {
        GameObject[] rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject rootObject in rootObjects)
        {
            GameObject foundObject = FindInactiveObjectByName(rootObject, name);
            if (foundObject != null)
            {
                return foundObject;
            }
        }
        return null;
    }

    private static GameObject FindInactiveObjectByName(GameObject parent, string name)
    {
        if (parent.name == name)
        {
            return parent;
        }

        foreach (Transform child in parent.transform)
        {
            GameObject foundObject = FindInactiveObjectByName(child.gameObject, name);
            if (foundObject != null)
            {
                return foundObject;
            }
        }
        return null;
    }
}
