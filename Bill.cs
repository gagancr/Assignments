using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace SampleFrameworks
{
    class Bill
    {
        public int BillNo { get; set; } = Math.Abs(DateTime.Now.GetHashCode());
       public string date { get; set; } = DateTime.Now.ToShortDateString();
        public string BillHolder { get; set; }
        public int BillAmount { get; set; }


    }

    class Item
    {
        public  int id ;
        public string Particulars;
        public int UnitPrice;
        
            
      static public Item[] ar = new Item[8];
        


    }
    class MiddleClass
    {
        static void BillSetter()
        {
            Item.ar[0] = new Item { Particulars = "sugar", UnitPrice = 40 };
            Item.ar[1] = new Item { Particulars = "salt", UnitPrice = 20 };
            Item.ar[2] = new Item { Particulars = "dal", UnitPrice = 70 };
            Item.ar[3] = new Item { Particulars = "soap", UnitPrice = 10 };
            Item.ar[4] = new Item { Particulars = "shampoo", UnitPrice = 5 };
            Item.ar[5] = new Item { Particulars = "brush", UnitPrice = 45 };
            Item.ar[6] = new Item { Particulars = "pen", UnitPrice = 15 };
            Item.ar[7] = new Item { Particulars = "book", UnitPrice = 35 };

            int id = 110;
            foreach (var item in Item.ar)
            {
                item.id = id++; 
            }

        }
        public void BillGenerator()
        {
            BillSetter();
            
            string name = Utilities.Prompt("Enter the name of the customer");
            Console.WriteLine();
            Console.WriteLine("enter the items from following ids");
            Bill Newbill = new Bill { BillHolder = name };
            foreach (var item in Item.ar)
            {
                Console.Write(" " + item.id+"("+item.Particulars+")");
            }
            Console.WriteLine();
            bool x = true;
            int bill = 0;
            ArrayList Listid = new ArrayList();
            ArrayList Listquantity = new ArrayList();
            do
            {

                bool enteredval = false;

            RETRYING:
                int enteredId = 0;
                try
                {

                    enteredId = Utilities.GetNumber("enter the id you want to add");
                }
                catch (Exception)
                {

                    Console.WriteLine("Enter valid id");
                    goto RETRYING;
                }
                foreach (var item in Item.ar)
                {
                    if (item.id == enteredId)
                    {
                        enteredval = true;
                    }
                    

                }
                if (enteredval == false)
                {
                    Console.WriteLine("Enter valid id ");
                    goto RETRYING;
                }
                Listid.Add(enteredId);
            int enteredQuantity = Utilities.GetNumber("enter the quantity");
              
           
            Listquantity.Add(enteredQuantity);
            
            bill += BillAdder(enteredId) * enteredQuantity;
                try
                {
            RETRY:
                int resp = Utilities.GetNumber("enter 0 to generate bill /nEnter 1 to continue with adding");
                if (resp == 1) x = true;
                else if (resp == 0) x = false;
                else {
                    Console.WriteLine("Invalid entry");
                    goto RETRY;
                        }

                }
                catch (Exception)
                {

                     Console.WriteLine("Invalid entry");
                }

            } while (x);
            Console.Clear();
            Newbill.BillAmount = bill;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Bill Number "+Newbill.BillNo);
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Name : "+Newbill.BillHolder +"                         "+"Date : "+ Newbill.date);
            Console.WriteLine("_____________________________________________________");


            Console.WriteLine("id\tName\tPrice\tQuantity   Total ");
            Console.WriteLine("----------------------------------------------------");
            int count = 0;


            foreach (int item in Listid)
            {
                Console.Write(item + "  ");

                Console.Write(NameOfParticular(item) + "\t");

                Console.Write(BillAdder(item) + "\t");

                Console.Write(Listquantity[count] + "\t");

                Console.Write(BillAdder(item) * (int)Listquantity[count]);
                Console.WriteLine();

                count++;
            }
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("Total Bill "+ Newbill.BillAmount);

        }

       
        public int BillAdder(int id )
        {
           
            for (int i = 0; i < Item.ar.Length; i++)
            {
                if (id == Item.ar[i].id)
                {
                    return Item.ar[i].UnitPrice;
                }
               
            }
            return 0;
        }
        public string NameOfParticular(int id)
        {
            for (int i = 0; i < Item.ar.Length; i++)
            {
                if (id == Item.ar[i].id)
                {
                    return Item.ar[i].Particulars;
                }

            }
            return null;
        }
    }

    class Setter
    {
        static void Main(string[] args)
        {
            MiddleClass m = new MiddleClass();
            m.BillGenerator();
        }

    }
}
