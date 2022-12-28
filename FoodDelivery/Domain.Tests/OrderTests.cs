// <copyright file="OrderTests.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace Domain.Tests
{
    using Domain;

    /// <summary>
    /// Модульные тесты для класса Order.
    /// </summary>
    [TestFixture]
    public class OrderTests
    {
        /// <summary>
        /// Тест на конструктор с правильным адресом.
        /// </summary>
        [Test]
        public void Ctor_Valid_DoesnotThrowException()
        {
            // Arrange
            // Act
            // Assert
            Assert.DoesNotThrow(() => _ = new Order("ул. Космонавтов, д. 11", new TimeOnly(10, 00, 00), new TimeOnly(10, 50, 00)));
        }

        /// <summary>
        /// Тест на конструктор с неправильным адресом.
        /// </summary>
        /// <param name="address"> Адрес.</param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_WrongAddress_ThrowException(string? address)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Order(address, new TimeOnly(10, 00, 00), new TimeOnly(10, 50, 00)));
        }
    }
}
