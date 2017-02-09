using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    public interface IShape
    {
        void Draw();
        
    }
    public interface IColor
    {
        void Fill();
    }

    public class Rectangle : IShape
    {
        void IShape.Draw()
        {
            Console.WriteLine("This is Rectangle Shape");
        }
    }
    public class Circle : IShape
    {
        void IShape.Draw()
        {
            Console.WriteLine("This is circle Shape");
        }
    }
    public class Square : IShape
    {
        void IShape.Draw()
        {
            Console.WriteLine("This is Square Shape");
        }
    }
    public class Red : IColor
    {
        public void Fill()
        {
            Console.WriteLine("This is Red Color");
        }
    }
    public class Yellow : IColor
    {
        public void Fill()
        {
            Console.WriteLine("This is Yellow Color");
        }
    }
    public class Blue : IColor
    {
        public void Fill()
        {
            Console.WriteLine("This is Blue Color");
        }
    }
    public class ShapeFactory : AbstractFactory
    {
        public override IShape getShape(string shape)
        {if(shape=="rectiangle")
            return new Rectangle();
            if (shape == "square")
                return new Square();
            if (shape == "circle")
                return new Circle();
            return null;
        }
        public override IColor getColor(string color) { return null; }

    }
    public class ColorFactory:AbstractFactory
    {
        public override IShape getShape(string shape) { return null; }
        public override IColor getColor(string color)
        {
            if(color=="yellow")
            return new Yellow();
            if (color == "red")
                return new Red();
            if (color == "blue")
                return new Blue();
            return null;
        }
    }
    public abstract class AbstractFactory 
    {
       public abstract IShape getShape(string shape);
      public  abstract IColor getColor(string color);
    }
    public class FactoryProvider
    {
       
        public AbstractFactory getChoose(string choose)
        {
            if(choose==null)
            {
                return null;
            }
            if(choose=="shape")
            {
                return new ShapeFactory();
            }
            if (choose == "color")
            {
                return new ColorFactory();
            }
            return null;
        }
    }
    
    public class Demo
    {
        
        static void Main()
        {
            Demo demo_obj = new Demo();
            Console.WriteLine("Enter Selection");
            string selection = Console.ReadLine();
            

            Console.WriteLine("Enter Which "+selection);
            string s = Console.ReadLine();

            FactoryProvider FacrPro_obj = new FactoryProvider();
          AbstractFactory selected_choice=  FacrPro_obj.getChoose(selection);

            if (selection == "color")
            {
                IColor color_obj = selected_choice.getColor(s);
                color_obj.Fill();
            }
            else
            {

                IShape Shape_obj = selected_choice.getShape(s);
                Shape_obj.Draw();
            }
            

        }

    }
}
