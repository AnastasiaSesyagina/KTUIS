// <copyright file="Program.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace Demo
{
    using System;
    using DataAccessLayer;
    using DataAccessLayer.ORM;
    using Domain;

    /// <summary>
    /// Исполняемый файл.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        private static void Main()
        {
            var customer = new Customer("Иванов", "Иван", "88888888888");
            var order = new Order("ул. Космонавтов, д. 11", customer, new DateTime(2022, 12, 20, 10, 00, 00), new DateTime(2022, 12, 20, 10, 50, 00));
            var product = new Product("Пицца", 499);
            var listItem = new ListItem(2, product);

            customer.Orders.Add(order);
            order.ListItems.Add(listItem);
            listItem.Add(product, 2);

            Console.WriteLine(customer);
            Console.WriteLine(order);
            Console.WriteLine(listItem);
            Console.WriteLine(product);

            var settings = new Settings();
            settings.AddDabaseServer("STACEY");
            settings.AddDatabase("FoodDelivery");

            using var sessionFactory = Configurator.GetSessionFactory(settings, showSql: true);

            using (var session = sessionFactory.OpenSession())
            {
                // Скорее всего порядок такой:
                // т.к. Products --> ListItems --> Orders --> Customers
                session.Save(customer); // 1
                session.Save(order); // 2
                session.Save(listItem); // 3
                session.Save(product); // 4

                session.Flush();
            }
        }
    }
}