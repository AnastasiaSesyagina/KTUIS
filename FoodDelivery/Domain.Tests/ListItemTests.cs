using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Order order = new Order("ул. Космонавтов, д. 11", customer, new TimeOnly(10, 00, 00), new TimeOnly(10, 50, 00));

            // Act
            // Assert
            Assert.DoesNotThrow(() => _ = new ListItem(3, order));
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
            Order order = new Order("ул. Космонавтов, д. 11", customer, new TimeOnly(10, 00, 00), new TimeOnly(10, 50, 00));

            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new ListItem(quantity, order));
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
            Assert.Throws<ArgumentNullException>(() => _ = new ListItem(2, order));
        }
    }
}
