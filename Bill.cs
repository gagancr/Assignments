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
        
            
      static public Item[] ar = new Item[10];
        
       public static void BillSetter()
        {
            ar[0] = new Item { Particulars = "Sugar", UnitPrice = 40 };
            ar[1] = new Item { Particulars = "Salt", UnitPrice = 20 };
            ar[2] = new Item { Particulars = "Dal", UnitPrice = 70 };
            ar[3] = new Item { Particulars = "Soap", UnitPrice = 10 };
            ar[4] = new Item { Particulars = "Shampoo", UnitPrice = 5 };
            ar[5] = new Item { Particulars = "Brush", UnitPrice = 45 };
            ar[6] = new Item { Particulars = "Pen", UnitPrice = 15 };
            ar[7] = new Item { Particulars = "Book", UnitPrice = 35 };
            ar[8] = new Item { Particulars = "FaceWash", UnitPrice = 90 };
            ar[9] = new Item { Particulars = "Perfume", UnitPrice = 220 };

            int id = 110;
            foreach (var item in Item.ar)
            {
                item.id = id++; 
            }
        }
   }
    class MiddleClass
    {
        public void BillGenerator()
        {
            Item.BillSetter();
            
            string name = Utilities.Prompt("Enter the name of the Customer");
            Console.WriteLine();
            Console.WriteLine("Enter the items from following ids");
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

                    enteredId = Utilities.GetNumber("Enter the id of the item you want to add");

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
                Console.WriteLine("Unit price of "+ NameOfParticular(enteredId)+" " + BillAdder(enteredId));

                int enteredQuantity = Utilities.GetNumber("enter the quantity");
                if (Listid.Contains(enteredId))
                {
                    int index=  Listid.IndexOf(enteredId);
                    
                    int temp = (int)Listquantity[index]+enteredQuantity;
                    Listquantity.Insert(index, temp);
                    goto HERE;
                }
                Listid.Add(enteredId);
                Listquantity.Add(enteredQuantity);
            
           // bill += BillAdder(enteredId) * enteredQuantity;
            HERE:
                try
                {
            RETRY:
                int resp = Utilities.GetNumber("enter 0 to generate bill \nEnter 1 to continue with adding");
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


            Console.WriteLine("sl.no\tid  Particulars\tPrice\tQuantity   Total ");
            Console.WriteLine("----------------------------------------------------");
            int count = 0;

            int tempBill = 0;
             bill = 0;
            foreach (int item in Listid)
            {
                Console.Write(count+1+"\t");
                Console.Write(item + "  ");

                Console.Write(NameOfParticular(item) + "\t");

                Console.Write(BillAdder(item) + "\t");

                Console.Write(Listquantity[count] + "\t");
                tempBill =(BillAdder(item) * (int)Listquantity[count]);
                Newbill.BillAmount += tempBill;
                Console.Write("    "+tempBill);
                Console.WriteLine();

                count++;
            }
           
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("Total Bill Amout                             Rs: "+ Newbill.BillAmount);
            Console.WriteLine("_____________________________________________________");
            Console.WriteLine("                 Thank You !!!! \n                 Visit Us Again...");

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
