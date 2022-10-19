// <copyright file="PersonRole.cs" company="Дюдя, Капанин, Паньков & Сесягина">
// Copyright (c) Дюдя В. А., Капанин А. А., Паньков Р. В., Сесягина А. А. 2022.
// </copyright>

namespace Domain
{
    /// <summary>
    /// Роль человека.
    /// </summary>
    public class PersonRole
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid Id { get; }

        // !!!Еще должны быть ссылки на Person(ID) и Role(ID)
    }
}
