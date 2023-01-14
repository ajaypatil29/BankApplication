using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
   
    
        public class CrudApplication
        {

            public List<User> userList = new List<User>();
            public List<Payee> payeeList = new List<Payee>();
            public static int count;

            public List<User> ShowAll()
            {
                return userList;
            }
            public List<User> ShowCustomers()
            {
                List<User> list = new List<User>();
                foreach (User item in userList)
                {
                    if (item.Role == Roles.Customer)
                    {
                        userList.Add(item);
                    }
                }
                return list;
            }
            public List<User> ShowActiveUsers()
            {
                List<User> list = new List<User>();
                foreach (User item in userList)
                {
                    if (item.IsActive == true)
                    {
                        list.Add(item);
                    }
                }
                return list;
            }
            public List<User> ShowDeactivedUsers()
            {
                List<User> list = new List<User>();
                foreach (User item in userList)
                {
                    if (item.IsActive == false)
                    {
                        list.Add(item);
                    }
                }
                return list;
            }


            public void AddUser(User user)
            {
                user.Role = Roles.Customer;
                user.IsActive = true;
                user.UserId = user.UserId;
                userList.Add(user);
                count++;
            }
            public void DeactivateUser(User user)
            {
                foreach (var item in userList)
                {
                    if (item.UserId == user.UserId)
                    {
                        item.IsActive = false;
                        break;
                    }
                }
            }
            public void ActivateUser(User user)
            {
                foreach (var item in userList)
                {
                    if (item.UserId == user.UserId)
                    {
                        item.IsActive = true;
                        break;
                    }
                }
            }
            public CrudApplication()
            {

                userList.Add(new User { UserName = "Admin", UserId = 1, Password = "1234", Role = Roles.Admin,IsActive =true  });
            }
            public int ValidateUser(User user, out int userid)
            {
                userid = 0;
                foreach (User u in userList)
                {
                    if (u.UserName == user.UserName && user.Password == u.Password)
                    {
                        if (u.Role == Roles.Admin)
                        {
                            userid = u.UserId;
                            return 1;

                        }
                        else
                        {
                            userid = u.UserId;
                        
                             return 0;
                        }
                    }

                }
                return 2;
            }
            User u = new User();
            public double CheckBalance(User u2)
            {
                double b = 0;

                foreach (User u in userList)
                {
                    if (u.UserId == u2.UserId)
                    {
                        b = u.Balance + u.MinBalance;
                    }
                }
                return b;

            }
            public void DepositBalance(User u4)
            {

                foreach (User u in userList)
                {
                    if (u.UserId == u4.UserId)
                    {
                        u.Balance = u.Balance + u4.Balance;


                    }
                }
            }
            public void ModifyUser(User v)
            {
                
                foreach (User a in userList)
                {
                    if (a.UserId == v.UserId)
                    {
                        a.UserName = v.UserName;
                        a.Password = v.Password;
                        a.Role = v.Role;
                        a.MinBalance = v.MinBalance;
                    }
                }

            }
            public void DeletUser(User v)
            {
                //List<User> apdateList = new List<User>();
                foreach (User u in userList)
                {
                    if (u.UserId == v.UserId)
                    {
                        userList.Remove(u);
                        break;
                    }
                }

            }
            public void ShowActiveUser()
            {
                foreach (var item in userList)
                {
                    if (item.IsActive == true)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            public void ShowDeActiveUser()
            {
                foreach (var item in userList)
                {
                    if (item.IsActive == false)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            public void AddPayee(Payee p)
            {
                foreach (User item in userList)
                {
                    if (item.UserId == p.UserId)
                    {
                        if (item.IsActive == true)
                        {
                            payeeList.Add(p);
                        }
                        else
                        {
                            Console.WriteLine("Sorry your Account is not Active");
                        }
                    }

                }

            }
            public void ShowPayeeList()
            {
                foreach (Payee p in payeeList)
                {
                    Console.WriteLine(p);
                }
            }
            public void TransferMoney(Payee p, User u)
            {
                foreach (User ur in userList)
                {
                    if (ur.UserId == u.UserId)
                    {
                        if (ur.Balance < u.Balance)
                        {
                        throw new MyException.MinimunBalanceException("You Have inSufficient balance");
                        }
                        else
                        {
                            foreach (Payee item in payeeList)
                            {
                                if (item.PayeeId == p.PayeeId)
                                {
                                    item.PayeeBalance = item.PayeeBalance + u.Balance;
                                }

                            }
                            foreach (User item in userList)
                            {
                                if (item.UserId == u.UserId)
                                {
                                    item.Balance = item.Balance - u.Balance;
                                }

                            }

                        }
                    }

                }

            }
            public void DeletPayee(Payee p1)
            {

                foreach (Payee p in payeeList)
                {
                    if (p.PayeeId == p1.PayeeId)
                    {
                        payeeList.Remove(p);
                        break;
                    }
                }

            }
        }
    }

