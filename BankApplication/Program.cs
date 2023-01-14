using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace BankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<<<<<<<<<<<<<<<Welcome to Kuber Bank>>>>>>>>>>>>>>>>>>>");

            MyThreading  o = new MyThreading ();

            Thread t = new Thread(new ThreadStart(o.process));
            
            t.Start();
            t.Join();
             



            int op = 6;
            int userid;
            char cha;
            CrudApplication userCRUD = new CrudApplication();
            do
            {
                Console.Clear();
                Console.WriteLine("Login...");


                User user = new User();
                Console.WriteLine("Enter UserName");
                user.UserName = Console.ReadLine();
                Console.WriteLine("Enter Password");
                user.Password = Console.ReadLine();
               

                int result = userCRUD.ValidateUser(user, out userid);
                if (result == 1)
                {
                    char adm;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("1. Add User");
                        Console.WriteLine("2. Show All User");
                        Console.WriteLine("3. Modify User");
                        Console.WriteLine("4. Delete User");
                        Console.WriteLine("5. Activate User");
                        Console.WriteLine("6. Deactive User");
                        Console.WriteLine("7. Show Active User");
                        Console.WriteLine("8. Show Deactive User");
                        Console.WriteLine("9. Exit");
                        Console.WriteLine("Enter your option");
                        op = Convert.ToInt32(Console.ReadLine());
                        switch (op)
                        {
                            case 1:
                                char a1;
                                do
                                {
                                    Console.Clear();
;                                    User a = new User();
                                    Console.WriteLine("Enter [userid,Username,Minbalance,password]");
                                    a.UserId = Convert.ToInt32(Console.ReadLine());
                                    
                                    a.UserName = Console.ReadLine();
                                    a.Role = Roles.Customer;
                                    a.MinBalance = Convert.ToDouble(Console.ReadLine());
                                    a.Password = Console.ReadLine();
                                    userCRUD.AddUser(a);
                                  
                                    Console.WriteLine("Operation Completed Successfully");

                                    Console.WriteLine("if you want to add another user then press y else press n");
                                    a1 = Convert.ToChar(Console.ReadLine());
                                } while (a1 == 'y' || a1 == 'Y');
                                break;
                            case 2:
                                List<User> alluser = new List<User>();
                                alluser = userCRUD.ShowAll();
                                foreach (var item in alluser)
                                {
                                    Console.WriteLine(item);
                                }
                                break;
                            case 3:
                                User b = new User();
                                Console.WriteLine("please enter the userid which you want to modify ");
                                b.UserId = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter new values [username,password,minBalance]");
                                b.UserName = Console.ReadLine();
                                b.Password = Console.ReadLine();
                                b.Role = Roles.Customer;
                                b.MinBalance = Convert.ToDouble(Console.ReadLine());

                                userCRUD.ModifyUser(b);
                                break;
                            case 4:
                                User c = new User();
                                Console.WriteLine(" Enter the userid which you want to Delete ");
                                c.UserId = Convert.ToInt32(Console.ReadLine());

                                userCRUD.DeletUser(c);
                                Console.WriteLine("account deleted successfully");
                                break;
                            case 5:
                                User d = new User();
                                Console.WriteLine("Enter the userid which you want to activate ");
                                d.UserId = Convert.ToInt32(Console.ReadLine());
                                userCRUD.ActivateUser(d);
                                Console.WriteLine("account activated successfully");
                                break;
                            case 6:
                                User e = new User();
                                Console.WriteLine("Enter the userid which you want to Deactive ");
                                e.UserId = Convert.ToInt32(Console.ReadLine());
                                userCRUD.DeactivateUser(e);
                                Console.WriteLine("account Deactivated successfully");
                                break;
                            case 7:
                                userCRUD.ShowActiveUser();

                                break;
                            case 8:
                                userCRUD.ShowDeActiveUser();

                                break;
                            case 9:
                                break;
                            default:
                                Console.WriteLine("Wrong");
                                break;
                        }
                        Console.WriteLine("If you want to go for Admin Menu Again then press y else n");
                        adm = Convert.ToChar(Console.ReadLine());
                    } while (adm == 'y' || adm == 'Y');
                }



                else if (result == 0)
                {
                    char ch1;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("1. Deposit Balance");
                        Console.WriteLine("2. Check Balance");
                        Console.WriteLine("3. Add Payee");
                        Console.WriteLine("4. Show All Payee");
                        Console.WriteLine("5. Remove Payee");
                        Console.WriteLine("6. Transfer Amount to payee");
                        Console.WriteLine("7. Exit");
                        Console.WriteLine("Enter your option");
                        op = Convert.ToInt32(Console.ReadLine());
                        CrudApplication c1 = new CrudApplication();
                        switch (op)
                        {
                            case 1:
                                char ch;
                                do
                                {

                                    User f = new User();
                                    Console.WriteLine("Enter the amount  ");
                                    f.UserId = userid;
                                    f.Balance = Convert.ToDouble(Console.ReadLine());

                                    userCRUD.DepositBalance(f);

                                    Console.WriteLine("Do you want to deposit money again.?");
                                    ch = Convert.ToChar(Console.ReadLine());
                                } while (ch == 'y' || ch == 'Y');
                                break;
                            case 2:

                                User g
                                   = new User();
                                //Console.WriteLine("enter the id of user");
                                g.UserId = userid;
                                double value = userCRUD.CheckBalance(g);
                                Console.WriteLine("available balance is: " + value);

                                break;
                            case 3:
                                char chp;
                                do
                                {
                                    Payee p1 = new Payee();
                                    // Console.WriteLine("Enter User Id:");
                                    p1.UserId = userid;
                                    Console.WriteLine("Enter Payee [id , Name]");

                                    p1.PayeeId = Convert.ToInt32(Console.ReadLine());
                                    p1.PayeeName = Console.ReadLine();

                                    userCRUD.AddPayee(p1);
                                    Console.WriteLine(" Do you want to Add another payee? then press y else press n");
                                    chp = Convert.ToChar(Console.ReadLine());
                                } while (chp == 'y' || chp == 'Y');

                                break;
                            case 4:
                                userCRUD.ShowPayeeList();
                                break;
                            case 5:
                                Payee p2 = new Payee();
                                Console.WriteLine("Enter the payeeId which you want to delet");
                                p2.PayeeId = Convert.ToInt32(Console.ReadLine());
                                userCRUD.DeletPayee(p2);
                                break;
                            case 6:
                                try
                                {
                                    User h = new User();
                                    Console.WriteLine("Please enter  amount");
                                    h.UserId = userid;
                                    h.Balance = Convert.ToDouble(Console.ReadLine());
                                    Payee p3 = new Payee();
                                    Console.WriteLine("Please enter Payee id");
                                    p3.PayeeId = Convert.ToInt32(Console.ReadLine());
                                    userCRUD.TransferMoney(p3, h);
                                }
                                catch (Exception x)
                                {
                                    
                                    Console.WriteLine(x.Message);
                                }
                                break;
                            case 7:
                                break;
                            default:
                                Console.WriteLine("Wrong");
                                break;
                        }
                        Console.WriteLine("If you want to go for user menu menu again press y else n");
                        ch1 = Convert.ToChar(Console.ReadLine());
                    } while (ch1 == 'y' || ch1 == 'Y');

                }
                else if (result == 2)
                {
                    op = 6;
                    Console.WriteLine("User name or password is wrong");
                }
                Console.WriteLine("if you want go for Login again press y else press n");
                cha = Convert.ToChar(Console.ReadLine());
            }
            while (cha == 'y' || cha == 'Y');
        }

    }
}
