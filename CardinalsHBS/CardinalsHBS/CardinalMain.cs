using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CardinalsHBS
{
    /// <summary>
    /// Main Class Driving the application of Hotel Blocking System
    /// </summary>

    class CardinalMain
    {
        //Buffer for placing Orders
        public static MultiCellBuffer n1 = new MultiCellBuffer();
        public static MultiCellBuffer n2 = new MultiCellBuffer();
        public static MultiCellBuffer n3 = new MultiCellBuffer();

        //Buffer for Receiving Order Status
        public static MultiCellBuffer n4 = new MultiCellBuffer();

        //Travel Agency Objects
        public static TravelAgency TravelAgent = new TravelAgency();
        public static TravelAgency TravelAgency1 = new TravelAgency();
        public static TravelAgency TravelAgency2 = new TravelAgency();
        public static TravelAgency TravelAgency3 = new TravelAgency();
        public static TravelAgency TravelAgency4 = new TravelAgency();
        public static TravelAgency TravelAgency5 = new TravelAgency();
        public static TravelAgency HTravelAgency1 = new TravelAgency();
        public static TravelAgency HTravelAgency2 = new TravelAgency();
        public static TravelAgency HTravelAgency3 = new TravelAgency();
        public static TravelAgency HTravelAgency4 = new TravelAgency();
        public static TravelAgency HTravelAgency5 = new TravelAgency();
        public static TravelAgency STravelAgency1 = new TravelAgency();
        public static TravelAgency STravelAgency2 = new TravelAgency();
        public static TravelAgency STravelAgency3 = new TravelAgency();
        public static TravelAgency STravelAgency4 = new TravelAgency();
        public static TravelAgency STravelAgency5 = new TravelAgency();

        //Hotel Suppliers
        public static HotelSupplier HotelSupplier1 = new HotelSupplier();
        public static HotelSupplier HotelSupplier2 = new HotelSupplier();
        public static HotelSupplier HotelSupplier3 = new HotelSupplier();
       
        //No. of PriceCuts per Each Hotel
        public static int NoOfPriceCuts = 10;

        /// <summary>
        /// Main Method for starting the application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.SetBufferSize(200, 3000);
            Console.WriteLine("Welcome to Cardinal Hotel Booking System!!!");
            Console.WriteLine();
            Console.WriteLine("We hae follwoing hotels with price(per room) and No. of rooms available!!!");
            Console.WriteLine();
            Console.WriteLine("HotelSupplier1 with {1} Rooms at a price of ${0} per room.",HotelSupplier.getRoomPrice("HotelSupplier1"), HotelSupplier.getRoomsAvailable("HotelSupplier1"));
            Console.WriteLine("HotelSupplier2 with {1} Rooms at a price of ${0} per room.", HotelSupplier.getRoomPrice("HotelSupplier2"), HotelSupplier.getRoomsAvailable("HotelSupplier2"));
            Console.WriteLine("HotelSupplier3 with {1} Rooms at a price of ${0} per room.", HotelSupplier.getRoomPrice("HotelSupplier3"), HotelSupplier.getRoomsAvailable("HotelSupplier3"));
            Console.WriteLine();
            Console.WriteLine("Following are the Credit Card No.s for the respective Travel Agencies: ");
            Console.WriteLine();

            //Bank Service Operations .. Applying for New Credit Card
            String Card1= BankService.generatecardno("TravelAgency1");
            String Card2= BankService.generatecardno("TravelAgency2");
            String Card3= BankService.generatecardno("TravelAgency3");
            String Card4= BankService.generatecardno("TravelAgency4");
            String Card5= BankService.generatecardno("TravelAgency5");

            Console.WriteLine("Credit Card Number for TravelAgency1: " + Card1);
            Console.WriteLine("Credit Card Number for TravelAgency2: " + Card2);
            Console.WriteLine("Credit Card Number for TravelAgency3: " + Card3);
            Console.WriteLine("Credit Card Number for TravelAgency4: " + Card4);
            Console.WriteLine("Credit Card Number for TravelAgency5: " + Card5);

            Console.WriteLine();
            //Getting the Input for Credit Card from respective Travel Agencies
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Type in the Credit for TravelAgency{0}: ",i+1);
                String CardNum= Console.ReadLine();
                while (CardNum.Length != 8)
                {
                    Console.WriteLine("Invalid Credit Card format!! (Hint: Exaclty 8 characters>");
                    CardNum = Console.ReadLine();
                }
                TravelAgency.CreditCards[i] = BankService.EncryptCardNo(CardNum);
            }

            Console.WriteLine();
            Console.WriteLine("Thank You For Entering the Card Details !!!");
            Console.WriteLine();
            Console.WriteLine("<Hint: For Verfiying 'Rooms Full' Conditions specify the no. of events in the range of 25 plus..>");
            Console.WriteLine();
            Console.WriteLine("Do you want to Enter the No. of PriceCut Event to happen for Each Hotel Supplier??");
            Console.WriteLine("<Default is 5-10 per Supplier depending on the lowprice or highprice>(Y/N): ");
           
            String option = Console.ReadLine();
            if (option.ToUpper().Equals("Y"))
            {
                //Option to modify the no of event proabilities
                Console.WriteLine("Enter the No. of Price Cut Events: ");
                NoOfPriceCuts = Convert.ToInt32(Console.ReadLine());
                while (NoOfPriceCuts <= 0)
                {
                    Console.WriteLine("Enter a minimum value of 1 or more...");
                    NoOfPriceCuts = Convert.ToInt32(Console.ReadLine());
                }
            }
            Console.WriteLine();
            Console.WriteLine("Starting to Execute Events....");
            Thread.Sleep(2000);

            Thread h1 = new Thread(new ThreadStart(HotelSupplier1.InvokePricingModel));
            Thread h2 = new Thread(new ThreadStart(HotelSupplier2.InvokePricingModel));
            Thread h3 = new Thread(new ThreadStart(HotelSupplier3.InvokePricingModel));

            h1.Name = "HotelSupplier1";
            h2.Name = "HotelSupplier2";
            h3.Name = "HotelSupplier3";
            h1.Start();
            h2.Start();
            h3.Start();

            //Travel Agency Subscribing to PriceCut Event of Hotel Supplier
            HotelSupplier.priceCut += new priceCutEvent(TravelAgent.RoomsPriceCut);
           
            Console.Read();
        }
        /// <summary>
        /// This method starts the threads for placing orders after a price cut event
        /// </summary>
        /// <param name="i">Input Paramter that determines in which HotelSupplier the Price Cut Event Occurred</param>
        public static void startOrders(int i)
        {
            //When PriceCut Event happens for HotelSupplier1
            if (i == 1)
            {
                Thread h1t1 = new Thread(new ThreadStart(CardinalMain.TravelAgency1.placeOrder));
                Thread h1t2 = new Thread(new ThreadStart(CardinalMain.TravelAgency2.placeOrder));
                Thread h1t3 = new Thread(new ThreadStart(CardinalMain.TravelAgency3.placeOrder));
                Thread h1t4 = new Thread(new ThreadStart(CardinalMain.TravelAgency4.placeOrder));
                Thread h1t5 = new Thread(new ThreadStart(CardinalMain.TravelAgency5.placeOrder));

                Thread H1 = new Thread(new ThreadStart(CardinalMain.HotelSupplier1.receiveOrder));
                H1.Name = "H1";
                h1t1.Start();
                h1t2.Start();
                h1t3.Start();
                h1t4.Start();
                h1t5.Start();
                H1.Start();
            }
            //When PriceCut Event happens for HotelSupplier2
            if (i == 2)
            {
                Thread h2t1 = new Thread(new ThreadStart(CardinalMain.HTravelAgency1.placeOrder));
                Thread h2t2 = new Thread(new ThreadStart(CardinalMain.HTravelAgency2.placeOrder));
                Thread h2t3 = new Thread(new ThreadStart(CardinalMain.HTravelAgency3.placeOrder));
                Thread h2t4 = new Thread(new ThreadStart(CardinalMain.HTravelAgency4.placeOrder));
                Thread h2t5 = new Thread(new ThreadStart(CardinalMain.HTravelAgency5.placeOrder));

                Thread H2 = new Thread(new ThreadStart(CardinalMain.HotelSupplier2.receiveOrder));
                H2.Name = "H2";
                h2t1.Start();
                h2t2.Start();
                h2t3.Start();
                h2t4.Start();
                h2t5.Start();
                H2.Start();
            }
            //When PriceCut Event happens for HotelSupplier3
            if (i == 3)
            {
                Thread h3t1 = new Thread(new ThreadStart(CardinalMain.STravelAgency1.placeOrder));
                Thread h3t2 = new Thread(new ThreadStart(CardinalMain.STravelAgency2.placeOrder));
                Thread h3t3 = new Thread(new ThreadStart(CardinalMain.STravelAgency3.placeOrder));
                Thread h3t4 = new Thread(new ThreadStart(CardinalMain.STravelAgency4.placeOrder));
                Thread h3t5 = new Thread(new ThreadStart(CardinalMain.STravelAgency5.placeOrder));

                Thread H3 = new Thread(new ThreadStart(CardinalMain.HotelSupplier3.receiveOrder));
                H3.Name = "H3"; 
                h3t1.Start();
                h3t2.Start();
                h3t3.Start();
                h3t4.Start();
                h3t5.Start();
                H3.Start();
            

            }     
            
        }
    }
}
