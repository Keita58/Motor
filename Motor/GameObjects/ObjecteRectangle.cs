namespace m17;

[Serializable]
public class ObjecteRectangle : GameObject
{
    public override List<Component> _Components { get; set; }
    public override string _Nom { get => "Rectangle"; }

    public ObjecteRectangle() 
    {
        _Components = new List<Component>();
        Start();
    }

    public ObjecteRectangle(float X = 0, float Y = 0, int Width = 250, int Height = 250)
    {
        _Components = new List<Component>();
        Start();
    }
    public override void Dispose()
    {   
        Console.WriteLine("Esborrant GO");
    }

    public override void Start()
    {
        Transform t = new Transform(70, 70);
        AddComponent(t);

        Render_Objecte r = new Render_Objecte(50, 50, Raylib_cs.Color.Blue);
        AddComponent(r);

        Comportament_Moviment c_m = new Comportament_Moviment();
        AddComponent(c_m);
    }

    public override void AddComponent(Component component) 
    {
        _Components.Add(component);
        component.SetGameObject(this);
    }
    
    public override void RemoveComponent(Component component)
    {
        _Components.Remove(component);
    }
    
    //El where és un extends de la classe Component
    //https://stackoverflow.com/questions/4732494/cs-equivalent-of-javas-extends-base-in-generics
    public override bool HasComponent<T>(T component)
    {
        return _Components.Contains(component);
    }

    //El where és un extends de la classe Component
    //https://stackoverflow.com/questions/4732494/cs-equivalent-of-javas-extends-base-in-generics
    public override T GetComponent<T>(T component)
    {
        return (T)_Components[_Components.IndexOf(component)];
    }
}