using System;
using System.Collections.Generic;
using System.Text;

namespace Car_DP_Builder
{
    //***Builder***
    //Спроектировать программу, 
    //которая будет симулировать процесс сборки автомобилей, 
    //другими словами будет создавать объект класса транспортного средства и 
    //наделять его свойствами, которые характерны конкретному автомобилю.
    partial class Program
    {
        static List<Builder> lb = new List<Builder>();
        static void Main(string[] args)
        {
            lb.Add(new ConcreteBuilder_Daewoo_Lanos());
            lb.Add(new ConcreteBuilder_Ford_Probe());
            lb.Add(new ConcreteBuilder_UAZ_Patriot());
            //********** add
            lb.Add(new ConcreteBuilder_Hyundai_Getz());
            //********** add
            List<Product> lp = new List<Product>();
            Builder builder;
            for (int i = 0; i < 5; i++)
            {

                builder = new ConcreteBuilder_Daewoo_Lanos();

                Director director = new Director(builder);
                director.Construct();
                Product product = builder.GetResult();

                product.Show();
            }


            /*            
                        // содаем объект пекаря
                        Baker baker = new Baker();
                        // создаем билдер для ржаного хлеба
                        BreadBuilder builder = new RyeBreadBuilder();
                        // выпекаем
                        Bread ryeBread = baker.Bake(builder);
                        Console.WriteLine(ryeBread.ToString());
                        // оздаем билдер для пшеничного хлеба
                        builder = new WheatBreadBuilder();
                        Bread wheatBread = baker.Bake(builder);
                        Console.WriteLine(wheatBread.ToString());
            */
            Console.Read();
        }
    }

    class Director
    {
        Builder builder;
        public Director(Builder builder)
        {
            this.builder = builder;
        }
        public void Construct()
        {
            builder.BuildPartBody();
            builder.BuildPartEngine();
            builder.BuildPartWheels();
            builder.BuildPartGearBox();
        }
    }

    abstract class Builder
    {
        //public string NameMechanism { get; set; } //Имя механизма
        public abstract void BuildPartBody(); //Корпус
        public abstract void BuildPartEngine(); //Двигатель (л. с)
        public abstract void BuildPartWheels(); //Колеса (R)
        public abstract void BuildPartGearBox(); //Коробка переключения передач К. П. П.
        public abstract Product GetResult();
    }

    public class Product
    {
        List<object> parts = new List<object>();
        public void Add(string part)
        {
            parts.Add(part);
        }
        public void Show()
        {
            foreach (var item in parts)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }

    class ConcreteBuilder_Daewoo_Lanos : Builder
    {
        Product product = new Product();
        //NameMechanism = "Daewoo Lanos";
        public override void BuildPartBody()
        {
            product.Add("Седан");
        }
        public override void BuildPartEngine()
        {
            product.Add("98");
        }
        public override void BuildPartWheels()
        {
            product.Add("13");
        }
        public override void BuildPartGearBox()
        {
            product.Add("5 Manual");
        }
        public override Product GetResult()
        {
            return product;
        }
    }

    class ConcreteBuilder_Ford_Probe : Builder
    {
        Product product = new Product();
        //NameMechanism = "Ford Probe";
        public override void BuildPartBody()
        {
            product.Add("Купе");
        }
        public override void BuildPartEngine()
        {
            product.Add("160");
        }
        public override void BuildPartWheels()
        {
            product.Add("14");
        }
        public override void BuildPartGearBox()
        {
            product.Add("4 Auto");
        }
        public override Product GetResult()
        {
            return product;
        }
    }

    class ConcreteBuilder_UAZ_Patriot : Builder
    {
        Product product = new Product();
        //NameMechanism = "UAZ Patriot";
        public override void BuildPartBody()
        {
            product.Add("Универсал");
        }
        public override void BuildPartEngine()
        {
            product.Add("120");
        }
        public override void BuildPartWheels()
        {
            product.Add("16");
        }
        public override void BuildPartGearBox()
        {
            product.Add("4 Manual");
        }
        public override Product GetResult()
        {
            return product;
        }
    }



 
    class ConcreteBuilder_Hyundai_Getz : Builder
    {
        Product product = new Product();
        //NameMechanism = "UAZ Patriot";
        public override void BuildPartBody()
        {
            product.Add("Хетчбэк");
        }
        public override void BuildPartEngine()
        {
            product.Add("66");
        }
        public override void BuildPartWheels()
        {
            product.Add("13");
        }
        public override void BuildPartGearBox()
        {
            product.Add("4 Auto");
        }
        public override Product GetResult()
        {
            return product;
        }
    }
}
