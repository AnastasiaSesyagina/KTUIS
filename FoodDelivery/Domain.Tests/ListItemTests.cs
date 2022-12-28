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
            // Act
            // Assert
            Assert.DoesNotThrow(() => _ = new ListItem(3));
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
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new ListItem(quantity));
        }
    }
}
