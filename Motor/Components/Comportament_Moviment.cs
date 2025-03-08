public class Comportament_Moviment : Component
{
    public override string _NomComponent => "Comportament_Moviment";

    public Comportament_Moviment() {}

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);

        if(Raylib_cs.Raylib.IsKeyDown(Raylib_cs.KeyboardKey.W))
        {
            foreach(Component aux in _GameObject._Components) 
            {
                if(aux is Transform) {
                    ((Transform)aux)._Y -= 550*deltaTime;
                    break;
                }
            }
        }
        if(Raylib_cs.Raylib.IsKeyDown(Raylib_cs.KeyboardKey.A))
        {
            foreach(Component aux in _GameObject._Components) 
            {
                if(aux is Transform) {
                    ((Transform)aux)._X -= 550*deltaTime;
                    break;
                }
            }
        }
        if(Raylib_cs.Raylib.IsKeyDown(Raylib_cs.KeyboardKey.S))
        {
            foreach(Component aux in _GameObject._Components) 
            {
                if(aux is Transform) {
                    ((Transform)aux)._Y += 550*deltaTime;
                    break;
                }
            }
        }
        if(Raylib_cs.Raylib.IsKeyDown(Raylib_cs.KeyboardKey.D))
        {
            foreach(Component aux in _GameObject._Components) 
            {
                if(aux is Transform) {
                    ((Transform)aux)._X += 550*deltaTime;
                    break;
                }
            }
        }
    }
}