using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Chapter23
{
    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //List<User> users = new List<User>(); 
            //XmlDocument document = new XmlDocument(); //создаем обьект XmlDocument
            //document.Load("D:\\New\\users.xml");        //подгружаем в него документ
            //XmlElement root = document.DocumentElement;  // c помощью свойства DocumentElement определяем корневой элемент
            //foreach (XmlElement e in root)                //перебираем узлы
            //{
            //    User user = new User();
            //    XmlNode attr = e.Attributes.GetNamedItem("name"); //присваиваем узлу элемент с атрибутом name
            //    if (attr != null)
            //    {
            //        user.Name = attr.Value;                       

            //    }
            //        foreach(XmlNode childnode in e.ChildNodes)       //идем по дочерним узлам корневого узла
            //        {
            //            if (childnode.Name == "company")
            //            {
            //                user.Company = childnode.InnerText;
            //            }
            //            if (childnode.Name == "age")
            //            {
            //                user.Age = Int32.Parse(childnode.InnerText);
            //            }
            //        }
            //        users.Add(user);
            //    }
            //    foreach (User u in users)
            //        Console.WriteLine($"{u.Name} ({u.Company}) - {u.Age}");
            //    Console.Read();

            ////добавление нового єлемента в документ

            ////создаем єлемент xmlDocument и загружаем в него документ
            //XmlDocument xmlDocument = new XmlDocument();
            //xmlDocument.Load("D:\\New\\users.xml");
            ////определяем корневой элемент
            //XmlElement xroot = xmlDocument.DocumentElement;
            ////создаем новый элемент user
            //XmlElement Xuser = xmlDocument.CreateElement("user");
            ////создаем у него новый атрибут name
            //XmlAttribute name = xmlDocument.CreateAttribute("name");
            ////создаем внутри него элемент company
            //XmlElement company = xmlDocument.CreateElement("company");
            ////создаме внутри него элемент age
            //XmlElement age = xmlDocument.CreateElement("age");
            ////создаем текстовые значения для атрибута и элементов
            //XmlText nameText = xmlDocument.CreateTextNode("Mark Zuckerberg");
            //XmlText companyText = xmlDocument.CreateTextNode("Facebook");
            //XmlText ageText = xmlDocument.CreateTextNode("32");
            //// добавляем узлы
            //name.AppendChild(nameText);
            //company.AppendChild(companyText);
            //age.AppendChild(ageText);
            //Xuser.Attributes.Append(name);
            //Xuser.AppendChild(company);
            //Xuser.AppendChild(age);
            //xroot.AppendChild(Xuser);
            //// сохраняем документ
            //xmlDocument.Save("D:\\New\\users.xml");

            //// удаление узла из документа

            //XmlDocument xDoc = new XmlDocument();
            //xDoc.Load("D:\\New\\users.xml");
            //XmlElement xRoot = xDoc.DocumentElement;

            //XmlNode firstNode = xRoot.FirstChild;
            //xRoot.RemoveChild(firstNode);
            //xDoc.Save("D:\\New\\users.xml");

            XmlDocument xdoc = new XmlDocument();
            xdoc.Load("D:\\New\\users.xml");
            XmlElement xmlroot = xdoc.DocumentElement;
            // выбор всех дочерних узлов
            XmlNodeList childlist = xmlroot.SelectNodes("*");
            foreach (XmlNode n in childlist)
                Console.WriteLine(n.OuterXml);

            //Выберем все узлы <user>:
            XmlNodeList childnodes = xmlroot.SelectNodes("user");
            //Выведем на консоль значения атрибутов name у элементов user:
            foreach (XmlNode n in childnodes)
            {
                Console.WriteLine(n.SelectSingleNode("@name").Value);
            }
            //Выберем узел, у которого атрибут name имеет значение "Bill Gates":
            XmlNode chilnode = xmlroot.SelectSingleNode("user[@name='Bill Gates']");
            if (chilnode != null)
                Console.WriteLine(chilnode.OuterXml);
            //Выберем узел, у которого вложенный элемент "company" имеет значение "Microsoft":
            XmlNode childnod = xmlroot.SelectSingleNode("user[company='Microsoft']");
            if (childnod != null)
                Console.WriteLine(childnod.OuterXml);

            //получить только компании
            XmlNodeList nodeList = xmlroot.SelectNodes("//user/company");
            foreach (XmlNode n in childnodes)
                Console.WriteLine(n.InnerText);



            //создание нового XmL документа

            XDocument xmldoc = new XDocument();

            XElement iphone = new XElement("phone");
            // создаем атрибут
            XAttribute iphoneName = new XAttribute("name", "iPhone 11");
            XElement iphoneCompany = new XElement("company", "Apple");
            XElement iphonePrice = new XElement("price", "20000");
            // добавляем атрибут и элементы в первый элемент
            iphone.Add(iphoneName);
            iphone.Add(iphoneCompany);
            iphone.Add(iphonePrice);
            XElement samsung = new XElement("phone");
            XAttribute samsungName = new XAttribute("name", "Samsung Galaxy S12");
            XElement samsungCompany = new XElement("company", "Samsung");
            XElement samsungPrice = new XElement("price", "25000");
            samsung.Add(samsungName);
            samsung.Add(samsungCompany);
            samsung.Add(samsungPrice);

            // создаем корневой элемент
            XElement phones = new XElement("phones");
            // добавляем в корневой элемент
            phones.Add(iphone);
            phones.Add(samsung);
            // добавляем корневой элемент в документ
            xmldoc.Add(phones);
            xmldoc.Save("D:\\New\\phones.xml");

            //второй способ выполнения данного задания
            //        XDocument xdoc = new XDocument(new XElement("phones",
            //new XElement("phone",
            //    new XAttribute("name", "iPhone 6"),
            //    new XElement("company", "Apple"),
            //    new XElement("price", "40000")),
            //new XElement("phone",
            //    new XAttribute("name", "Samsung Galaxy S5"),
            //    new XElement("company", "Samsung"),
            //    new XElement("price", "33000"))));
            //        xdoc.Save("phones.xml");


            XDocument xDocument = XDocument.Load("D:\\New\\phones.xml");
            var items = from xe in xDocument.Element("phones").Elements("phone")
                        where xe.Element("company").Value == "Samsung"
                        select new Phone
                        {
                            Name = xe.Attribute("name").Value,
                            Price = xe.Element("price").Value
                        };
            foreach (var item in items)
                Console.WriteLine($"{item.Name} - {item.Price}");


            XDocument xDocument1 = XDocument.Load("D:\\New\\phones.xml");
            XElement root = xDocument1.Root;

            foreach(XElement xe in root.Elements("phone").ToList()){
                if (xe.Attribute("name").Value == "Samsung Galaxy S11")
                {
                    xe.Element("price").Value = "32000";
                }
                if(xe.Attribute("name").Value=="iPhone 11")
                {
                    xe.Remove();
                }
            }
            root.Add(new XElement("phone", 
                new XAttribute("name", "Iphone 12"), 
                new XElement("company", "Apple"), 
                new XElement("price", "30000")));
            xDocument1.Save("D:\\New\\phones.xml");

            // выводим xml-документ на консоль
            Console.WriteLine(xDocument1);


            Person p1 = new Person("Tom", 29,new Company( "Apple"));
            Person p2 = new Person("Bill", 32, new Company("Microsoft"));

            Person[] people = new Person[] { p1, p2 };
            XmlSerializer formatter = new XmlSerializer(typeof(Person[]));
            using (FileStream fs = new FileStream("D:\\New\\people.xml",FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);
            }

            using (FileStream fs = new FileStream("D:\\New\\people.xml", FileMode.OpenOrCreate))
            {
                Person[] newpeople = (Person[])formatter.Deserialize(fs);
                foreach (Person p in newpeople)
                {
                    Console.WriteLine($"Имя: {p.Name} --- Возраст: {p.Age} --- Компания: {p.Company.Name}");
                }
            }
            Console.ReadLine();
        }
        }
        public class Phone
        {
            public string Name { get; set; }
            public string Price { get; set; }
        }
    [Serializable]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Company Company { get; set; }
        public Person()
        { }

        public Person(string name, int age, Company comp)
        {
            Name = name;
            Age = age;
            Company = comp;
        }
    }
    [Serializable]
    public class Company
    {
        public string Name { get; set; }

        // стандартный конструктор без параметров
        public Company() { }

        public Company(string name)
        {
            Name = name;
        }
    }
}

