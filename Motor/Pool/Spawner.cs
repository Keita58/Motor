public class Spawner
{

    private Pool<GameObject> pool;
    public Spawner(Pool<GameObject> pool)
    {
        this.pool = pool;
    }

    public void Spawn(int time)
    {
        while (true)
        {
            this.pool.GetElement();
            Thread.Sleep(time*1000);
        }
    }

    public void Despawn(GameObject go)
    {
        this.pool.TryReturnElement(go);
    }
}