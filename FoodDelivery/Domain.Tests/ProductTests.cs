// <copyright file="ProductTests.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace Domain.Tests
{
    using Domain;

    /// <summary>
    /// Модульные тесты для класса Product.
    /// </summary>
    [TestFixture]
    public class ProductTests
    {
        /// <summary>
        /// Тест на конструктор с правильным названием блюда и ценой.
        /// </summary>
        [Test]
        public void Ctor_Valid_DoesnotThrowException()
        {
            // Arrange
            // Act
            // Assert
            Assert.DoesNotThrow(() => _ = new Product("Пицца", 499));
        }

        /// <summary>
        /// Тест на конструктор с неправильным названием блюда.
        /// </summary>
        /// <param name="menuName"> Название блюда.</param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_WrongProductName_ThrowException(string? menuName)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Product(menuName, 499));
        }

        /// <summary>
        /// Тест на конструктор с неправильной ценой.
        /// </summary>
        /// <param name="price"> Цена блюда.</param>
        [Test]
        [TestCase(-30)]
        [TestCase(0)]
        public void Ctor_WrongPrice_ThrowException(decimal price)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _ = new Product("Пицца", price));
        }


        /// <summary>
        /// Проверка на эквивиалентность двух одинаковых экземпляров.
        /// </summary>
        [Test]
        public void AreEquals_Success()
        {
            // Arrange
            var product = new Product("Пицца", 499);
            var product2 = product;

            // Act & Assert
            Assert.That(product, Is.EqualTo(product2));
        }

        /// <summary>
        /// Проверка на преобразование в строку.
        /// </summary>
        [Test]
        public void ToString_ValidData_Success()
        {
            // Arrange
            var product = new Product("Пицца", 499);
            var expected = "Пицца, 499";

            // Act & Assert
            Assert.That(product.ToString(), Is.EqualTo(expected));
        }
    }
}
