// <copyright file="Person.cs" company="Дюдя, Капанин, Паньков & Сесягина">
// Copyright (c) Дюдя В. А., Капанин А. А., Паньков Р. В., Сесягина А. А. 2022.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Человек.
    /// </summary>
    public class Person
    {
        private string fullName;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Person"/>.
        /// </summary>
        /// <param name="firstName"> Фамилия.</param>
        /// <param name="lastName"> Имя.</param>
        /// <param name="middleName"> Отчество.</param>
        /// <param name="phoneNumber"> Номер телефона.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Person(string firstName, string lastName, string? middleName, string phoneNumber)
        {
            this.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            this.LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            this.MiddleName = middleName;
            this.fullName = this.FullName;
            this.PhoneNumber = phoneNumber ?? throw new ArgumentNullException(nameof(phoneNumber));
        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// Отчество.
        /// </summary>
        public string? MiddleName { get; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        public string PhoneNumber { get; }

        /// <summary>
        /// Полное имя.
        /// </summary>
        public string FullName
        {
            get => this.fullName;
            set
            {
                if (this.MiddleName is not null)
                {
                    this.fullName = string.Concat(this.LastName, " ", this.FirstName[0], ". ", this.MiddleName[0], ".");
                }
                else
                {
                    this.fullName = string.Concat(this.LastName, " ", this.FirstName[0], ". ");
                }
            }
        }

        /// <inheritdoc/>
        public override string ToString()
            => this.FullName;

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is not Person)
            {
                return false;
            }

            return Equals((obj as Person)?.Id, this.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
            => this.Id.GetHashCode();
    }
}