namespace FoodTrackerApp.Data.Entities
{
    public class ActionFood
    {
        public int Id { get; set; }
        public int ActionID { get; set; }
        public int FoodID { get; set; }
        public virtual Action Action { get; set; }
        public virtual Food Food { get; set; }

        public ActionFood()
        {
        }

    }
}