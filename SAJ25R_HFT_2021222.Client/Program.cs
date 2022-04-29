
using ConsoleTools;
using SAJ25R_HFT_2021222.Models.Others;
using SAJ25R_HFT_2021222.Models.Tables;
using System;
using System.Collections.Generic;

namespace SAJ25R_HFT_2021222.Client
{
    class Program
    {
        static RestService rest;

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:7671/", "gun");


            var stat = rest.Get<KeyValuePair<string, double>>("stat/SumWeightByOwner");

            var gunMenu = new ConsoleMenu()
                .Add("\t -List all guns", () => ListAllGuns())
                .Add("\t -Gun by id", () => GetGunByID())
                .Add("\t -Add gun", () => AddGun())
                .Add("\t -Chage gun price", () => ChangeGunPrice())
                .Add("\t -Avarage money spent by owners", () => AvgValueByOwner())
                .Add("\t -Gun owners", () => GunsOwns())
                .Add("\t -Gun weights by owner", () => SumWeightByOwner())
                .Add("\t -Remove gun by Id", () => RemoveGunById())
                .Add("Return", ConsoleMenu.Close);


            var ownerMenu = new ConsoleMenu()
                .Add("\t -List all owners", () => ListAllOwners())
                .Add("\t -Owner by Id", () => GetOwnerById())
                .Add("\t -Add owner", () => AddOwner())
                .Add("\t -Change owner job", () => ChangeOwnerJob())
                .Add("\t -Remove owner by Id", () => RemoveOwnerById())
                .Add("\t -Owner's guns", () => OwnsGuns())
                .Add("Return", ConsoleMenu.Close);



            var retailerMenu = new ConsoleMenu()
                .Add("\t -List all retailers", () => ListAllRetailers())
                .Add("\t -Get retailer by Id", () => GetRetailerById())
                .Add("\t -Add retailer", () => AddRetailer())
                .Add("\t -Change retailer's position", () => ChangeRetailerPosition())
                .Add("\t -Remove retailer by Id", () => RemoveRetailerById())
                .Add("\t -Retailers sold to", () => RetOwns())
                .Add("Return", ConsoleMenu.Close);

            var menu = new ConsoleMenu()
                .Add("Gun menu", gunMenu.Show)
                .Add("Owner menu", ownerMenu.Show)
                .Add("Retailer menu", retailerMenu.Show)
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

            Console.ReadKey();

        }

