// <copyright file="CustomerMapTests.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace DataAccessLayer.Tests
{
    using FluentNHibernate.Testing;
    using Domain;
    using NUnit.Framework;

    /// <summary>
    /// Тесты маппингов для класса Customer.
    /// </summary>
    [TestFixture]
    internal class CustomerMapTests : MapTests
    {
        /// <summary>
        /// Тест правильной работы маппинга.
        /// </summary>
        [Test]
        public void PersistenceSpecification_ValidData_Success()
        {
            // Arrange
            var customer = new Customer("Иванов", "Иван", "88888888888");

            // Act & Assert
            new PersistenceSpecification<Customer>(this.Session)
                .VerifyTheMappings(customer);
        }
    }
}