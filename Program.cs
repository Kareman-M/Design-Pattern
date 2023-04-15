namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {

            #region SingleResponsibility Princile
            /// Summary
            /// That Principle Specifies that any Particular Class Should have just a single reason to change
            ///

            //var j = new Journal();
            //j.AddEntry("I ate a Bug");
            //j.AddEntry("I studied Design Patters");
            //Console.WriteLine(j);

            //// applay single responsibilty
            //var p = new Persistence();
            //var filename = @"E:\KM\DP\journal.txt";
            //p.SaveToFile(j, filename, false);
            //Process.Start(filename);
            #endregion


            #region OpenClosed Principle
            /// Summary
            /// Every class should be Open for extend, Closed for modification
            ///


            //var apple = new Product("Apple", Color.Green, Size.Small);
            //var tree = new Product("Tree", Color.Green, Size.Large);
            //var house = new Product("House", Color.Blue, Size.Large);

            //Product[] products = { apple, tree, house };

            //#region old way
            //var pf = new ProductFilter();
            //Console.WriteLine("Green Products (old):");
            //foreach (var item in pf.FilterByColor(products, Color.Green))
            //{
            //    Console.WriteLine($"- {item.Name} is green");
            //}
            //#endregion

            //#region new way
            //var bf = new BetterFilter();
            //Console.WriteLine("Green Products (new):");
            //foreach (var b in bf.Filter(products, new ColorSpecification(Color.Green)))
            //{
            //    Console.WriteLine($"- {b.Name} is green");
            //};

            //Console.WriteLine("Large blue Items (new):");
            //foreach (var b in bf.Filter(products, new AndSpecification<Product>(new ColorSpecification(Color.Blue), new SizeSpecification(Size.Large))))
            //{
            //    Console.WriteLine($"- {b.Name} is green");
            //};
            //#endregion

            #endregion


            #region Liskov Substitution Principle
            /// Summary
            /// The idea is that you should be able to Substitute a base type for a subtype
            ///

            Rectangle rc = new Rectangle(2, 3);
            Console.WriteLine($"{rc} has area {rc.Area()}");

            Rectangle sq = new Square();
            sq.Width = 4;
            Console.WriteLine($"{sq} has area {sq.Area()}");

            #endregion


            #region Interface Segregation Principle
            /// Summary
            /// Your Interfaces should be segregated so that nobody who implements your interface has to implement which they don't actually need
            ///

            #endregion

            #region Dependency Inversion Principle
            /// Summary
            /// the high level parts of the system should not depend on low level parts of the system directly, that instead 
            /// they should depend on some kind of abstraction
            ///

            var parent = new Person { Namel = "John" };
            var child1 = new Person { Namel = "Chris" };
            var child2 = new Person { Namel = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            #endregion
        }

    }


    #region SingleResponsibility Princile

    //public class Journal
    //{
    //    private readonly List<string> entries = new List<string>();
    //    private static int count = 0;
    //    public int AddEntry(string text)
    //    {
    //        entries.Add($"{++count}: {text}");
    //        return count;
    //    }
    //    public void RemoveEntry(int index)
    //    {
    //        entries.RemoveAt(index);
    //    }
    //    public void Save(string filename) // altered by the persistence class (SaveToFile Method)
    //    {
    //        File.WriteAllText(filename, ToString());
    //    }
    //    public override string ToString()
    //    {
    //        return string.Join(Environment.NewLine, entries);
    //    }
    //}

    //public class Persistence
    //{
    //    public void SaveToFile(Journal j, string filename, bool overwrite = false)
    //    {
    //        if (overwrite || !File.Exists(filename)) File.WriteAllText(filename, j.ToString());
    //    }
    //}

    #endregion

    #region OpenClosed Principle
    //public enum Color { Red, Green, Blue }
    //public enum Size { Small, Medium, Large, Yuge }
    //public class Product
    //{
    //    public string Name;
    //    public Color Color;
    //    public Size Size;
    //    public Product(string name, Color color, Size size)
    //    {
    //        if (name == null) throw new ArgumentNullException("name");
    //        Name = name;
    //        Color = color;
    //        Size = size;
    //    }
    //}

    //#region old way
    //public class ProductFilter
    //{
    //    public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
    //    {
    //        foreach (Product product in products)
    //        {
    //            if (product.Size == size)
    //                yield return product;
    //        }
    //    }
    //    public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
    //    {
    //        foreach (Product product in products)
    //        {
    //            if (product.Color == color)
    //                yield return product;
    //        }
    //    }
    //    public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
    //    {
    //        foreach (Product product in products)
    //        {
    //            if (product.Color == color && product.Size == size)
    //                yield return product;
    //        }
    //    }
    //}
    //#endregion

    //#region new way
    //public interface ISpecification<T>
    //{
    //    bool IsSatisified(T t);
    //}
    //public interface IFilter<T>
    //{
    //    IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    //}

    //public class AndSpecification<T> : ISpecification<T>
    //{
    //    private ISpecification<T> first, second;

    //    public AndSpecification(ISpecification<T> first, ISpecification<T> second)
    //    {
    //        this.first = first;
    //        this.second = second;
    //    }

    //    public bool IsSatisified(T t)
    //    {
    //        return first.IsSatisified(t) && second.IsSatisified(t);
    //    }
    //}
    //public class ColorSpecification : ISpecification<Product>
    //{
    //    private Color Color;
    //    public ColorSpecification(Color color)
    //    {
    //        Color = color;
    //    }

    //    public bool IsSatisified(Product t)
    //    {
    //        return t.Color == Color;
    //    }
    //}
    //public class SizeSpecification : ISpecification<Product>
    //{
    //    private Size Size;
    //    public SizeSpecification(Size size)
    //    {
    //        Size = size;
    //    }

    //    public bool IsSatisified(Product t)
    //    {
    //        return t.Size == Size;
    //    }
    //}

    //public class BetterFilter : IFilter<Product>
    //{
    //    public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
    //    {
    //        foreach (var item in items)
    //        {
    //            if (spec.IsSatisified(item)) yield return item;
    //        }
    //    }
    //}
    //#endregion

    #endregion

    #region Liskov Substitution Principle
    public class Rectangle
    {
        // use virtual to can override and not violate the liskov principle (To Violate The Principle remove virtual keyword and run the code again)
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public int Area() => Width * Height;
        public Rectangle()
        {

        }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }

    }

    public class Square : Rectangle
    {
        //using override instead of new to not violate the liskov principle (To Violate The Principle replace override with new keyword and run the code again)
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }
        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }
    #endregion

    #region Interface Segregation Principle
    public class Document { }

    #region the volating of this principle
    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document document)
        {
            // Fax Document
        }

        public void Print(Document document)
        {
            //  Print Document
        }

        public void Scan(Document document)
        {
            // Scan Document
        }
    }

    public class OldFashionPrinter : IMachine
    {
        public void Fax(Document document)
        {
            // Not having a Fax 
        }

        public void Print(Document document)
        {
            //  Print Document
        }

        public void Scan(Document document)
        {
            // Not having a Scan 
        }
    }

    public interface IMachine
    {
        void Print(Document document);
        void Scan(Document document);
        void Fax(Document document);
    }

    #endregion

    public interface IPrinter
    {
        void Print(Document document);
    }
    public interface IScanner
    {
        void Scan(Document document);
    }
    public interface IFax
    {
        void Fax(Document document);
    }
    public class PhotoCopier : IPrinter, IScanner
    {
        public void Print(Document document)
        {
            // Print
        }

        public void Scan(Document document)
        {
            // Scan
        }
    }

    #endregion

    #region Dependency Inversion Principle
    public enum Relationship { Parent, Child, Sibling }

    public class Person
    {
        public string Namel;
    }
    // low-level parts of the system
    public class Relationships
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }
    }

    #endregion

}