using DB_1;
using DB_1.Entityes;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Sql;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace test_server
{
   public  class Program
    {
        static DBHelper helper = new DBHelper();
        static void Main(string[] args)
        {
            Console.Title = "SERVER";
            const int port = 2020;
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), port);

            server.Start();
            //while (true)
            //{
            //    Console.WriteLine("Wait...");
            //    var client = server.AcceptTcpClient();
            //    Console.WriteLine("Connect.");
            //    client.Close();
            //}
            Start_Server(server);
        }

        public static void Start_Server(TcpListener server)
        {
            Console.WriteLine("...[ Server wait for connection ]...");
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();

                Console.WriteLine("...[ Connected ]...");
                NetworkStream stream = client.GetStream();
                try
                {
                    if (stream.CanRead)
                    {
                        byte[] buffer = new byte[1024];
                        string msg = "";
                        int count = 0;
                        do
                        {
                            count = stream.Read(buffer, 0, buffer.Length);
                            msg = Encoding.UTF8.GetString(buffer, 0, count);

                        } while (stream.DataAvailable);

                        switch (msg)
                        {
                            case "Emp":
                                GetEmployee(client);
                                break;
                            case "Adr":
                                GetAddress(client);
                                break;
                            case "Dep":
                                GetDepartment(client);
                                break;
                            case "Rep":
                                GetRetort(client);
                                break;
                            case "AddEmp":
                                AddEmployee(client);
                                break;
                            case "UpdEmp":
                                UpdateEmployee(client);
                                break;
                            case "DelEmp":
                                DeleteEmployee(client);
                                break;
                            default:
                                break;
                        }
                    }
                }
                finally
                {
                    client.Close();
                    stream.Close();
                }
            }
        }
        public void Add_Address(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AddressDTO));
                var contact = (AddressDTO)serializer.Deserialize(stream);

               // bob.AddAddress(new Address { City = contact.City, Street = contact.Street, Apartment = contact.Apartment, House = contact.House });
                Console.WriteLine("OK");
            }
        }

        #region Employee
        public static void GetEmployee(TcpClient client)
        {

            var employees = helper.GetEmployees().Select(x => new EmployeeDTO
            {
                ID = x.Id,
                Name = x.Name,
                Surname = x.Surname,
                Photo = x.Photo,
                Phone = x.Phone,
                DateOfBirths = x.DateOfBirths,
                Email = x.Email,
                Details = x.Details,
                DepartmentID = x.DepartmentId,
                AddressID = x.AddressId,               
                
            }
            ).ToList();

            using (NetworkStream stream1 = client.GetStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(employees.GetType());
                xmlSerializer.Serialize(stream1, employees);
            }
        }

        public static void AddEmployee(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(EmployeeDTO));
                var emp = (EmployeeDTO)serializer.Deserialize(stream);

                helper.AddEmployee(new EmployeeDTO
                {
                    Name = emp.Name,
                    Surname = emp.Surname,
                    DateOfBirths = emp.DateOfBirths,
                    Email = emp.Email,
                    Phone = emp.Phone,
                    Details = emp.Details,
                    Photo = emp.Photo,
                    AddressID = emp.AddressID, 
                    DepartmentID =emp.DepartmentID
                });
                Console.WriteLine("...[ Add new employee ]...");
            }
        }

        public static void DeleteEmployee(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(EmployeeDTO));
                var emp = (EmployeeDTO)serializer.Deserialize(stream);
                helper.DeleteEmployee(emp.ID);
                Console.WriteLine("...[ Delete employee ]...");
            }
        }

        public static void UpdateEmployee(TcpClient client)
        {
            using (NetworkStream stream = client.GetStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(EmployeeDTO));
                var emp = (EmployeeDTO)serializer.Deserialize(stream);

                helper.UpdateEmployee(new EmployeeDTO 
                {
                    ID = emp.ID,
                    Name = emp.Name,
                    Surname = emp.Surname,
                    Phone = emp.Phone,
                    DateOfBirths = emp.DateOfBirths,
                    Photo = emp.Photo,
                    Email = emp.Email,
                    Details = emp.Details,
                    AddressID = emp.AddressID,
                    DepartmentID = emp.DepartmentID,                    
                });
                Console.WriteLine("...[ Update employee ]...");
            }
        }
        #endregion


        public static void GetAddress(TcpClient client)
        {
            var tmp = helper.GetAddresses().Select(x => new AddressDTO
            {
                ID = x.Id,
                Apartment = x.Apartment,
                City = x.City,
                House = x.House,
                Street = x.Street
            }
            ).ToList();

            using (NetworkStream stream1 = client.GetStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(tmp.GetType());
                xmlSerializer.Serialize(stream1, tmp);
            }
        }

        public static void GetDepartment(TcpClient client)
        {
            var tmp = helper.GetDepartaments().Select(x => new DepartmentDTO
            {
                ID = x.Id,
                Name = x.Name,
            }
            ).ToList();

            using (NetworkStream stream1 = client.GetStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(tmp.GetType());
                xmlSerializer.Serialize(stream1, tmp);
            }
        }

        public static void GetRetort(TcpClient client)
        {
            var tmp = helper.GetReports().Select(x => new ReportDTO
            {
                WorkTime = x.WorkTime,
                Absenteeism = x.Absenteeism, 
                Salary = x.Salary, 
                Delay = x.Delay, 
                Overtime = x.Overtime,
                Products = x.Products,
                Year = x.Year,
                Month = x.Month
                
            }
            ).ToList();

            using (NetworkStream stream1 = client.GetStream())
            {
                XmlSerializer xmlSerializer = new XmlSerializer(tmp.GetType());
                xmlSerializer.Serialize(stream1, tmp);
            }
        }
    }
}
