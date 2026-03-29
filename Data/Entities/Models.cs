// Models for Grocery Store Management System

using System;
using System.Collections.Generic;

namespace GroceryStoreManagementSystem.Models
{
    // Category Entity
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }

    // Product Entity
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
    }

    // ProductAttribute Entity
    public class ProductAttribute
    {
        public int Id { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public virtual Product Product { get; set; }
    }

    // Customer Entity
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }

    // Supplier Entity
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }

    // Invoice Entity
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }

    // InvoiceDetail Entity
    public class InvoiceDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Product Product { get; set; }
        public virtual Invoice Invoice { get; set; }
    }

    // Order Entity
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

    // OrderDetail Entity
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }

    // StockMovement Entity
    public class StockMovement
    {
        public int Id { get; set; }
        public DateTime MovementDate { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }

    // Payment Entity
    public class Payment
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}