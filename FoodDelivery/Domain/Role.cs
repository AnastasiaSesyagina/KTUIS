// <copyright file="Role.cs" company="Дюдя, Капанин, Паньков & Сесягина">
// Copyright (c) Дюдя В. А., Капанин А. А., Паньков Р. В., Сесягина А. А. 2022.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Роль.
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Role"/>.
        /// </summary>
        /// <param name="roleName"> Название роли.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Role(string roleName)
        {
            this.RoleName = roleName ?? throw new ArgumentNullException(nameof(roleName));

        }

        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Название роли.
        /// </summary>
        public string RoleName { get; }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is not Role)
            {
                return false;
            }

            return Equals((obj as Role)?.Id, this.Id);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
            => this.Id.GetHashCode();
    }
}
