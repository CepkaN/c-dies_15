using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace c_dies_15
{
    public delegate void Action<in T>(T obj);
    public delegate void EventHandler<T>(T obj);

    public delegate void OrderCompleteDelegate(Object obj);
    internal class Program
    {
        public class FoodItem
        {
            public string Name { get; set; }
            public int Price { get; set; }
            public FoodItem(string str,int n) { Name = str;Price = n; }
            public void Mostra()
            {
                Console.WriteLine(" Название : " + Name + "\n Цена : " + Price + "\n");
            }
        }
        public interface IMenu
        {
            public void AddItem(FoodItem item);
            public void GetMenuItems();
        }
        public class Menu : IMenu {
        public List<FoodItem> EDA { get; set; }
            public Menu() { EDA= new List<FoodItem>();}
            public void AddItem(FoodItem item)
            {
                EDA.Add(item);
            }
            public void GetMenuItems()
            {
                foreach(var H in EDA)
                {
                    H.Mostra();
                }
            }
        }
        public class Order
        {
            public List<FoodItem> Items { get; set; }
            public Order() { Items = new List<FoodItem>();}
            public event OrderCompleteDelegate OrderCompleteEvent;

            public void AddItem(FoodItem F)
            {
                Items.Add(F);
            }
            public void GetTotalPrice()
            {
                int Sum = 0;
                if (Items.Count() > 0)
                {
                    foreach(var Z in Items)
                    {
                        Sum+= Z.Price;
                    }
                }
                Console.WriteLine(" Общая стоимость : " + Sum + "\n");
            }
            public void PlaceOrder()
            {
                if (Items.Count() > 0)
                {
                    OrderCompleteEvent?.Invoke(Items);
                    Console.WriteLine(" Заказ есть \n");
                    GetTotalPrice();
                }
            }
            static void c_ThresholdReached(object sender, EventArgs e)
            {
                Console.WriteLine("The threshold was reached.");
            }
        }
        public interface ISwim
        {
            public void Swim();           
        }
        public interface IWalk
        {
            public void Walk();
        }
        public abstract class Animal
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public void Eat() {
                Console.WriteLine(" Я ем.\n");
            }
            public void Sleep() { 
                Console.WriteLine(" Я сплю.\n");
            }
            public virtual void Mostra() { }
            
        }
        public class Mammal : Animal, ISwim , IWalk
        {
            public string FurColor { get; set; }
            public Mammal(string F,string N,int a)
            {
                this.Name = F; this.Age = a;FurColor= N;
            }
            public void Swim()
            {
                Console.WriteLine(" Я плыву.\n");
            }

            public void Walk()
            {
                Console.WriteLine(" Я хожу.\n");
            }
            public override void Mostra()
            {
                Console.WriteLine(" Назание : " + Name + "\n Возраст : " + Age + "\n Цвет шерсти : " + FurColor + '\n');
            }

        }
        public class Bird : Animal
        {
            public Bird(string N,int A) { Name = N;Age = A; }
            public void Fly()
            {
                Console.WriteLine(" Я летаю.\n");
            }
            public void BuildNest()
            {
                Console.WriteLine(" Пора строить гнездо.\n");
            }
            public override void Mostra()
            {
                Console.WriteLine(" Назание : " + Name + "\n Возраст : " + Age + '\n');
            }

        }
        public class ZOO
        {
            public event EventHandler<Animal> AnimalAdded1;
            public List<Animal> ONI { get; set; }
            public ZOO() { ONI = new List<Animal>(); }
            public void AnimalAdded(Animal animal)
            {
                ONI.Add(animal);
                AnimalAdded1?.Invoke(animal);
                Console.WriteLine(" Животное добавлено \n");
            }
            public void MOSTR()
            {
                foreach(var Z in ONI)
                {
                    Z.Mostra();
                }
            }
        }
        static void Main(string[] args)
        {
            //Menu MEN=new Menu();
            //FoodItem FOO1 = new FoodItem(" Торт", 450);
            //FoodItem FOO2 = new FoodItem(" Шампанское", 4450);
            //FoodItem FOO3 = new FoodItem(" Оливье", 850);
            //FoodItem FOO4 = new FoodItem(" Пана-кота", 550);
            //MEN.AddItem(FOO1);
            //MEN.AddItem(FOO2);
            //MEN.AddItem(FOO3);
            //MEN.AddItem(FOO4);
            //MEN.GetMenuItems();
            //Order ORDA= new Order();
            //ORDA.AddItem(FOO2);
            //ORDA.AddItem(FOO3);
            //ORDA.AddItem(FOO4);
            //ORDA.PlaceOrder();

            Mammal an1 = new Mammal(" Манул", "черный", 6);
            Mammal an2 = new Mammal(" Лиса", " рыжий", 7);
            Mammal an3 = new Mammal(" Тигр", " полосатый", 3);
            Bird br1 = new Bird(" Колибри", 1);
            Bird br2 = new Bird(" Фаэтон", 3);
            Bird br3 = new Bird(" Стриж", 2);
            ZOO zooo= new ZOO();
            zooo.AnimalAdded(an1);
            zooo.AnimalAdded(an2);
            zooo.AnimalAdded(an3);
            zooo.AnimalAdded(br1);
            zooo.AnimalAdded(br2);
            zooo.AnimalAdded(br3);
            zooo.MOSTR();
            an1.Sleep();
            br2.Fly();

        }
    }
}