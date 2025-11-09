
This project simulates an online store where placing an order updates inventory, creates an order, and records a payment within a single EF Core transaction.
If any part fails, all changes are rolled back to keep the database consistent.

The solution follows Clean Architecture:

Domain Layer: Entities like Product, Order, Payment

Application Layer: Business logic and interfaces (OrderService, ProductInventoryService)

Infrastructure Layer: EF Core DbContext, repositories, and Unit of Work

Presentation Layer (optional): For testing via console or API (haven't finished this one though)

Isolation Levels

Different isolation levels control how transactions interact.
For this system, Read Committed is best, as it prevents reading uncommitted data and provides a good balance between consistency and performance.

Summary

The system ensures reliable, atomic order processing using EF Core transactions and clean, layered architecture.
