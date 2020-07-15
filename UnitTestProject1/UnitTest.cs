using collection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class CollectionsTest
    {

        [TestMethod]
        public void Add_new_right_items()
        {
            List<Payment> actual_payments = new List<Payment>();
            actual_payments.Add(new Payment(1, new DateTime(2019, 3, 9, 9, 23, 31), 92, 5.12, 001));

            List<Payment> expected_payments = new List<Payment>();
            expected_payments.Add(new Payment(1, new DateTime(2019, 3, 9, 9, 23, 31), 92, 5.12, 001));

            CollectionAssert.AreEqual(actual_payments, expected_payments); // return true
        }

        [TestMethod]
        public void Add_new_false_items()
        {
            List<Payment> actual_payments = new List<Payment>();
            actual_payments.Add(new Payment(2, new DateTime(2020, 4, 9, 9, 23, 31), 92, 6.212, 005));

            List<Payment> expected_payments = new List<Payment>();
            expected_payments.Add(new Payment(1, new DateTime(2019, 3, 9, 9, 23, 31), 92, 5.12, 001));

            CollectionAssert.AreEqual(actual_payments, expected_payments); // return false
        }

        [TestMethod]
        public void Read_new_right_payments()
        {
            byte actual_gas_station = 1;
            var actual_petrol=92;
            var actual_volume= 30;
            var actual_time = new DateTime(2020,05,03,16,00,30);
            byte actual_id= 001;
             List<Payment> actual_payments = new List<Payment>();
            actual_payments.Add(new Payment(actual_gas_station, actual_time, actual_petrol, actual_volume, actual_id));
            List<Payment> expected_payments = new List<Payment>();
            expected_payments.Add(new Payment(actual_gas_station, actual_time, actual_petrol, actual_volume, actual_id));
            CollectionAssert.AreEqual(expected_payments, actual_payments);
        }
        [TestMethod]
        public void Read_new_false_payments()
        {
            byte actual_gas_station = 1;
            var actual_petrol = 92;
            var actual_volume = 30;
            var actual_time = new DateTime(2020, 05, 03, 16, 00, 30);
            byte actual_id = 001;            
            List<Payment> actual_payments = new List<Payment>();
            actual_payments.Add(new Payment(actual_gas_station, actual_time, actual_petrol, actual_volume, actual_id));
            byte expected_gas_station = 1;
            var expected_petrol = 92;
            var expected_volume = 30;
            var expected_time = new DateTime(2020, 05, 03, 16, 00, 30);
            byte expected_id = 002;
            List<Payment> expected_payments = new List<Payment>();
            expected_payments.Add(new Payment(expected_gas_station, expected_time, expected_petrol, expected_volume, expected_id));
            CollectionAssert.AreEqual(expected_payments, actual_payments);
        }

    }
}
