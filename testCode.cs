class WorldManager {

    public GameObject default_worker;
    public GameObject default_tile;
    public GameObject default_furniture;
    public GameObject default_wall;
    public GameObject default_floor;
    Dictionary<Tile,GameObject> tiles = new Dictionary<Tile,GameObject>();
    Dictionary<Worker,GameObject> workers = new Dictionary<Worker,GameObject>();
    Dictionary<Furniture,GameObject> furnitures = new Dictionary<Furniture,GameObject>();
    Dictionary<Wall,GameObject> walls = new Dictionary<Wall,GameObject>();
    Dictionary<Creature,GameObject> creatures = new Dictionary<Creature,GameObject>();
    List<Room> rooms = new List<Room>();

    public static WorldManager world = {protected get, set}
    void initialise(int x, int y){

    }

    void update(double deltaTime){
        PlayerManager.player.update(deltaTime);
    }

    void create_worker(pos,params_) {
        GameObject worker_go = default_worker;
        Worker worker_class = new Worker(params_);
        workers.Add(worker_class,worker_go);
        instantiate(worker_go,pos,something);
    }

    void create_furniture() {
        GameObject furniture_go = default_worker;
        Furniture furniture_class = new Worker(params_);
        furnitures.Add(furniture_class,furniture_go);
        instantiate(furniture_go,pos,something);
    }

    void delete_workers(){
        var item = workers.First(kvp => kvp.Value == value);
        workers.Remove(item.Key);
    }

    void delete_furniture(){

    }
}

class PlayerManager
{
    public int money;
    public int selected_mode;
    public int build_mode;

    public double game_time;

    // 1 second = 144 game seconds
    public boolean day_passed = false;
    public static PlayerManager player = {protected get, set}
    Dictionary<int, Research> research_tree = new Dictionary<int, Research>();
    Dictionary<int, Quest> quest_list = new Dictionary<int, Quest>();

    public void update(double deltaTime)
    {
        if (day_passed)
        {
            daily_finances();
        }

        completed_quests(); //check for quest completion criteria.
    }

    void daily_finances()
    {
        foreach (worker in workers){
            money -= worker.cost;
        }
    }

    void research_tech(double increment, int tech_id){
        Research research = research_tree.ElementAt(tech_id);
        research.progress+=increment;
        if(research.progress > research.limit){
            research.unlocked = true;
            //do appropriate thing at this point like unlocking items, etc.
        }
    }

    void completed_quests(){
        for (int i = 0; i < quest_list.Count; i++){
            dict[dict.Keys.ElementAt(i)];
        }
    }
}

class Research { 
    double progress; 
    double limit; double unlocked; 
    string description; //Unlocks stored here somehow
}

class Quest { 
    //Stores Quest description, requirements, reward
}

class Worker { 
    
    Vector2 location; 
    int type = pawns.default; 
    int mood; 
    int mood_value; 
    Task task; 
    Vector2 target_location;
    List<Modifier> modifiers = new List<Modifier>();

    void do_task(Task task) {

    }
}

class JobQueue { public static JobQueue queue = {protected get, set} public List jobs = new List(); public void add_job(Tile tile, type){ Job job = new Job(tile,type); //This is run by QAUR?

    jobs.Add(job);
}
}

class Room {

}

class Job {

}

class Tile { 
    Vector2 location; 
    Dictionary ground = null; 
    Dictionary floor = null; 
    Dictionary wall = null; 
    Dictionary icon = null; 
    void add_plan(int type){ 
        if(tile.upper_layer == null){ 
            if(type == BUILD_MODES.furniture){ 
                //create icons, method of passing them
                icon = buildIcons.furniture(); 
                ///item to build need to be added
                JobQueue.queue.add_job(tile,type); 
            } 
            if(type == BUILD_MODES.floor){ 
                //create icons, method of passing them
                icon = buildIcons.floor(); 
                ///item to build need to be added
                JobQueue.queue.add_job(tile,type); 
            } if(type == BUILD_MODES.wall){ 
                //create icons, method of passing them
                icon = buildIcons.wall(); 
                ///item to build need to be added
                JobQueue.queue.add_job(tile,type); 
            } 
        } 
    } 
}

/* class Creature {

}*/

class Wall {

}

