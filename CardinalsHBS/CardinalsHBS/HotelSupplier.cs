using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading;

namespace CardinalsHBS
{
   //Event for Hotel price cuts
   public delegate void priceCutEvent(Int32 price, String AgencyName);
   
    class HotelSupplier
    {
        //Price of respective hotel room
        private static Int32 H1RoomPrice = 3000;
        private static Int32 H2RoomPrice = 5000;
        private static Int32 H3RoomPrice = 7000;

        //Total No. of Rooms Available in Each Hotel
        private static Int32 H1RoomCount = 150;
        private static Int32 H2RoomCount = 125;
        private static Int32 H3RoomCount = 175;

        private static Queue<OrderClass> OrderProcessingQueue = new Queue<OrderClass>();
        static Random rand = new Random();

        public HotelSupplier()
        {
        }


        //Reference for priceCutEvent
        public static event priceCutEvent priceCut;

        /// <summary>
        /// This method generates an event based on the previous price of the hotel room
        /// </summary>
        /// <param name="price">New Price</param>
        /// <param name="HotelName">Hotel Supplier Name</param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void changePrice(Int32 price,String HotelName)
        {
            if (HotelName.Equals("HotelSupplier1"))
            {
                if (price < H1RoomPrice)
                {
                    if (priceCut != null)
                        priceCut(price, Thread.CurrentThread.Name);
                }
                H1RoomPrice = price;
            }
            if (HotelName.Equals("HotelSupplier2"))
            {
                if (price < H2RoomPrice)
                {
                    if (priceCut != null)
                        priceCut(price, Thread.CurrentThread.Name);
                }
                H2RoomPrice = price;
            }
            if (HotelName.Equals("HotelSupplier3"))
            {
                if (price < H3RoomPrice)
                {
                    if (priceCut != null)
                        priceCut(price, Thread.CurrentThread.Name);
                }
                H3RoomPrice = price;
            }
        }

        /// <summary>
        /// Pricing Model which determines price randomly .. Sometimes it goes high and sometimes it goes low.
        /// Change Price method is called with the new price.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InvokePricingModel()
        {
            if (Thread.CurrentThread.Name.Equals("HotelSupplier1"))
            {
                for (Int32 i = 0; i < CardinalMain.NoOfPriceCuts; i++)
                {
                    Thread.Sleep(500);
                    Int32 newprice = rand.Next(2500, 3500);//Both low and high prices possible
                    changePrice(newprice,Thread.CurrentThread.Name);
                }
            }

            if (Thread.CurrentThread.Name.Equals("HotelSupplier2"))
            {
                for (Int32 i = 0; i < CardinalMain.NoOfPriceCuts; i++)
                {
                    Thread.Sleep(500);
                    Int32 newprice = rand.Next(4500, 5500);//Both low and high prices possible
                    changePrice(newprice,Thread.CurrentThread.Name);
                }
            }
            if (Thread.CurrentThread.Name.Equals("HotelSupplier3"))
            {
                for (Int32 i = 0; i < CardinalMain.NoOfPriceCuts; i++)
                {
                    Thread.Sleep(500);
                    Int32 newprice = rand.Next(6500, 7500);//Both low and high prices possible
                    changePrice(newprice, Thread.CurrentThread.Name);
                }
            }
            
        }

        /// <summary>
        /// This method receives the order placed by the travel agencies. The orders are read from the multi-cell
        /// buffer
        /// </summary>
        public void receiveOrder()
        {
            Boolean[] arr= new Boolean[5];
            int i = 15;
            while(i!=0)
            {
                if(Thread.CurrentThread.Name.Equals("H1"))
                {
                if(Monitor.TryEnter(CardinalMain.n1))
                {

                    try
                    {
                        OrderClass OrderObject = Decoder(CardinalMain.n1.getOneCell());
                        Console.WriteLine("Order Object Received by " + OrderObject.getReceiverID() + " from: " + OrderObject.getSenderID());
                        OrderProcessingQueue.Enqueue(OrderObject);
                        Console.WriteLine();
                    }
                    finally
                    {
                        i--;
                        Monitor.Exit(CardinalMain.n1);
                    }
                }
                }
                else if (Thread.CurrentThread.Name.Equals("H2"))
                {
                    if (Monitor.TryEnter(CardinalMain.n2))
                    {

                        try
                        {
                            OrderClass OrderObject = Decoder(CardinalMain.n2.getOneCell());
                            Console.WriteLine("Order Object Received by " + OrderObject.getReceiverID() + " from: " + OrderObject.getSenderID());
                            OrderProcessingQueue.Enqueue(OrderObject);
                            Console.WriteLine();
                        }
                        finally
                        {
                            i--;
                            Monitor.Exit(CardinalMain.n2);
                        }
                    }
                }
                else if (Thread.CurrentThread.Name.Equals("H3"))
                {
                    if(Monitor.TryEnter(CardinalMain.n3))
                    {

                        try
                        {
                            OrderClass OrderObject = Decoder(CardinalMain.n3.getOneCell());
                            Console.WriteLine("Order Object Received by " + OrderObject.getReceiverID() + " from: " + OrderObject.getSenderID());
                            OrderProcessingQueue.Enqueue(OrderObject);
                            Console.WriteLine();
                        }
                        finally
                        {
                            i--;
                            Monitor.Exit(CardinalMain.n3);
                        }
                    }
                }

                //Order Processing Block
                {
                    HotelSupplier OrderProcessingObject = new HotelSupplier();
                    TravelAgency OrderStatusObject = new TravelAgency();
                    Thread OrderProcessingThread = new Thread(new ThreadStart(OrderProcessingObject.processOrder));
                    Thread OrderStatusThread = new Thread(new ThreadStart(OrderStatusObject.receiveOrderConfirmation));

                    OrderProcessingThread.Start();
                    OrderStatusThread.Start();
                    OrderStatusThread.Join();
                    OrderProcessingThread.Join();
                }
                
            }

           
        }


