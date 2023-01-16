// <copyright file="CustomerTests.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace Domain.Tests
{
    using Domain;

    /// <summary>
    /// ��������� ����� ��� ������ Customer.
    /// </summary>
    [TestFixture]
    public class CustomerTests
    {
        /// <summary>
        /// ���� �� ����������� � ���������� ��.
        /// </summary>
        /// <param name="middleName"> ��������. </param>
        [Test]

        public void Ctor_Valid_DoesnotThrowException()
        {
            // Arrange
            // Act
            // Assert
            Assert.DoesNotThrow(() => _ = new Customer("������", "����", "88888888888"));
        }

        /// <summary>
        /// ���� �� ����������� � ������������ ��������.
        /// </summary>
        /// <param name="lastName"> �������.</param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_WrongLastName_ThrowException(string? lastName)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Customer(lastName, "����", "88888888888"));
        }

        /// <summary>
        /// ���� �� ����������� � ������������ ������.
        /// </summary>
        /// <param name="firstName"> ���.</param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_WrongFirstName_ThrowException(string? firstName)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Customer("������", firstName, "88888888888"));
        }

        /// <summary>
        /// ���� �� ����������� � ������ ������� ��������.
        /// </summary>
        /// <param name="phoneNumber"> ����� ��������.</param>
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_WrongPhoneNumber_ThrowException(string? phoneNumber)
        {
            // Arrange
            // Act
            // Assert
            Assert.Throws<ArgumentNullException>(() => _ = new Customer("������", "����", phoneNumber));
        }

        /// <summary>
        /// �������� �� ���������������� ���� ���������� �����������.
        /// </summary>
        [Test]
        public void AreEquals_Success()
        {
            // Arrange
            var customer = new Customer("������", "����", "88888888888");
            var customer2 = customer;

            // Act & Assert
            Assert.That(customer, Is.EqualTo(customer2));
        }

        /// <summary>
        /// �������� �� �������������� � ������. ������� ��������.
        /// </summary>
        [Test]
        public void ToString_ValidData_Success()
        {
            // Arrange
            var customer = new Customer("������", "����", "88888888888");
            var expected = "������ ����";

            // Act & Assert
            Assert.That(customer.ToString(), Is.EqualTo(expected));
        }
    }
}