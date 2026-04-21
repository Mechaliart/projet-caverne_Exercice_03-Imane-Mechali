using UnityEngine;

public class Jeu : MonoBehaviour
{
    // Static crée une propriété unique pour tous les éléments ayant ce script. 
    // Ex: Si plusieurs objets ont le script et modifie la propriété. C'est changé pour tout le monde.
    //On accède ensuite à une propriété public static avec le nom du script. Ex: Jeu.copieUnique
    public static GameObject copieUnique;


    //Pour accéder à ces propriétés, on utilise ex: Jeu.copieUnique.nombreVies
    public int nombreVies = 4;
    public bool niveau1Complet = false;
    public string nom = "Maxime";


    void Awake()
    {
        // Méthode de programmation appelé Singleton
        // Permet de s'assurer qu'il n'y a toujours qu'un seul exemplaire de ce script sur la scène.
        if (copieUnique == null)
        {
            // Si l'objet est null c'est qu'aucune copie n'existe encore
            // Si c'est le cas, on l'enregistre et on s'assure qu'il persiste si on change de scène
            copieUnique = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //Si copieUnique n'est pas égal à null, c'est qu'il a déjà été enregistré dans un autre script avant. 
            // On détruit la 2e copie pour s'assurer qu'il n'y a toujours qu'un seul exemplaire de ce script sur la scène.
            Destroy(this.gameObject);
        }
    }


}
