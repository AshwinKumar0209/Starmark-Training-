//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SampleConApp
//{
//    class Account {

//        private int No;

//        public int AccNo
//        {
//            get { return No; }
//            set { No = value; }
//        }

//        //private double Bal;

//        //public double AccBal
//        //{
//        //    get { return Bal = 2000; } 
//        //    set { Bal = value; }
//        //}

//        public double AccBal { get; private set; } = 2000;

//        private string Name;

//        public string AccName
//        {
//            get { return Name; }
//            set { Name = value; }
//        }
//        public void Credit(int amount) => AccBal += amount;
//        public void Debit(int amount)
//        {
//            if(amount >AccBal)
//            {
//                throw  new Exception("INSUFFICIENT FUND");
//            }
//            AccBal -= amount;
//        }

//    }

//    class AccountManager {
//        private Account[] _accounts = null;
//        private int _size = 0;
//        public AccountManager(int size)
//        {
//            _size = size;
//            _accounts = new Account[_size];
//        }

//        public void AddNewAccount(Account acc)
//        {
//            for (int i = 0; i < _size; i++)
//            {
//                if(_accounts[i]==null)
//                {
//                    _accounts[i] = new Account { AccName = acc.AccName, AccNo = acc.AccNo };
//                    _accounts[i].Credit((int)acc.AccBal);
//                    return;
//                }
//            }
//        }

//        public void UpdateAccountDetails(Account acc)
//        {
//            for(int i = 0; i < _size; i++)
//            {
//                if (_accounts[i] != null && _accounts[i].AccNo == acc.AccNo)
//                {
//                    _accounts[i].AccName = acc.AccName;
//                    return;
//                }
//            }throw new Exception("Account not FOUND");
//        }

//        public void DeleteAccount(int id)
//        {
//            for(int i = 0; i < _size; i++)
//            {
//                if(_accounts[i]!= null && _accounts[i].AccNo == id)
//                {
//                    _accounts[i] = null;
//                    return;
//                }
//            }throw new Exception("No Account found to delete");
//        }

//        public Account FindAccount(int id)
//        {
//            foreach(Account acc in _accounts)
//            {
//                if(acc!=null && acc.AccNo == id)
//                {
//                    return acc;
//                }
//            }
//            throw new Exception("No Account Found");
//        }

//    }


        

//    class Employee1 // TO explain getter and setters 
//    {
//        private int id;

//        public int EmpId
//        {
//            get { return id; }
//            set { id = value; }
//        }
//        private String Name;

//        public String EmpName
//        {
//            get { return Name; }
//            set { Name = value; }
//        }

//        private String Address;
                                                    
//        public String EmpAddress            
//        {
//            get { return Address; }
//            set { Address = value; }
//        }


//    }

//    class ObjectsBasics
//    {
//        static void Main(string[] args)
//        {

//            Employee1 obj = new Employee1 { EmpId = 3306, EmpAddress = "Bangalore", EmpName = "Ashwin" };
//            Console.WriteLine("The Employee Name is "+obj.EmpName+" With ID No: "+obj.EmpId+" From "+obj.EmpAddress);
//            Account obj1 = new Account { AccName = "Ashwin", AccNo = 3306 };
//            obj1.Debit(1000);
//            Console.WriteLine($"Account balance after debiting  {obj1.AccBal}");
//            obj1.Credit(5000);
//            Console.WriteLine($"Account balance after crediting {obj1.AccBal}");

//            //int count = utilities.GetAlldata("Enter the account count:");
//            //AccountManager mgr = new AccountManager(count);
//            try
//            {
//               /* mgr.FindAccount(123)*/;
//            }
//            catch (Exception ex)
//            {

//                Console.WriteLine(ex.Message);
//            }
//        }
//    }
//}
