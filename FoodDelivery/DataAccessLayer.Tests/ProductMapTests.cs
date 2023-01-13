// <copyright file="ProductMap.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace DataAccessLayer.Tests
{
    using FluentNHibernate.Testing;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты маппингов для класса Album.
    /// </summary>
    [TestFixture]
    internal class ProductMapTests : MapTests
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
            ListItem listItem = new ListItem(3, order, product);
            this.Session.Save(listItem);

            // act & assert
            new PersistenceSpecification<Product>(this.Session)
                .VerifyTheMappings(product);
        }
    }
}