        /// <summary>
        /// Decodes the Order Information String and re-constructs it into a object of type Order Class
        /// </summary>
        /// <param name="CurrentOrder"></param>
        /// <returns></returns>
        private OrderClass Decoder(String CurrentOrder)
        {
            OrderClass OrderObject = new OrderClass();
            if (CurrentOrder != null)
            {
                String[] arr = CurrentOrder.Split('-');

                OrderObject.setSenderID(arr[0]);
                OrderObject.setNoOfRooms(Convert.ToInt32(arr[1]));
                OrderObject.setCardNo(arr[2]);
                OrderObject.setReceieverID(arr[3]);
                OrderObject.setNoOfDays(Convert.ToInt32(arr[4]));
            }
            return OrderObject;
        }

        /// <summary>
        ///  Based on the hotel name rooms available is returned
        /// </summary>
        /// <param name="HotelName">Hotel Name</param>
        /// <returns>No of Rooms Available</returns>
        public static Int32 getRoomsAvailable(String HotelName)
        {
            if (HotelName.Equals("HotelSupplier1")&&H1RoomCount>0)
                return H1RoomCount;
            else if (HotelName.Equals("HotelSupplier2")&&H2RoomCount>0)
                return H2RoomCount;
            else if (HotelName.Equals("HotelSupplier3")&&H3RoomCount>0)
                return H3RoomCount;
            else
                return 0;
        }

        /// <summary>
        /// Based on the Hotel Name room price is returned
        /// </summary>
        /// <param name="HotelName">Hotel Name</param>
        /// <returns>Room Price of the hotel</returns>
        public static Int32 getRoomPrice(String HotelName)
        {
            if (HotelName.Equals("HotelSupplier1"))
                return H1RoomPrice;
            else if (HotelName.Equals("HotelSupplier2"))
                return H2RoomPrice;
            else if (HotelName.Equals("HotelSupplier3"))
                return H3RoomPrice;
            else
                return 0;
        }

