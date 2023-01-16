// <copyright file="CustomerTests.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace Domain.Tests
{
    using Domain;

    /// <summary>
    /// Модульные тесты для класса Customer.
    /// </summary>
    [TestFixture]
    public class CustomerTests
    {
        /// <summary>
        /// Тест на конструктор с правильным ФИ.
        /// </summary>
        /// <param name="middleName"> Отчество. </param>
        [Test]

        public void Ctor_Valid_DoesnotThrowException()
        {
            // Arrange
            // Act
            // Assert
            Assert.DoesNotThrow(() => _ = new Customer("Иванов", "Иван", "88888888888"));
        }

        /// <summary>
        /// Тест на конструктор с неправильной фамилией.
        /// </summary>
        /// <param name="lastName"> Фамилия.</param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_WrongLastName_ThrowException(string? lastName)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Customer(lastName, "Иван", "88888888888"));
        }

        /// <summary>
        /// Тест на конструктор с неправильным именем.
        /// </summary>
        /// <param name="firstName"> Имя.</param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_WrongFirstName_ThrowException(string? firstName)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Customer("Иванов", firstName, "88888888888"));
        }

        /// <summary>
        /// Тест на конструктор с пустым номером телефона.
        /// </summary>
        /// <param name="phoneNumber"> Номер телефона.</param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_WrongPhoneNumber_ThrowException(string? phoneNumber)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Customer("Иванов", "Иван", phoneNumber));
        }

        /// <summary>
        /// Проверка на эквивиалентность двух одинаковых экземпляров.
        /// </summary>
        [Test]
        public void AreEquals_Success()
        {
            // Arrange
            var customer = new Customer("Иванов", "Иван", "88888888888");
            var customer2 = customer;

            // Act & Assert
            Assert.That(customer, Is.EqualTo(customer2));
        }

        /// <summary>
        /// Проверка на преобразование в строку. Имеется отчество.
        /// </summary>
        [Test]
        public void ToString_ValidData_Success()
        {
            // Arrange
            var customer = new Customer("Иванов", "Иван", "88888888888");
            var expected = "Иванов Иван";

            // Act & Assert
            Assert.That(customer.ToString(), Is.EqualTo(expected));
        }
    }
}