class Action { 
    public int type; 
    public Pawn pawn; 
    public Item item; 
    public Room room; 
    public enum actions = {

    }

private bool generate_accident(Double time){
    double num = random.double*accident_probability(type)
    * (1-pawn.skills(type))*time;
    if(num > 0.5){
        room.generate_accident(num);
        return true;
    }
    else{
        return false;
    }
}

public boolean perform(Double time){
    if(action.requirements_met()){
        double increment = pawn.skills(actions.RESEARCH)*time;
        bool success = generate_accident(time);
        if(success){
            pawn.skill_level(type)++;
            action.generate_result();
            return true;
        }
    }
    return false;
}

private void requirements_met(){
    if(type == actions.RESEARCH){
        if(item.type == items.RESEARCH_TABLE){
            if(pawn.skill_level(type) > 2){
                return true;
            }
        }
    }
    return false;
}

private void generate_result(){
    if(type == actions.RESEARCH){
        item.set_value("research_amount",item.get_value("research_amount")+1);
    }
}
}

public class Item { Dictionary values; }

using System.Collections; using System.Collections.Generic;

public class Actions {

    public Dictionary<string, System.Action> myActions = new Dictionary<string, System.Action>();

    public Actions() {
        myActions ["myKey"] = TheFunction;
    }

    public void TheFunction() {
        // your logic here
    }
}

//Then invoke it with:
//Actions.myActions"myKey";
void spread(vector2d pos, double time)
{
    double prob = spreadRate*time;
    if (random.NextDouble() < prob){
            int num = random.Next(0, 3);
            switch (num)
            {
                case 0: 
                    map.get_left(pos).values("grown",1); 
                    break; 
                case 1: 
                    map.get_up(pos).values("grown",1); 
                    break; 
                case 2: 
                    map.get_right(pos).values("grown",1); 
                    break; 
                case 3: 
                    map.get_down(pos).values("grown",1); 
                    break;
            }
        }
    }

    void effect_mood(Modifier mod)
    {
        mood += mod.value; 
        modifiers.append(mod);
    }

class Modifier { 
    int value; 
    string description; 
    string name; 
    Effects effects; //These need to be handled somehow, I currently lack a data structure on this technique for these types of problems.
}

//mouse control details enum MODES { build, delete, place, select, }

enum BUILD_MODES { floor, wall, furniture, }

void click_tile(){ //Get tile somehow Tile tile = Magic.RaytraceBS(); if(mode == build_mode){ if(PlayerManager.player.build_mode == BUILD_MODES.furniture){ if(tile.buildable(BUILD_MODES.furniture)){ //Should include something denoting furniture type tile.add_plan(BUILD_MODES.furniture); } } else if(PlayerManager.player.build_mode == BUILD_MODES.wall){ if(tile.buildable(BUILD_MODES.wall)){ //Should include something denoting wall type tile.add_plan(BUILD_MODES.wall); } } else if(PlayerManager.player.build_mode == BUILD_MODES.floor){ if(tile.buildable(BUILD_MODES.floor)){ //Should include something denoting floor type tile.add_plan(BUILD_MODES.floor); } } else { //Unknown build mode break; } } }

void drag(){ 
    if(mouseDragged == true){ 
        if(dragCompleted == true){ 
            Dictionary<Tile,GameObject> tiles = select_all_tiles(drag_start-drag_end); 
            if(PlayerManager.player.selected_mode == MODES.build){
                for (int i = 0; i < tiles.count; i++)
                {
                    Tile tile = tiles.Keys.ElementAt(i);
                    GameObject go = tiles.somethingSomething(); //get build mode, is it floor, wall, furniture, whatever
                    if(PlayerManager.player.buildmode == BUILD_MODES.furniture){ 
                        //You should not be able to mass drag furniture break;
                    } else if(PlayerManager.player.buildmode == BUILD_MODES.wall){ 
                        if(tile.buildable(BUILD_MODES.wall)){ 
                        //Should include something denoting wall type
                        tile.add_plan(BUILD_MODES.wall); } 
                    } else if(PlayerManager.player.buildmode == BUILD_MODES.floor){ 
                        if(tile.buildable(BUILD_MODES.floor)){ //Should include something denoting floor type
                            tile.add_plan(BUILD_MODES.floor); } 
                    } else { //Unknown build mode
                        break; 
                    } 
                } 
            } 
        } 
    } 
}
