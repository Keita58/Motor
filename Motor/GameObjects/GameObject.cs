[Serializable]
public abstract class GameObject 
{
    public abstract string _Nom { get; }
    public abstract List<Component> _Components { get; set; }
    protected GameObject() {}
    public abstract void Dispose();
    public abstract void Start();
    public void Update(float deltaTime)
    {
        foreach(Component c in _Components) 
        {
            c.Update(deltaTime);
        }
    }

    public void Render()
    {
        foreach(Component c in _Components) 
        {
            c.Render();
        }
    }
    
    public abstract void AddComponent(Component component);
    public abstract void RemoveComponent(Component component);
    
    //El where és un extends de la classe Component
    //https://stackoverflow.com/questions/4732494/cs-equivalent-of-javas-extends-base-in-generics
    public abstract bool HasComponent<T>(T component) where T : Component;

    //El where és un extends de la classe Component
    //https://stackoverflow.com/questions/4732494/cs-equivalent-of-javas-extends-base-in-generics
    public abstract T GetComponent<T>(T component) where T : Component;
}