        private static void ListAllGuns()
        {
            var guns = rest.Get<Gun>("gun");
            Console.WriteLine("\n-- All Guns --\n");
            foreach (var item in guns)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        private static void GetGunByID()
        {
            Console.WriteLine("Type the Gun's Id you want to get!");
            int id = int.Parse(Console.ReadLine());
            var output = rest.Get<Gun>(id, "gun");
            Console.WriteLine(output);
            Console.ReadKey();
        }

        private static Gun _GetGunByID(int id)
        {
            return rest.Get<Gun>(id, "gun");
        }

        private static void AddGun()
        {
            Console.WriteLine("Type the Owner's ID![1-10]");
            int ownerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Type the name of the gun!");
            string gunName = Console.ReadLine();
            Console.WriteLine("Type the caliber!");
            string caliber = Console.ReadLine();
            Console.WriteLine("Type the weight of the gun!");
            int weight = int.Parse(Console.ReadLine());
            Console.WriteLine("Type the price of the gun!");
            int price = int.Parse(Console.ReadLine());
            Gun newgun = new Gun(ownerId, gunName, caliber, weight, price);

            rest.Post(newgun, "gun");

            Console.WriteLine("New Gun added!");
            Console.ReadKey();
        }

        private static void ChangeGunPrice()
        {
            Console.Write("Type the Gun's Id which price you want to change!");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter the new price!");
            int price = int.Parse(Console.ReadLine());

            var oggun = _GetGunByID(id);
            oggun.Price = price;

            rest.Put<Gun>(oggun, "gun");

            Console.WriteLine("Price changed!");
            Console.ReadKey();
        }

        private static void AvgValueByOwner()
        {
            var stat = rest.Get<KeyValuePair<string, double>>("stat/AvgValueByOwner");
            foreach (var item in stat)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        private static void SumWeightByOwner()
        {
            var stat = rest.Get<KeyValuePair<string, double>>("stat/SumWeightByOwner");
            foreach (var item in stat)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        private static void GunsOwns()
        {
            var stat = rest.Get<GunsOwners>("stat/GunsOwns");
            foreach (var item in stat)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }

        private static void RemoveGunById()
        {
            Console.Write("Type the Gun's Id which you want to remove!");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "gun");
            Console.WriteLine("Gun deleted");
            Console.ReadKey();
        }

        private static void ListAllOwners()
        {
            var owners = rest.Get<Owner>("owner");
            Console.WriteLine("\n-- All Owners --\n");
            foreach (var item in owners)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }

        private static void GetOwnerById()
        {
            Console.WriteLine("Type the Owner's Id you want to get![1-10]");
            int id = int.Parse(Console.ReadLine());
            var output = rest.Get<Owner>(id, "owner");
            Console.WriteLine(output);
            Console.ReadKey();
        }

        private static Owner _GetOwnerByID(int id)
        {
            return rest.Get<Owner>(id, "owner");
        }

        private static void AddOwner()
        {
            Console.WriteLine("Type the Seller's Id![11-15]");
            int sellerId = int.Parse(Console.ReadLine());
            Console.WriteLine("Type the owner's age!");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Type the owner's name!");
            string name = Console.ReadLine();
            Console.WriteLine("Type the owner's job!");
            string job = Console.ReadLine();
            Console.WriteLine("type the owner's address!");
            string address = Console.ReadLine();
            Owner newOwner = new Owner(sellerId, age, name, job, address);
            rest.Post(newOwner, "owner");
            Console.WriteLine("New Owner added!");
            Console.ReadKey();
        }

        //update owner
        private static void ChangeOwnerJob()
        {
            Console.WriteLine("Type the Owners's Id which you want to change![1-10]");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Type the owner's new job!");
            string newJob = Console.ReadLine();

            var ogowner = _GetOwnerByID(id);
            ogowner.Job = newJob;

            rest.Put(ogowner, "owner");

            Console.WriteLine("Job changed");
            Console.ReadKey();
        }

        private static void RemoveOwnerById()
        {
            Console.Write("Type the Owners's Id which you want to remove![1-10]");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "owner");
            Console.WriteLine("Owner deleted");
            Console.ReadKey();
        }


        private static void OwnsGuns()
        {
            var stat = rest.Get<OwnersGuns>("stat/OwnsGuns");
            foreach (var item in stat)
            {
                Console.WriteLine(item.OwnName);
                foreach (var gun in item.Guns)
                {
                    Console.WriteLine(" " + gun);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static void ListAllRetailers()
        {
            var ret = rest.Get<Retailer>("retailer");
            Console.WriteLine("\n-- All Retailers --\n");
            foreach (var item in ret)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        private static void GetRetailerById()
        {
            Console.WriteLine("Type the Retailer's Id you want to get![11-15]");
            int id = int.Parse(Console.ReadLine());
            var output = rest.Get<Retailer>(id, "retailer");
            Console.WriteLine(output);
            Console.ReadKey();
        }

        private static Retailer _GetRetailerById(int id)
        {
            return rest.Get<Retailer>(id, "retailer");
        }

        private static void AddRetailer()
        {
            Console.WriteLine("Type the retailer's salary!");
            int salary = int.Parse(Console.ReadLine());
            Console.WriteLine("Type the retailer's name!");
            string name = Console.ReadLine();
            Console.WriteLine("Type the Id of the retailer's desk!");
            int deskId = int.Parse(Console.ReadLine());
            Console.WriteLine("type the reatiler's position!");
            string position = Console.ReadLine();
            Console.WriteLine("Type the date of the selling![YYYY.MM.DD]");
            DateTime sellingDate = DateTime.Parse(Console.ReadLine());
            Retailer newRetailer = new Retailer(salary, name, deskId, position, sellingDate);
            rest.Post(newRetailer, "retailer");
            Console.WriteLine("New Retailer added!");
            Console.ReadKey();
        }

        private static void ChangeRetailerPosition()
        {
            Console.WriteLine("Type the Retailers's Id which you want to change![11-15]");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("New position: ");
            string position = Console.ReadLine();

            var ogretaieler = _GetRetailerById(id);
            ogretaieler.Position = position;
            rest.Put<Retailer>(ogretaieler, "retailer");

            Console.WriteLine("Position changed");
            Console.ReadKey();
        }

        private static void RemoveRetailerById()
        {
            Console.Write("Type the Retailer's Id which you want to remove![11-15]");
            int id = int.Parse(Console.ReadLine());
            rest.Delete(id, "retailer");
            Console.WriteLine("Retailer deleted");
            Console.ReadKey();
        }

        private static void RetOwns()
        {
            var stat = rest.Get<RetailersOwners>("stat/RetOwns");
            foreach (var item in stat)
            {
                Console.WriteLine(item.RetName);
                foreach (var ret in item.Owners)
                {
                    Console.WriteLine(" " + ret);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }

}
