using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleConApp;

namespace SampleFrameWork.Practical
{
    class BillFinal
    {
        public BillFinal()
        {
            BillNo += 1;
        }
        public int BillNo { get; set; } = 0;
      

        public int BillHolder { get; set; }

        public List<int> BillAmt { get; set; } 

       

      
    }

    class Item : BillFinal {

        SortedList<string, int> Particulars = new SortedList<string, int>();
        public int Id { get; set; }
        public int Unitprice { get; set; }
        public int Quantity { get; set; } = 1;

       public void SetParticular() {
            Particulars.Add("Rice", 1);
            Particulars.Add("Sugar", 2);
            Particulars.Add("Oil", 3);
            Particulars.Add("Salt", 4);
            Particulars.Add("Fish", 5);
        }
    public void Display()
        {
            foreach (var item in Particulars)
            {
                Console.WriteLine(item.Key+"-"+item.Value);
            }

        }
        SortedList<string, int> TotalSelected = new SortedList<string, int>();

         List<int> BillAmt = new List<int>();
        public void SetPrice(int id,int ItemQuantity)
        {
           
            foreach (var item in Particulars)
            {  
                if (item.Value == id)
                {
                    TotalSelected.Add(item.Key,ItemQuantity);
                    switch (id)
                    {
                        case 1:
                            BillAmt.Add(20 * ItemQuantity);
                            break;
                        case 2:
                            BillAmt.Add(40 * ItemQuantity);
                            break;
                        case 3:
                            BillAmt.Add(60 * ItemQuantity);
                            break;
                        case 4:
                            BillAmt.Add(80 * ItemQuantity);
                            break;
                        case 5:
                            BillAmt.Add(100 * ItemQuantity);
                            break;
                        default:
                            Console.WriteLine("Not a Valid Option");
                            break;
                    }

                    //foreach (var Amt in BillAmt)
                    //{   

                    //    Console.WriteLine(Amt);
                    //}
                    


                }

            }


        }
        public void TotalBill()
        {
            DateTime BillDate = DateTime.Now;
            Console.WriteLine("Bil NO :" + BillNo + "   BillDATE :" + BillDate);
            Console.WriteLine("------------------------------------------------------");
            foreach (var item in TotalSelected)
            {
                Console.WriteLine($"Item :{item.Key}     Quantity:{item.Value}" );
            }

           
            Console.WriteLine("Total Bill :" + BillAmt.Sum());
            Console.WriteLine("------------------------------------------------------");

        }


        public void SelectedItems()
        {
            Console.WriteLine("Selected Items");
            foreach (var item in TotalSelected)
            {

                Console.WriteLine(item.Key + "-" + item.Value);
            }
        }


    }

    class Bill
{
        static void Main(string[] args)
        {
            Item SelectedItem = new Item();
            BillFinal bill = new BillFinal();
        SHOP:
            string CustName = utilities.Prompt("Name Please");
            Console.WriteLine("This is our Menu");
            SelectedItem.SetParticular();



        RETRY:
            SelectedItem.Display();
            int ItemId = utilities.GetNumber("ENter Id");
            int ItemQuantity = utilities.GetNumber("Enter Quantity");
            //SelectedItem.id = ItemId;
            //SelectedItem.Quantity = ItemQuantity;
            SelectedItem.SetPrice(ItemId,ItemQuantity);
            int choice = utilities.GetNumber("ENter 1 to continue or any other key to Exit");
            if(choice==1)
            {
                goto RETRY;
            }
            //SelectedItem.SelectedItems();

            SelectedItem.TotalBill();
            int retry = utilities.GetNumber("Enter 1 to Shop Again");
            if (retry == 1)
            {
                goto SHOP;
            }


        }
    }

}
