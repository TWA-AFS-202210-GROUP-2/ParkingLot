﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingLot
{
    public class ParkingTicket
    {
        private string parkingTime = default(DateTime).ToShortTimeString();
        private string carPlateNumber;
        private Parkinglot parkingLot;
        private bool isUsed = false;

        public ParkingTicket(string parkedCarPlateNumber, Parkinglot parkingLotObject)
        {
            this.carPlateNumber = parkedCarPlateNumber;
            this.parkingLot = parkingLotObject;
        }

        public string GetParkingTime()
        {
            return this.parkingTime;
        }

        public string GetCarPlateNumber()
        {
            return this.carPlateNumber;
        }

        public Parkinglot GetParkingLot()
        {
            return this.parkingLot;
        }

        public bool GetIsUsed()
        {
            return this.isUsed;
        }

        public void UseTicket()
        {
            this.isUsed = true;
        }
    }
}