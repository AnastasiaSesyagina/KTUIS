// <copyright file="ListItemMapTests.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace DataAccessLayer.Tests
{
    using FluentNHibernate.Testing;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты маппингов для класса ListItem.
    /// </summary>
    [TestFixture]
    internal class ListItemMapTests : MapTests
    {
        /// <summary>
        /// Тест правильной работы маппинга.
        /// </summary>
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // arrange
            Customer customer = new Customer("Иванов", "Иван", "88888888888");
            this.Session.Save(customer);
            Order order = new Order("ул. Космонавтов, д. 11", customer, new DateTime(2022, 12, 20, 10, 00, 00), new DateTime(2022, 12, 20, 10, 50, 00));
            this.Session.Save(order);
            Product product = new Product("Пицца", 499);
            var listItem = new ListItem(3, order, product);

            // act & assert
            new PersistenceSpecification<Order>(this.Session)
                .VerifyTheMappings(order);
        }
    }
}
