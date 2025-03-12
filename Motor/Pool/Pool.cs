public class Pool<T>{

    private class PoolElement<T>
    {
        public T element;
        public bool available;

        public PoolElement(T el, bool av)
        {
            element = el;
            available = av;
        }
    }

    IPoolableFactory<T> goFactory;
    List<PoolElement<T>> elements;
    int size;
    public Pool(int n, IPoolableFactory<T> factory){
        size=n;
        elements= new List<PoolElement<T>>();
        goFactory=factory;
        for (int i=0;i<size;i++){
            elements.Add(new PoolElement<T>(goFactory.Create(), true)); 
            Console.WriteLine("AÑADO: "+elements.ElementAt(i).element);
        }
        Console.WriteLine("tamaño lista pool: "+elements.Count);    
    }

    public T GetElement(){
        //Component a = new Component(a);
        foreach (PoolElement<T> element in elements){
            if (element.available){
                element.available = false;
                goFactory.Activate(element.element);
                return element.element;
            }
        }
        
        PoolElement<T> aux = elements.ElementAt(0);
        elements.Remove(aux);
        elements.Add(aux);
        aux.available = false;
        goFactory.Activate(aux.element);
        return aux.element;
    }
    
    public bool TryReturnElement(T gameObject){
         foreach (PoolElement<T> element in elements){
            if (element.element.Equals(gameObject)){
                goFactory.Deactivate(element.element);
                element.available=true;
                return true;
            }
         }
            return false;
        }
}