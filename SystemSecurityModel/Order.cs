﻿using System;

namespace SystemSecurityModel
{
    public class Order
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int SystemmID { get; set; }
        public int? ExecutorID { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }
        public virtual Customer Customer { set; get; }
        public virtual Systemm Systemm { set; get; }
        public Executor Executor { set; get; }
    }

    public enum OrderStatus
    {
        Принят = 0, Выполняется = 1, Готов = 2, Оплачен = 3
    }
}
