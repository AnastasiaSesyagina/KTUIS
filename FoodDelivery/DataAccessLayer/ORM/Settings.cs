// <copyright file="Settings.cs" company="ActiVia">
// Copyright (c) ActiVia 2022.
// </copyright>

namespace DataAccessLayer
{
    /// <summary>
    /// Настройки для СУБД.
    /// </summary>
    public sealed class Settings
    {
        private string dabaseServerName;
        private string databaseName;

        /// <summary>
        /// Добавление сервера.
        /// </summary>
        /// <param name="serverName">Имя сервера.</param>
        public void AddDabaseServer(string serverName)
        {
            this.dabaseServerName = serverName;
        }

        /// <summary>
        /// Получение имени сервера.
        /// </summary>
        /// <returns>Имя сервера.</returns>
        public string GetDatabaseServer()
        {
            return this.dabaseServerName;
        }

        /// <summary>
        /// Добавление БД.
        /// </summary>
        /// <param name="databaseName">Название БД.</param>
        public void AddDatabase(string databaseName)
        {
            this.databaseName = databaseName;
        }

        /// <summary>
        /// Получение названия БД.
        /// </summary>
        /// <returns>Название БД.</returns>
        public string GetDatabaseName()
        {
            return this.databaseName;
        }
    }
}
