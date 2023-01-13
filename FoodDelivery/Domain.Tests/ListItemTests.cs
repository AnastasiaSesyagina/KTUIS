// <copyright file="ListItemTests.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>


namespace Domain.Tests
{
    using Domain;

    /// <summary>
    /// Модульные тесты для класса ListItem.
    /// </summary>
    [TestFixture]
    public class ListItemTests
    {
        /// <summary>
        /// Тест на конструктор с правильным количеством блюд.
        /// </summary>
        [Test]
        public void Ctor_Valid_DoesnotThrowException()
        {
            // Arrange
            Customer customer = new Customer("Иванов", "Иван", "88888888888");
            Order order = new Order("ул. Космонавтов, д. 11", customer, new DateTime(2022, 12, 20, 10, 00, 00), new DateTime(2022, 12, 20, 10, 50, 00));
            Product product = new Product("Пицца", 499);

            // Act
            // Assert
            Assert.DoesNotThrow(() => _ = new ListItem(3, order, product));
        }

        /// <summary>
        /// Тест на конструктор с неправильным количеством блюд.
        /// </summary>
        /// <param name="quantity"> Количество.</param>
        [Test]
        [TestCase(-30)]
        [TestCase(0)]
        public void Ctor_WrongQuantity_ThrowException(int quantity)
        {
            // Arrange
            Customer customer = new Customer("Иванов", "Иван", "88888888888");
            Order order = new Order("ул. Космонавтов, д. 11", customer, new DateTime(2022, 12, 20, 10, 00, 00), new DateTime(2022, 12, 20, 10, 50, 00));
            Product product = new Product("Пицца", 499);

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new ListItem(quantity, order, product));
        }

        /// <summary>
        /// Тест на конструктор с неправильным заказом.
        /// </summary>
        /// <param name="order"> Заказ.</param>
        [Test]
        [TestCase(null)]

        public void Ctor_WrongOrder_ThrowException(Order? order)
        {
            // Arrange
            // Act
            // Assert
            Product product = new Product("Пицца", 499);
            Assert.Throws<ArgumentNullException>(() => _ = new ListItem(2, order, product));
        }
    }
}
