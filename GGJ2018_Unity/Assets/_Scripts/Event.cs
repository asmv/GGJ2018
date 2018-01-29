public class Event{

    public float delay {get; protected set;}
    public ENEMYTYPE enemy {get; protected set;}
    public FORMATYPE formation {get; protected set;}

    public Event(float d, ENEMYTYPE e, FORMATYPE f){
        this.delay = d;
        this.enemy = e;
        this.formation = f;
    }
}