        /// <summary>
        /// Once the Hotel Supplier Receives the Order process order is called for processing the order
        /// and sends back the result to the travel agency 
        /// </summary>
        public void processOrder()
        {
            while (OrderProcessingQueue.Count!=0)
            {
                String result = "";
                try
                {
                    OrderClass currentOrder = OrderProcessingQueue.Dequeue();
                    
                    if (currentOrder.getReceiverID().Equals("HotelSupplier1"))
                    {
                        int roomsRequired = currentOrder.getNoOfRooms();
                        if (roomsRequired <= H1RoomCount)
                        {
                            //Total Cost Inclusive of 15 Percent Tax + 2 Percent Location Charges
                            double amount = (roomsRequired * H1RoomPrice)+((roomsRequired * H1RoomPrice) * 0.15) +((roomsRequired * H1RoomPrice) * 0.02);
                            if(BankService.verifyaccount(currentOrder.getSenderID(),currentOrder.getCardNo()))
                            {
                            H1RoomCount = H1RoomCount - roomsRequired;
                            result = "Order Status from " + currentOrder.getReceiverID() + " sent back to " + currentOrder.getSenderID() + ":|";
                            result = result + "Required No. of rooms are booked by " + currentOrder.getSenderID() + " at " + currentOrder.getReceiverID() + ": " + currentOrder.getNoOfRooms() + " Rooms |";
                            result = result + "Total Cost of Booking (including taxes+location charges): $" + amount + " |";
                            result = result + "Processed At: " + DateTime.Now.ToString() + " |";
                            }
                            else{
                                result = "Order Status from " + currentOrder.getReceiverID() + " sent back to " + currentOrder.getSenderID() + ":|";
                                result = "Invalid Credit Card Number for: "+currentOrder.getSenderID()+"|";
                                result = result + "Processed At: " + DateTime.Now.ToString() + " |";
                            }
                        }
                        else
                        {
                            result = "Sorry HotelSupplier1 Rooms are full.. Not Enough rooms Available!!! |" + "Order from " + currentOrder.getSenderID() + " could not be processed. |";
                            result = result + "Processed At: " + DateTime.Now.ToString() + " |";
                        }
                    }

                    else if (currentOrder.getReceiverID().Equals("HotelSupplier2"))
                    {
                        int roomsRequired = currentOrder.getNoOfRooms();
                        if (roomsRequired <= H2RoomCount)
                        {
                            //Total Cost Inclusive of 17 Percent Tax + 3 Percent Location Charges
                            double amount = (roomsRequired * H2RoomPrice) + ((roomsRequired * H2RoomPrice) * 0.17) + ((roomsRequired * H2RoomPrice) * 0.03);
                            if (BankService.verifyaccount(currentOrder.getSenderID(), currentOrder.getCardNo()))
                            {
                                H2RoomCount = H2RoomCount - roomsRequired;
                                result = "Order Status from " + currentOrder.getReceiverID() + " sent back to " + currentOrder.getSenderID() + " :|";
                                result = result + "Required No. of rooms are booked by " + currentOrder.getSenderID() + " at " + currentOrder.getReceiverID() + ": " + currentOrder.getNoOfRooms() + " Rooms |";
                                result = result + "Total Cost of Booking (including taxes+location charges): $" + amount + " |";
                                result = result + "Processed At: " +DateTime.Now.ToString() + " |";
                            }
                            else
                            {
                                result = "Order Status from " + currentOrder.getReceiverID() + " sent back to " + currentOrder.getSenderID() + ":|";
                                result = "Invalid Credit Card Number for: " + currentOrder.getSenderID() + "|";
                                result = result + "Processed At: " + DateTime.Now.ToString() + " |";
                            }
                        }
                        else
                        {
                            result = "Sorry HotelSupplier2 Rooms are full.. Not Enough rooms Available!!! |" + "Order from " + currentOrder.getSenderID() + " could not be processed. |";
                            result = result + "Processed At: " + DateTime.Now.ToString() + " |";
                        }
                    }

                    else if (currentOrder.getReceiverID().Equals("HotelSupplier3"))
                    {
                        int roomsRequired = currentOrder.getNoOfRooms();
                        if (roomsRequired <= H3RoomCount)
                        {
                            //Total Cost Inclusive of 14 Percent Tax + 4 percent Location Charges
                            double amount = (roomsRequired * H3RoomPrice) + ((roomsRequired * H3RoomPrice) * 0.14) + ((roomsRequired * H3RoomPrice) * 0.04);
                            if (BankService.verifyaccount(currentOrder.getSenderID(), currentOrder.getCardNo()))
                            {
                                H3RoomCount = H3RoomCount - roomsRequired;
                                result = "Order Status from " + currentOrder.getReceiverID() + " sent back to " + currentOrder.getSenderID() + ":|";
                                result = result + "Required No. of rooms are booked by " + currentOrder.getSenderID() + " at " + currentOrder.getReceiverID() + ": " + currentOrder.getNoOfRooms() + " Rooms |";
                                result = result + "Total Cost of Booking (including taxes+location charges): $" + amount + " |";
                                result = result + "Processed At: " + DateTime.Now.ToString() + " |";
                            }
                            else
                            {
                                result = "Order Status from " + currentOrder.getReceiverID() + " sent back to " + currentOrder.getSenderID() + ":|";
                                result = "Invalid Credit Card Number for: " + currentOrder.getSenderID() + "|";
                                result = result + "Processed At: " + DateTime.Now.ToString() + " |";
                            }
                        }
                        else
                        {
                            result = "Sorry HotelSupplier3 Rooms are full.. Not Enough rooms Available!!! |" + "Order from " + currentOrder.getSenderID() + " could not be processed. |";
                            result = result + "Processed At: " + DateTime.Now.ToString() + " |";
                        }

                    }
                    //Sends back the order to Travel Agency using a separate buffer cell
                    if (Monitor.TryEnter(CardinalMain.n4))
                    {
                        try
                        {
                            CardinalMain.n4.setOneCell(result);//Order Status Sent to Travel Agency
                        }
                        finally
                        {
                            result = "";
                            Monitor.Exit(CardinalMain.n4);
                        }
                    }

                }
                finally
                {
                   
                }
            }
            
        }
    }
}
