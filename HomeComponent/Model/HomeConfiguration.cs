namespace HomeComponent.Model
{
    public class HomeUIConfiguration
    {

        public ActionType actonType { get; set; }

        public List<Dictionary<string, object>> Params { get; set; }

    }

    public enum ActionType
    {
        Shortcuts, //buttions
        Favorites, // list favourite
        History,   //we already knowthat 
        Controls,   //under the vignette container
        Reports,     //etat favoris
        actions //vignette 
    }
}
