using System;


namespace collection
{
    //Обьявление новой структуры(типа значений)
    public struct Payment
    {
        public int Petrol;
        public double Volume;
        public DateTime Time;
        public byte GasStation;
        public byte Id;
        public Payment(byte gasStation, DateTime time, int petrol, double volume, byte id)
        {
            GasStation = gasStation;
            Petrol = petrol;
            Volume = volume;
            Time = time;
            Id = id;
        }

    }
    } 

