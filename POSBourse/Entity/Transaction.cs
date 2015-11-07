//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POSBourse.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public Transaction()
        {
            this.SoldProduct = new HashSet<SoldProduct>();
            this.EmittedCoupon = new HashSet<EmittedCoupon>();
            this.EnteredCoupon = new HashSet<EnteredCoupon>();
            this.EnteredDirectExchange = new HashSet<EnteredDirectExchange>();
            this.EnteredDiscount = new HashSet<EnteredDiscount>();
        }
    
        public int Id { get; set; }
        public System.DateTime datetime { get; set; }
        public decimal giftCouponValue { get; set; }
        public decimal couponValue { get; set; }
        public decimal usedCouponValue { get; set; }
        public decimal exchangeValue { get; set; }
        public decimal usedExchangeValue { get; set; }
        public decimal convertedCouponExchangeValue { get; set; }
        public decimal discountOfferValue { get; set; }
        public decimal directExchangeValue { get; set; }
        public decimal paycardValue { get; set; }
        public decimal cashValue { get; set; }
        public decimal realCashValue { get; set; }
        public decimal emittedCouponValue { get; set; }
        public decimal emittedCashValue { get; set; }
        public decimal realEmittedCashValue { get; set; }
        public decimal totalSalesValue { get; set; }
        public decimal totalBuyValue { get; set; }
        public long productCount { get; set; }
        public string store { get; set; }
    
        public virtual ICollection<SoldProduct> SoldProduct { get; set; }
        public virtual BuyTransaction BuyTransaction { get; set; }
        public virtual CashOutput CashOutput { get; set; }
        public virtual CashInput CashInput { get; set; }
        public virtual ICollection<EmittedCoupon> EmittedCoupon { get; set; }
        public virtual ICollection<EnteredCoupon> EnteredCoupon { get; set; }
        public virtual ICollection<EnteredDirectExchange> EnteredDirectExchange { get; set; }
        public virtual ICollection<EnteredDiscount> EnteredDiscount { get; set; }
    }
}